using Avalonia.Controls;
using UI.Avalonia.ViewModels;

namespace UI.Avalonia;

public partial class PerformerDetailWindow : Window
{
    public PerformerDetailWindow(PerformerDetailWindowViewModel vm)
    {
        InitializeComponent();
        DataContext = vm;
    }
}


