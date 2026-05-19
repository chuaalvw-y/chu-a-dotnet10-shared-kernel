namespace ChuA.SharedKernel.Models;

/// <summary>
/// Provides structural equality for value objects.
/// </summary>
public abstract class ValueObject
{
    /// <summary>
    /// Gets the atomic values that participate in equality.
    /// </summary>
    /// <returns>The equality components.</returns>
    protected abstract IEnumerable<object?> GetEqualityComponents();

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        if (obj is null || obj.GetType() != GetType())
        {
            return false;
        }

        return GetEqualityComponents().SequenceEqual(((ValueObject)obj).GetEqualityComponents());
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        var hash = new HashCode();

        foreach (var component in GetEqualityComponents())
        {
            hash.Add(component);
        }

        return hash.ToHashCode();
    }
}
