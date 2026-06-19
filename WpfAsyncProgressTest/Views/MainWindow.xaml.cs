using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAsyncProgressTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly ProgressSampleViewModel     m_viewModel;

        public MainWindow()
        {
            InitializeComponent();
            this.m_viewModel = new ProgressSampleViewModel();
            this.DataContext = this.m_viewModel;
        }

        private async void OnButtonClickAsync(object sender, RoutedEventArgs e)
        {
            Task<int> task = Task.Run<int>(new Func<int>(m_viewModel.HeavyTask));
            int result = await task;
            this.ResultText.Text = $"{result}";
        }

    }

}
