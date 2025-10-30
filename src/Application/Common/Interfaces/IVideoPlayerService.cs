namespace AdultHub.Application.Common.Interfaces;

public interface IVideoPlayerService
{
    Task PlayAsync(string filePath, CancellationToken cancellationToken = default);
    Task StopAsync(CancellationToken cancellationToken = default);
    bool IsPlaying { get; }
}


