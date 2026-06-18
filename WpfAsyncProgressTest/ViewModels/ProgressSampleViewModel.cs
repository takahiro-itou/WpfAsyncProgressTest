
using System.Windows.Input;

namespace WpfAsyncProgressTest
{

public class ProgressSampleViewModel
{
    private readonly    IProgress<int>  m_progress;
    private             int             m_progressValue = 0;

    public ProgressSampleViewModel()
    {
        this.m_progress = new Progress<int>(ProgressChanged);
    }

    public void ProgressChanged(int progressValue)
    {
        this.m_progressValue = progressValue;
    }

    public  int  ProgressValue
    {
        get { return  this.m_progressValue; }
        set { this.m_progressValue = value; }
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

}

}
