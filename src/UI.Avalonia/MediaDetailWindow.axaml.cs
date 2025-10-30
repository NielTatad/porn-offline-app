using Avalonia.Controls;
using UI.Avalonia.ViewModels;

namespace UI.Avalonia;

public partial class MediaDetailWindow : Window
{
    public MediaDetailWindow(MediaDetailWindowViewModel vm)
    {
        InitializeComponent();
        DataContext = vm;
    }
}


