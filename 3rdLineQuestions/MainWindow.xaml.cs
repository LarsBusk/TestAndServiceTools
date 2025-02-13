using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ThirdLineQs;

namespace _3rdLineQuestions
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DataBaseHelper helper;
        public MainWindow()
        {
            InitializeComponent();
            helper = new DataBaseHelper();
        }

        private void AddShortQuestion(object sender, RoutedEventArgs e)
        {
            var kind = (string)((Button)sender).Content;
            AddNewQuestion(GetKind(kind), 1);
        }

        private void AddLongQuestion(object sender, RoutedEventArgs e)
        {
            var kind = (string)((Button)sender).Content;
            AddNewQuestion(GetKind(kind), 2);
        }

        private void AddNewQuestion(short kind, short duration)
        {
            helper.AddQuestion(kind, duration);
        }

        private short GetKind(string kind)
        {
            switch (kind)
            {
                case "Software":
                    return 1;
                case "Hardware":
                    return 2;
                case "General":
                    return 3;
                case "Support":
                    return 4;
                default:
                    return 5;
            }
        }
    }
}