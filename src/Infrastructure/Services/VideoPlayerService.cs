using AdultHub.Application.Common.Interfaces;
using Microsoft.Extensions.Logging;

namespace AdultHub.Infrastructure.Services;

// Minimal stub implementation. Replace with LibVLCSharp or Windows Media APIs later.
public sealed class VideoPlayerService : IVideoPlayerService
{
    private readonly ILogger<VideoPlayerService> _logger;
    public bool IsPlaying { get; private set; }

    public VideoPlayerService(ILogger<VideoPlayerService> logger)
    {
        _logger = logger;
    }

    public Task PlayAsync(string filePath, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(filePath))
            throw new ArgumentException("File path is required", nameof(filePath));

        _logger.LogInformation("Playing video: {file}", filePath);
        IsPlaying = true;
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken = default)
    {
        if (!IsPlaying)
        {
            _logger.LogDebug("Stop requested but player is idle");
            return Task.CompletedTask;
        }

        _logger.LogInformation("Stopping video");
        IsPlaying = false;
        return Task.CompletedTask;
    }
}


