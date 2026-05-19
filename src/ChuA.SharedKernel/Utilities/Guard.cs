namespace ChuA.SharedKernel.Utilities;

/// <summary>
/// Provides guard clauses for validating method arguments.
/// </summary>
public static class Guard
{
    /// <summary>
    /// Throws when the value is null.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="value">The value to inspect.</param>
    /// <param name="parameterName">The parameter name.</param>
    /// <returns>The non-null value.</returns>
    public static T AgainstNull<T>(T? value, string parameterName)
        where T : class
    {
        ArgumentNullException.ThrowIfNull(value, parameterName);
        return value;
    }

    /// <summary>
    /// Throws when the value is null, empty, or whitespace.
    /// </summary>
    /// <param name="value">The value to inspect.</param>
    /// <param name="parameterName">The parameter name.</param>
    /// <returns>The non-empty value.</returns>
    public static string AgainstNullOrWhiteSpace(string? value, string parameterName)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Value cannot be null, empty, or whitespace.", parameterName);
        }

        return value;
    }

    /// <summary>
    /// Throws when the value is negative or zero.
    /// </summary>
    /// <param name="value">The value to inspect.</param>
    /// <param name="parameterName">The parameter name.</param>
    /// <returns>The positive value.</returns>
    public static int AgainstNegativeOrZero(int value, string parameterName)
    {
        if (value <= 0)
        {
            throw new ArgumentOutOfRangeException(parameterName, value, "Value must be greater than zero.");
        }

        return value;
    }
}
