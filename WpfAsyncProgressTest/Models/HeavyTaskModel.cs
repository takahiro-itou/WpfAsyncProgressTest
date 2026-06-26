
namespace WpfAsyncProgressTest.Models
{

public class HeavyTaskModel
{
    private  readonly   IProgress<int>  m_progress;

    private  int        m_curVal;
    private  bool       m_paused;

    public
    HeavyTaskModel(
        IProgress<int>  progress)
    {
        this.m_progress = progress;
        this.m_curVal   = 0;
    }

    public  int
    doHeavyTask()
    {
        int total = 0;

        this.m_progress.Report(1);
        for ( int i = 1; i <= 20; ++ i ) {
            while ( this.m_paused ) {
                Thread.Sleep(500);
            }

            total += i;
            Thread.Sleep(1000);
            this.m_curVal = total;
            this.m_progress.Report(i * 5);
        }

        return ( total );
    }

    public  int
    CurrentValue {
        get {
            return  this.m_curVal;
       }
    }

    public  bool
    IsPaused {
        get {
            return  this.m_paused;
        }
        set {
            this.m_paused = value;
        }
    }

}

}
