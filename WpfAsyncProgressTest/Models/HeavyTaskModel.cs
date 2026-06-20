
namespace WpfAsyncProgressTest.Models
{

public class HeavyTaskModel
{
    public  int
    doHeavyTask(
        IProgress<int>  progress)
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

}

}
