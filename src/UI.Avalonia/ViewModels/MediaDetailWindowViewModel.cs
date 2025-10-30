using CommunityToolkit.Mvvm.ComponentModel;

namespace UI.Avalonia.ViewModels;

public partial class MediaDetailWindowViewModel : ObservableObject
{
    [ObservableProperty]
    private string _title = "Sample Movie";

    public string Country => "USA";
    public string Language => "English";
    public string ReleaseDate => "2025-01-01";
    public string Genre => "Action";
    public string Synopsis => "Synopsis placeholder...";
}


