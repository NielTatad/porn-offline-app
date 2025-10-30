using AdultHub.Application.Common.Interfaces;
using AdultHub.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AdultHub.Infrastructure.Configs;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IVideoPlayerService, VideoPlayerService>();
        return services;
    }
}


