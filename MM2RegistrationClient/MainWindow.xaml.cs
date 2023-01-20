using System.Windows;

namespace RegistrationClient
{
    /// <summary>
    /// Test client that uses OPC to communicate with Nova to provide registration values into Nova.
    /// Covers the Danish Crown with writing to 2 opc tags (Registration=2).
    /// Covers the case of using a bar code reader to provide registration values (Registration=3)
    /// 
    /// Requires:
    /// 1. OpcServerConfiguration.xml must be set up to use some kind of Registration
    /// 2. If you want to test Nova must be setup 
    /// </summary>
    public partial class MainWindow
  {

    private readonly MainWindowViewModel viewModel;

    public MainWindow()
    {
      InitializeComponent();
      viewModel = new MainWindowViewModel();
      this.DataContext = viewModel;
    }

    private void ConnectToServer(object sender, RoutedEventArgs e)
    {
      if (!viewModel.IsConnected)
      {
        viewModel.ConnectToServer();
      }
      else
      {
        viewModel.DisConnect();
      }
    }

    private void SetValues(object sender, RoutedEventArgs e)
    {
      viewModel.InsertValues();
    }


    private void StartStopMeasuring(object sender, RoutedEventArgs e)
    {
      viewModel.StartStopMeasuring();
    }
  }
}