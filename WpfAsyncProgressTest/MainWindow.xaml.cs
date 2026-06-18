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
        IProgress<int>  progress;
        ProgressSampleViewModel     ViewModel;

        public MainWindow()
        {
            InitializeComponent();
            this.ViewModel = new ProgressSampleViewModel();
            this.progress = new Progress<int>(ProgressChanged);
        }

        public void ProgressChanged(int progressValue)
        {
            this.MyProgress.Value = progressValue;
        }

        public int HeavyTask()
        {
            int total = 0;

            progress.Report(0);
            for ( int i = 1; i <= 20; ++ i ) {
                total += i;
                Thread.Sleep(1000);
                progress.Report(i * 5);
            }
            return ( total );
        }

        private async void OnButtonClickAsync(object sender, RoutedEventArgs e)
        {
            Task<int> task = Task.Run<int>(new Func<int>(HeavyTask));
            int result = await task;
            this.ResultText.Text = $"{result}";
        }

    }

}
