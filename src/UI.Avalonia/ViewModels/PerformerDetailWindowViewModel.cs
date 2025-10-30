using CommunityToolkit.Mvvm.ComponentModel;

namespace UI.Avalonia.ViewModels;

public partial class PerformerDetailWindowViewModel : ObservableObject
{
    [ObservableProperty]
    private string _name = "Sample Performer";

    [ObservableProperty]
    private int _selectedTabIndex = 0;

    public string BioText => "Birthday: 01/01/1990\nHeight: 170 cm\n...";
    public string BackgroundText => "Early life and career lorem ipsum...";
    public string AwardsText => "Award list lorem ipsum...";
}


