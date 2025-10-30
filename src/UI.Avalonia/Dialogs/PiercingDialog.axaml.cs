using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.VisualTree;
using System.Linq;

namespace UI.Avalonia.Dialogs;

public partial class PiercingDialog : Window
{
    public string? Selected { get; private set; }

    public PiercingDialog()
    {
        InitializeComponent();
    }

    private void OnOk(object? sender, RoutedEventArgs e)
    {
        var selected = this.GetVisualDescendants().OfType<RadioButton>()
            .FirstOrDefault(r => r.IsChecked == true);
        Selected = selected?.Tag?.ToString();
        Close(Selected);
    }
}


