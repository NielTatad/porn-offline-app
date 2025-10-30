namespace AdultHub.Domain.Entities;

public sealed class Performer
{
    public Guid Id { get; }
    public string StageName { get; }
    public string? Alias { get; }
    public DateOnly? BirthDate { get; }

    public Performer(Guid id, string stageName, string? alias = null, DateOnly? birthDate = null)
    {
        if (string.IsNullOrWhiteSpace(stageName))
            throw new ArgumentException("Stage name is required", nameof(stageName));

        Id = id == Guid.Empty ? Guid.NewGuid() : id;
        StageName = stageName.Trim();
        Alias = string.IsNullOrWhiteSpace(alias) ? null : alias.Trim();
        BirthDate = birthDate;
    }
}


