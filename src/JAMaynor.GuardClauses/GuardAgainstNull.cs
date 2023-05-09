using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace JAMaynor;


public static class GuardAgainstNull
{
    public static T Null<T>(this IGuardClause guardClause, T input, string? message = null, [CallerArgumentExpression("input")] string? parameterName = null)
    {
        if (input is null)
        {
            throw new ArgumentNullException(message ?? $"Required input {parameterName} was null.");
        }
        return input;
    }

    public static string NullOrEmpty(this IGuardClause guardClause, string? input, string? message = null, [CallerArgumentExpression("input")] string? parameterName = null)
    {
        Guard.Against.Null(input, message, parameterName);
        if (input == string.Empty)
        {
            throw new ArgumentException(message ?? $"Required input {parameterName} was empty.", parameterName);
        }

        return input!;
    }

    public static Guid NullOrEmpty(this IGuardClause guardClause, Guid? input, string? message = null, [CallerArgumentExpression("input")] string? parameterName = null)
    {
        Guard.Against.Null(input, message, parameterName);
        if (input == Guid.Empty)
        {
            throw new ArgumentException(message ?? $"Required input {parameterName} was empty.", parameterName);
        }

        return input!.Value;
    }

    public static IEnumerable<T> NullOrEmpty<T>(this IGuardClause guardClause, IEnumerable<T>? input, string? message = null, [CallerArgumentExpression("input")] string? parameterName = null)
    {
        Guard.Against.Null(input, message, parameterName);

        if (!input!.Any())
        {
            throw new ArgumentException(message ?? $"Required input {parameterName} was empty.", parameterName);
        }

        return input!;
    }

    public static string NullOrWhitespace(this IGuardClause guardClause, string? input, string? message = null, [CallerArgumentExpression("input")] string? parameterName = null)
    {
        Guard.Against.NullOrEmpty(input, message, parameterName);
        if (string.IsNullOrWhiteSpace(input))
        {
            throw new ArgumentException(message ?? $"Required input {parameterName} was empty.", parameterName);
        }
        return input!;
    }

    public static T Default<T>(this IGuardClause guardClause, T input, string? message = null, [CallerArgumentExpression("input")] string? parameterName = null)
    {
        if (EqualityComparer<T>.Default.Equals(input, default!) || input is null)
        {
            throw new ArgumentException(message ?? $"Parameter [{parameterName}] is default value for type {typeof(T).Name}", parameterName);
        }

        return input;
    }
}
