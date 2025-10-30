using Avalonia.Controls;
using UI.Avalonia.ViewModels;
using UI.Avalonia.Dialogs;
using Avalonia.Interactivity;
using System;
using Microsoft.Extensions.DependencyInjection;
using Avalonia.Input;

namespace UI.Avalonia;

public partial class MainWindow : Window
{
    public MainWindow(MainViewModel vm)
    {
        InitializeComponent();
        DataContext = vm;
        this.PropertyChanged += (_, e) =>
        {
            if (e.Property == BoundsProperty) UpdateColumns();
        };
        UpdateColumns();
    }

    private async void OnPiercingClick(object? sender, RoutedEventArgs e)
    {
        var dlg = new PiercingDialog();
        var result = await dlg.ShowDialog<string>(this);
        if (DataContext is MainViewModel vm)
        {
            vm.SelectedPiercing = result;
            vm.HasPiercing = !string.IsNullOrWhiteSpace(vm.SelectedPiercing);
        }
    }

    private async void OnTattooClick(object? sender, RoutedEventArgs e)
    {
        var dlg = new TattooDialog();
        var result = await dlg.ShowDialog<string>(this);
        if (DataContext is MainViewModel vm)
        {
            vm.SelectedTattoo = result;
            vm.HasTattoo = !string.IsNullOrWhiteSpace(vm.SelectedTattoo);
        }
    }

    private void UpdateColumns()
    {
        if (DataContext is not MainViewModel vm) return;
        var contentWidth = ContentArea?.Bounds.Width ?? this.Bounds.Width - 600; // approx when not measured
        // Each card cell ~ 220 px incl. margins
        var cols = Math.Max(2, Math.Min(8, (int)Math.Floor(contentWidth / 220.0)));
        vm.CardColumns = cols;
    }

    private async void OnBirthdayClick(object? sender, RoutedEventArgs e)
    {
        var dlg = new BirthdayDialog();
        var result = await dlg.ShowDialog<DateTime?>(this);
        if (DataContext is MainViewModel vm)
        {
            vm.SelectedBirthday = result.HasValue ? DateOnly.FromDateTime(result.Value) : null;
        }
    }

    private void OnPerformerClick(object? sender, PointerPressedEventArgs e)
    {
        var provider = App.HostApp.Services;
        var wnd = provider.GetRequiredService<PerformerDetailWindow>();
        wnd.Show();
    }

    private void OnOpenMedia(object? sender, RoutedEventArgs e)
    {
        var provider = App.HostApp.Services;
        var wnd = provider.GetRequiredService<MediaWindow>();
        wnd.Show();
    }
}