
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

}

}
