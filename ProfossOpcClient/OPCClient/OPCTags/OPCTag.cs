using System;

namespace OPCClient.OPCTags
{
  /// <summary>
  /// Interface that represents an OPCTag
  /// </summary>
  public interface IOPCTag
  {
    //Name without serverPrefix
    string ShortName { get; set; }

    //Name with serverPrefix
    string FullName { get; set; }
    Type Type { get; }
    string ToString();
    object ObjectValue { get; set; }
  }

  /// <summary>
  /// generic implementation of an OPCTag
  /// </summary>
  public class OPCTag<T> : IOPCTag
  {
    /// <summary>
    ///     constructor, assure that value is initialized with a reasonable value
    /// </summary>
    /// <param name="serverPrefix"></param>
    /// <param name="shortName"></param>
    public OPCTag(string serverPrefix, string shortName)
    {
      ShortName = shortName;
      FullName = serverPrefix + shortName;

      if (typeof(T) == typeof(string))
      {
        Value = (T) (object) string.Empty;
      }

      if (typeof(T) == typeof(string[]))
      {
        Value = (T) (object) new string[0];
      }

      if (typeof(T) == typeof(int[]))
      {
        Value = (T) (object) new int[0];
      }

    }

    public string ShortName { get; set; }
    public string FullName { get; set; }

    public Type Type
    {
      get { return typeof(T); }
    }

    //Native type - not an object
    public T Value { get; private set; }

    /// <summary>
    ///     returns the value of value
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
      if ((typeof(T) == typeof(string[])))
      {
        return String.Join(",", (string[]) (object) Value);
      }

      if ((typeof(T) == typeof(int[])))
      {
        return String.Join(",", (int[]) (object) Value);
      }

      return Value.ToString();
    }

    ///     Sets a value to an OPCTag, keep initial value, if objectValue is null
    public object ObjectValue
    {
      get { return Value; }
      set
      {
        if (value != null)
          Value = (T) value;
      }
    }
  }
}