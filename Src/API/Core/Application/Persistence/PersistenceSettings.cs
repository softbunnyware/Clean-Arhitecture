using System.ComponentModel.DataAnnotations;

namespace Application.Persistence;

public class PersistenceSettings
{
    public required string DatabaseProvider { get; set; }
    public required string ConnectionString { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (string.IsNullOrEmpty(DatabaseProvider))
        {
            yield return new ValidationResult($"{nameof(PersistenceSettings)}.{nameof(DatabaseProvider)} is not configured", new[] { nameof(DatabaseProvider) });
        }

        if (string.IsNullOrEmpty(ConnectionString))
        {
            yield return new ValidationResult($"{nameof(PersistenceSettings)}.{nameof(ConnectionString)} is not configured", new[] { nameof(ConnectionString) });
        }
    }
}
