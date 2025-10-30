namespace AdultHub.Domain.Entities;

public sealed class MediaItem
{
    public Guid Id { get; }
    public string Title { get; }
    public string FilePath { get; }
    public DateTime AddedAtUtc { get; }

    public MediaItem(Guid id, string title, string filePath, DateTime? addedAtUtc = null)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title is required", nameof(title));
        if (string.IsNullOrWhiteSpace(filePath))
            throw new ArgumentException("File path is required", nameof(filePath));

        Id = id == Guid.Empty ? Guid.NewGuid() : id;
        Title = title.Trim();
        FilePath = filePath.Trim();
        AddedAtUtc = addedAtUtc ?? DateTime.UtcNow;
    }
}


