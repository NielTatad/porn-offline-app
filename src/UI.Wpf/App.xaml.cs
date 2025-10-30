using AdultHub.Infrastructure.Configs;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AdultHub.UI.Wpf;

public partial class App : System.Windows.Application
{
    public static IHost HostApp { get; private set; } = default!;

    public App()
    {
        HostApp = Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                services.AddInfrastructure();
                services.AddSingleton<ViewModels.MainViewModel>();
                services.AddSingleton<Views.MainWindow>();
            })
            .ConfigureLogging(b => b.AddDebug())
            .Build();
    }

    protected override async void OnStartup(System.Windows.StartupEventArgs e)
    {
        await HostApp.StartAsync();
        var window = HostApp.Services.GetRequiredService<Views.MainWindow>();
        window.Show();
        base.OnStartup(e);
    }

    protected override async void OnExit(System.Windows.ExitEventArgs e)
    {
        await HostApp.StopAsync();
        HostApp.Dispose();
        base.OnExit(e);
    }
}


