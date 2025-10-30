using Avalonia.Controls;
using UI.Avalonia.ViewModels;

namespace UI.Avalonia;

public partial class MediaWindow : Window
{
    public MediaWindow(MediaWindowViewModel vm)
    {
        InitializeComponent();
        DataContext = vm;
    }
}


