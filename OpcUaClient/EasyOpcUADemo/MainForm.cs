// $Header: $ 
// Copyright (c) CODE Consulting and Development, s.r.o., Plzen. All rights reserved.
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;
using EasyOpcUADemo.Properties;
using JetBrains.Annotations;
using OpcLabs.EasyOpc.UA;
using OpcLabs.EasyOpc.UA.OperationModel;

[assembly:CLSCompliant(true)]

namespace EasyOpcUADemo
{
  public partial class MainForm : Form
  {
    private OpcUaClient opcUaClient;
    private bool _isSubscribed /* = false*/;
    private QueueThread<List<OpcNodeResult>> resultWriterThread;

    public MainForm()
    {
      InitializeComponent();
      resultWriterThread = new QueueThread<List<OpcNodeResult>>(CsvWriter.WriteToFile);
    }

    private void readButton_Click(object sender, EventArgs e)
    {
      UAAttributeData attributeData = null;
      Exception exception = null;
      try
      {
        attributeData = opcUaClient.ReadSingleValue(nodeIdTextBox.Text);
      }
      catch (UAException ex)
      {
        exception = ex;
      }

      DisplayAttributeData(attributeData);
      DisplayException(exception);
    }

    private void DisplayAttributeData(UAAttributeData attributeData)
    {
      if (attributeData == null)
      {
        valueTextBox.Text = "";
        statusTextBox.Text = "";
        sourceTimestampTextBox.Text = "";
        serverTimestampTextBox.Text = "";
      }
      else
      {
        valueTextBox.Text = attributeData.DisplayValue();
        statusTextBox.Text = attributeData.StatusCode.ToString();
        sourceTimestampTextBox.Text = attributeData.SourceTimestamp.ToString(CultureInfo.CurrentCulture);
        serverTimestampTextBox.Text = attributeData.ServerTimestamp.ToString(CultureInfo.CurrentCulture);
      }
    }

    private void DisplayException(Exception exception)
    {
      exceptionTextBox.Text = exception == null ? "" : exception.GetBaseException().Message;
    }

    public bool IsSubscribed
    {
      get { return _isSubscribed; }
      set
      {
        _isSubscribed = value;
        subscribeMonitoredItemButton.Enabled = !_isSubscribed;
      }
    }

    private void subscribeButton_Click(object sender, EventArgs e)
    {
      this.opcUaClient.SubscribeSingleNode(nodeIdTextBox.Text);
      IsSubscribed = true;
    }


    private void closeButton_Click(object sender, EventArgs e)
    {
      opcUaClient.Unsubscribe();
      Close();
    }

    private void writeValueButton_Click(object sender, EventArgs e)
    {
      Exception exception = null;
      try
      {
        opcUaClient.WriteItem(nodeIdTextBox.Text, valueToWriteTextBox.Text);
      }
      catch (UAException ex)
      {
        exception = ex;
      }

      DisplayException(exception);
    }

    private void connectButton_Click(object sender, EventArgs e)
    {
      opcUaClient = new OpcUaClient(serverUriTextBox.Text, groupTextbox.Text);
      opcUaClient.RaiseDataChangeEvent += OpcUaClient_RaiseDataChangeEvent;
    }

    private void OpcUaClient_RaiseDataChangeEvent(object sender, OpcClientEventArgs e)
    {
      var results = opcUaClient.ReadAll();

      resultWriterThread.Enqueue(results);
      //CsvWriter.WriteToFile(results);
    }

    private void subscribeResultsButton_Click(object sender, EventArgs e)
    {
      opcUaClient.SubscribeSampleCounter();
    }

    private void unsubscribeButton_Click(object sender, EventArgs e)
    {
      opcUaClient.Unsubscribe();
    }
  }
}
