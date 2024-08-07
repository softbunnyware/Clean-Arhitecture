using Domain.Base;

namespace Domain.Entities;

public class Actor : BaseEntity
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public virtual ICollection<Movie> Movies { get; set; } = default!;

}
