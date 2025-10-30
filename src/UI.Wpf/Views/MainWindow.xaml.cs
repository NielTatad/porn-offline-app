using AdultHub.UI.Wpf.ViewModels;

namespace AdultHub.UI.Wpf.Views;

public partial class MainWindow : System.Windows.Window
{
    public MainWindow(MainViewModel vm)
    {
        InitializeComponent();
        DataContext = vm;
    }
}


