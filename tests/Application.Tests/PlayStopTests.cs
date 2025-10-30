using AdultHub.Application.Common.Interfaces;
using AdultHub.Application.UseCases.PlayVideo;
using AdultHub.Application.UseCases.StopVideo;
using Moq;
using Xunit;

namespace AdultHub.Tests.Application;

public class PlayStopTests
{
    [Fact]
    public async Task Play_Then_Stop_Invokes_Service()
    {
        var player = new Mock<IVideoPlayerService>();
        var play = new PlayVideoCommandHandler(player.Object);
        var stop = new StopVideoCommandHandler(player.Object);

        await play.HandleAsync(new PlayVideoCommand("c:/sample.mp4"));
        await stop.HandleAsync(new StopVideoCommand());

        player.Verify(p => p.PlayAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Once);
        player.Verify(p => p.StopAsync(It.IsAny<CancellationToken>()), Times.Once);
    }
}


