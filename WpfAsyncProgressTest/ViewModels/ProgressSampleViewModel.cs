
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

using WpfAsyncProgressTest.Commands;
using WpfAsyncProgressTest.Models;

namespace WpfAsyncProgressTest
{

public class ProgressSampleViewModel : INotifyPropertyChanged
{
    private  readonly   IProgress<int>  m_progress;
    private  readonly   SimpleCommand   m_heavyCommand;
    private  readonly   HeavyTaskModel  m_model;

    private  int    m_progressValue = 0;
    private  int    m_resultValue   = 0;

    public ProgressSampleViewModel()
    {
        this.m_progress = new Progress<int>(ProgressChanged);

        this.m_model    = new HeavyTaskModel(this.m_progress);
        this.m_heavyCommand = new SimpleCommand(_ => HeavyTask());
    }

    public ICommand HeavyTaskCommand => m_heavyCommand;

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

    public  int  ResultValue {
        get {
            return  this.m_resultValue;
        }
        set {
            this.m_resultValue  = value;
            OnPropertyChanged(nameof(ResultValue));
        }
    }

    public  async  void  HeavyTask()
    {
        Task<int> task = Task.Run<int>(new Func<int>(
            m_model.doHeavyTask));
        int result = await task;
        this.ResultValue = result;
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
