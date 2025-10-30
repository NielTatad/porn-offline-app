using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using AdultHub.Infrastructure.Configs;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AdultHub.Application.UseCases.PlayVideo;
using AdultHub.Application.UseCases.StopVideo;

namespace UI.Avalonia;

public partial class App : Application
{
    public static IHost HostApp { get; private set; } = default!;
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        HostApp = Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                services.AddInfrastructure();
                services.AddSingleton<PlayVideoCommandHandler>();
                services.AddSingleton<StopVideoCommandHandler>();
                services.AddSingleton<ViewModels.MainViewModel>();
                services.AddSingleton<ViewModels.MediaWindowViewModel>();
                services.AddSingleton<ViewModels.PerformerDetailWindowViewModel>();
                services.AddSingleton<ViewModels.MediaDetailWindowViewModel>();
                services.AddSingleton<MainWindow>();
                services.AddSingleton<MediaWindow>();
                services.AddSingleton<PerformerDetailWindow>();
                services.AddSingleton<MediaDetailWindow>();
            })
            .Build();

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            desktop.MainWindow = HostApp.Services.GetRequiredService<MainWindow>();

        base.OnFrameworkInitializationCompleted();
    }
}