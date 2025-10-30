namespace UI.Avalonia.Models;

public sealed class MediaItemVm
{
    public string Title { get; init; } = string.Empty;
    public string Duration { get; init; } = "00:00";
    public string? ThumbnailUrl { get; init; }
    public bool IsFavorite { get; init; }
}


