using Domain.Base;

namespace Domain.Entities;

public class Movie : BaseEntity
{
    public string? ImdbId { get; set; }
    public required string Title { get; set; }
    public DateTime Date { get; set; }
    public string? Description { get; set; }
    public virtual ICollection<Actor> Actors { get; set; } = default!;
}
