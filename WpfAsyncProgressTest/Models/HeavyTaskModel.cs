
namespace WpfAsyncProgressTest.Models
{

public class HeavyTaskModel
{
    private  readonly   IProgress<int>  m_progress;

    public
    HeavyTaskModel(
        IProgress<int>  progress)
    {
        this.m_progress = progress;
    }

    public  int
    doHeavyTask()
    {
        int total = 0;

        this.m_progress.Report(1);
        for ( int i = 1; i <= 20; ++ i ) {
            total += i;
            Thread.Sleep(1000);
            this.m_progress.Report(i * 5);
        }

        return ( total );
    }

}

}
