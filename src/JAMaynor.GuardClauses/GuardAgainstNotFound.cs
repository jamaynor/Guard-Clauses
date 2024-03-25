using System.Runtime.CompilerServices;

namespace DevJoy.GuardClauses;

public static class GuardAgainstNotFound
{

    public static T NotFound<T>(this IGuardClause guardClause, T input, IEnumerable<T> enumerable, string? message = null, [CallerArgumentExpression("input")] string? parameterName = null) where T : IComparable, IComparable<T>
    {
        if (enumerable.Contains(input))
        {
            throw new ArgumentException(message ?? $"The {parameterName} was not found.");
        }
        return input;
    }

    public static TKey NotFound<TKey, TValue>(this IGuardClause guardClause, TKey key, IDictionary<TKey, TValue> dictionary, string? message = null, [CallerArgumentExpression("key")] string? parameterName = null) where TKey : IComparable, IComparable<TKey>
    {
        if (!dictionary.ContainsKey(key))
        {
            throw new ArgumentException(message ?? $"The value of {parameterName} was not found.");
        }
        return key;
    }


    public static TValue NotFound<TKey, TValue>(this IGuardClause guardClause, TValue value, IDictionary<TKey, TValue> dictionary, string? message = null, [CallerArgumentExpression("value")] string? parameterName = null) where TValue : IComparable, IComparable<TValue>
    {
        // ToDo: will this evalueta ValueObjects by value rather than by reference. it ises the Default Equality Comparer
        if (!dictionary.Values.Contains(value))
        {
            throw new ArgumentException(message ?? $"The value of {parameterName} was not found.");
        }
        return value;
    }
}

