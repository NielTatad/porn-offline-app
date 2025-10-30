using AdultHub.Application.UseCases.PlayVideo;
using AdultHub.Application.UseCases.StopVideo;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Linq;
using System.Collections.Generic;

namespace UI.Avalonia.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private readonly PlayVideoCommandHandler _playHandler;
    private readonly StopVideoCommandHandler _stopHandler;

    [ObservableProperty]
    private string _videoPath = string.Empty;

    // Filters state
    [ObservableProperty]
    private int _ethnicityIndex = -1;

    [ObservableProperty]
    private int _hairColorIndex = -1;

    [ObservableProperty]
    private int _breastSizeIndex = -1;

    [ObservableProperty]
    private int _activeDecadeIndex = -1;

    [ObservableProperty]
    private string? _selectedEthnicity;

    [ObservableProperty]
    private string? _selectedHairColor;

    [ObservableProperty]
    private string? _selectedBreastSize;

    [ObservableProperty]
    private string? _selectedActiveDecade;

    [ObservableProperty]
    private bool _hasTattoo;

    [ObservableProperty]
    private bool _hasPiercing;

    [ObservableProperty]
    private string? _selectedPiercing;

    [ObservableProperty]
    private string? _selectedTattoo;

    [ObservableProperty]
    private DateOnly? _selectedBirthday;

    public IRelayCommand PlayCommand { get; }
    public IRelayCommand StopCommand { get; }
    public IRelayCommand ClearFiltersCommand { get; }

    [ObservableProperty]
    private string _searchText = string.Empty;

    public ObservableCollection<string> SamplePerformers { get; } = new(
        new[]
        {
            "A.J. Applegate","Cindy Starfall","Tera Patrick","Jenna Jameson",
            "Abella Danger","Addison Rose","Adria Rae","Aidra Fox"
        });

    // Sidebar thumbnail placeholders
    public ObservableCollection<string> FavoriteThumbnails { get; } = new(
        new[] { "t1","t2","t3","t4","t5","t6" });
    public ObservableCollection<string> LastWatchedThumbnails { get; } = new(
        new[] { "lw1","lw2","lw3","lw4","lw5","lw6","lw7" });

    public IEnumerable<string> FavoriteTop => FavoriteThumbnails.Take(5);
    public IEnumerable<string> LastWatchedTop => LastWatchedThumbnails.Take(5);

    // Responsive card grid
    [ObservableProperty]
    private int _cardColumns = 5;

    public MainViewModel(PlayVideoCommandHandler playHandler, StopVideoCommandHandler stopHandler)
    {
        _playHandler = playHandler;
        _stopHandler = stopHandler;

        PlayCommand = new AsyncRelayCommand(PlayAsync);
        StopCommand = new AsyncRelayCommand(StopAsync);
        ClearFiltersCommand = new RelayCommand(ClearFilters);
    }

    private Task PlayAsync() => _playHandler.HandleAsync(new PlayVideoCommand(VideoPath));
    private Task StopAsync() => _stopHandler.HandleAsync(new StopVideoCommand());

    private void ClearFilters()
    {
        // reset indices (clears dropdown selection)
        EthnicityIndex = -1;
        HairColorIndex = -1;
        BreastSizeIndex = -1;
        ActiveDecadeIndex = -1;
        // reset backing values (if any binding relies on them)
        SelectedEthnicity = null;
        SelectedHairColor = null;
        SelectedBreastSize = null;
        SelectedActiveDecade = null;
        HasTattoo = false;
        HasPiercing = false;
        SelectedPiercing = null;
        SelectedTattoo = null;
        SelectedBirthday = null;
    }
}


