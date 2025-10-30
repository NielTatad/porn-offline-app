using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using UI.Avalonia.Models;

namespace UI.Avalonia.ViewModels;

public partial class MediaWindowViewModel : ObservableObject
{
    public ObservableCollection<MediaItemVm> Media { get; } = new(
        new[]
        {
            new MediaItemVm{ Title = "Prime Anal", Duration = "01:20:15", IsFavorite=true},
            new MediaItemVm{ Title = "Glamorous 4", Duration = "00:42:10"},
            new MediaItemVm{ Title = "Naughty Nannies", Duration = "01:05:33"},
            new MediaItemVm{ Title = "Evil Angel Show", Duration = "00:55:08"},
            new MediaItemVm{ Title = "TeamSkeet Special", Duration = "00:39:50"},
        });
}


