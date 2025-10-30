using AdultHub.Application.Common.Interfaces;

namespace AdultHub.Application.UseCases.StopVideo;

public sealed class StopVideoCommand { }

public sealed class StopVideoCommandHandler
{
    private readonly IVideoPlayerService _videoPlayerService;
    public StopVideoCommandHandler(IVideoPlayerService videoPlayerService)
    {
        _videoPlayerService = videoPlayerService;
    }

    public Task HandleAsync(StopVideoCommand _, CancellationToken cancellationToken = default)
        => _videoPlayerService.StopAsync(cancellationToken);
}


