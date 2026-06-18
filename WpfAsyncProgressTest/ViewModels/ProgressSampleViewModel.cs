
namespace WpfAsyncProgressTest
{

public class ProgressSampleViewModel
{
    private readonly    IProgress<int>  m_progress;

    public ProgressSampleViewModel()
    {
        this.m_progress = new Progress<int>(ProgressChanged);
    }

    public void ProgressChanged(int progressValue)
    {
    }

}

}
