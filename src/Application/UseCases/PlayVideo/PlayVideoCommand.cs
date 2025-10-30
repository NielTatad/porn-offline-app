using AdultHub.Application.Common.Interfaces;

namespace AdultHub.Application.UseCases.PlayVideo;

public sealed class PlayVideoCommand
{
    public string FilePath { get; }
    public PlayVideoCommand(string filePath)
    {
        FilePath = filePath ?? string.Empty;
    }
}

public sealed class PlayVideoCommandHandler
{
    private readonly IVideoPlayerService _videoPlayerService;
    public PlayVideoCommandHandler(IVideoPlayerService videoPlayerService)
    {
        _videoPlayerService = videoPlayerService;
    }

    public Task HandleAsync(PlayVideoCommand command, CancellationToken cancellationToken = default)
        => _videoPlayerService.PlayAsync(command.FilePath, cancellationToken);
}


