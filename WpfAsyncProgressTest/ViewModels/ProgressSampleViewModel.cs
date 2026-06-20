
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

using WpfAsyncProgressTest.Commands;
using WpfAsyncProgressTest.Models;

namespace WpfAsyncProgressTest
{

public class ProgressSampleViewModel : INotifyPropertyChanged
{
    private readonly    IProgress<int>  m_progress;
    private             int             m_progressValue = 0;

    public ProgressSampleViewModel()
    {
        this.m_progress = new Progress<int>(ProgressChanged);
    }

    public void ProgressChanged(int progressValue)
    {
        this.ProgressValue = progressValue;
    }

    public  int  ProgressValue
    {
        get {
                return  this.m_progressValue;
            }
        set {
            this.m_progressValue = value;
            OnPropertyChanged(nameof(ProgressValue));
        }
    }

    public  int  HeavyTask()
    {
        int total = 0;

        this.m_progress.Report(0);
        for ( int i = 1; i <= 20; ++ i ) {
            total += i;
            Thread.Sleep(1000);
            this.m_progress.Report(i * 5);
        }
        return ( total );
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged(
        [CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(
            this, new PropertyChangedEventArgs(propertyName));
    }

}

}
