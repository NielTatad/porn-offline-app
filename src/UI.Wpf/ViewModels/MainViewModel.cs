using AdultHub.Application.UseCases.PlayVideo;
using AdultHub.Application.UseCases.StopVideo;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AdultHub.UI.Wpf.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private readonly PlayVideoCommandHandler _playHandler;
    private readonly StopVideoCommandHandler _stopHandler;

    [ObservableProperty]
    private string _videoPath = string.Empty;

    public IRelayCommand PlayCommand { get; }
    public IRelayCommand StopCommand { get; }

    public MainViewModel(PlayVideoCommandHandler playHandler, StopVideoCommandHandler stopHandler)
    {
        _playHandler = playHandler;
        _stopHandler = stopHandler;

        PlayCommand = new AsyncRelayCommand(PlayAsync);
        StopCommand = new AsyncRelayCommand(StopAsync);
    }

    private Task PlayAsync()
        => _playHandler.HandleAsync(new PlayVideoCommand(VideoPath));

    private Task StopAsync()
        => _stopHandler.HandleAsync(new StopVideoCommand());
}


