using log4net;
using System;
using System.Collections.Generic;
using System.Threading;

namespace OPCCsvLoggerClient
{
  /// <summary>
  /// This class encapsulates a thread and a queue. Items can be enqueue and 
  /// will later be handled by the thread. QueueThread is used when the data
  /// are expected to arrive fast and thus it makes sure to have a dedicated
  /// physical thread for them.
  /// </summary>
  /// <typeparam name="T">Type of items in the queue.</typeparam>
  public class QueueThread<T>
  {
    #region private fields
    /// <summary>
    /// Thread queue runs in.
    /// </summary>
    private Thread thread;

    /// <summary>
    /// If not null, the created thread is given this name.
    /// </summary>
    private readonly string threadName;

    /// <summary>
    /// Max items allowed to be in the queue.
    /// </summary>
    private const int maxQueueSize = 100000;

    /// <summary>
    /// The queue with data.
    /// </summary>
    private readonly Queue<T> queue = new Queue<T>();

    /// <summary>
    /// Synchronizes access to the queue.
    /// </summary>
    private readonly object queueLock = new Object();

    /// <summary>
    /// Semaphore used to detect addition of an item to the queue.
    /// </summary>
    private readonly ManualResetEvent itemsPresent = new ManualResetEvent(false);

    /// <summary>
    /// Handler to execute when item arrives.
    /// </summary>
    private readonly Action<T> handler;

    /// <summary>
    /// Priority of thread to create.
    /// </summary>
    private readonly ThreadPriority threadPriority;

    /// <summary>
    /// Flag which is set to true when queue is going to shut down.
    /// </summary>
    private volatile bool threadStopped;

    /// <summary>
    /// Event used to notify that the processing in queue is completed.
    /// </summary>
    private readonly ManualResetEvent queueDone =
      new ManualResetEvent(false);

    private static readonly log4net.ILog Log = LogManager.GetLogger(typeof(QueueThread<T>));

    #endregion

    #region private methods
    /// <summary>
    /// Processing thread executed.
    /// </summary>
    private void ThreadMain()
    {
      Log.InfoFormat("QueueThread {0} started, count: {1}.", Thread.CurrentThread.ManagedThreadId, queue.Count);
      while (!threadStopped)
      {
        T item = default(T);
        bool hasItem = false;

        Log.Debug("Waiting for item.");
        itemsPresent.WaitOne();
        lock (queueLock)
        {
          if (queue.Count > 0)
          {
            item = queue.Dequeue();
            hasItem = true;
          }
          if (queue.Count == 0)
          {
            itemsPresent.Reset();
          }
        }

        Thread.MemoryBarrier();
        if (hasItem && !threadStopped)
        {
          Log.Debug("Executing item.");
          handler(item);
        }

        Thread.MemoryBarrier();
      }

      Log.InfoFormat("QueueThread {0} ending, count: {1}.", Thread.CurrentThread.ManagedThreadId, queue.Count);
      Log.Debug("Queue done, setting event.");
      queueDone.Set();
    }

    /// <summary>
    /// Creates the thread to process queue items.
    /// </summary>
    private void CreateThread(ThreadPriority priority)
    {
      thread = new Thread(ThreadMain);
      thread.IsBackground = true;
      thread.Priority = priority;
      if (threadName != null)
        thread.Name = threadName;

      thread.Start();
    }
    #endregion

    #region public methods
    /// <summary>
    /// Creates the queue with default thread priority.
    /// </summary>
    /// <param name="handler">Handler to execute for items arriving.</param>
    /// <param name="threadName">If this is not null, the created thread is given this name</param>
    public QueueThread(Action<T> handler, string threadName = null)
      : this(handler, ThreadPriority.Normal, threadName)
    {

    }

    /// <summary>
    /// Creates the queue with specific thread priority. Priority can be increased
    /// in case if there are important data needs to be extracted ASAP (like
    /// line scans).
    /// </summary>
    /// <param name="handler">Handler to execute for items arriving.</param>
    /// <param name="threadPriority">Priority of the thread.</param>
    /// <param name="threadName">If this is not null, the created thread is given this name</param>
    public QueueThread(Action<T> handler, ThreadPriority threadPriority, string threadName = null)
    {
      if (handler == null)
      {
        throw new ArgumentNullException("handler");
      }

      this.handler = handler;
      this.threadPriority = threadPriority;
      this.threadName = threadName;
      CloseTimeout = 60000;

      CreateThread(threadPriority);
    }

    /// <summary>
    /// Adds item to the queue.
    /// </summary>
    /// <param name="item">Item to add.</param>
    public int Enqueue(T item)
    {
      Log.DebugFormat("Adding item {0} to the queue.", item);

      int qCount;
      lock (queueLock)
      {
        queue.Enqueue(item);
        qCount = queue.Count;
        if (qCount > maxQueueSize)
        {
          throw new InvalidOperationException(string.Format("Queue length exceeded max limit. Length {0}. Limit {1}", queue.Count, maxQueueSize));
        }
        itemsPresent.Set();
      }

      Log.Debug("Item added.");
      return qCount;
    }

    /// <summary>
    /// Clears the current queue
    /// </summary>
    public void Clear()
    {
      Log.Debug("Clearing the queue");
      int count;
      lock (queueLock)
      {
        count = queue.Count;
        queue.Clear();
        itemsPresent.Reset();
      }

      Log.DebugFormat("Queue cleared. {0} elements deleted.", count);
    }

    /// <summary>
    /// </summary>
    public int CloseTimeout { get; set; }

    /// <summary>
    /// Stops processing of the queue and waits for the current
    /// handler to complete execution.
    /// </summary>
    public void Close()
    {
      Log.InfoFormat("QueueThread {0} is closing queue with {1} lines.", thread.ManagedThreadId, queue.Count);
      threadStopped = true;

      // We should proceed with main cycle execution even if there is no items.
      lock (queueLock)
      {
        itemsPresent.Set();
      }

      Log.Debug("Waiting for queue to close.");
      if (!queueDone.WaitOne(TimeSpan.FromMilliseconds(CloseTimeout)))
      {
        Log.Warn("Failed to shut down queue thread in time.");
      }
      Log.InfoFormat("QueueThread {0} closed with {1} lines.", thread.ManagedThreadId, queue.Count);
    }

    /// <summary>
    /// Restarts the queue ignoring all its content.
    /// </summary>
    public void Restart()
    {
      Log.InfoFormat("QueueThread {0} is restarting queue, clearing {1} entries.", thread.ManagedThreadId, queue.Count);
      Close();

      Log.Debug("Clearing queue.");
      lock (queueLock)
      {
        queue.Clear();
        itemsPresent.Reset();
      }

      Log.Debug("Starting new thread.");
      threadStopped = false;
      queueDone.Reset();
      CreateThread(threadPriority);
    }

    /// <summary>
    /// Returns the number of items in the queue
    /// </summary>
    public int Count()
    {
      return queue.Count;
    }
    #endregion
  }
}