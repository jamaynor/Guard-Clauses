using System.Runtime.CompilerServices;

namespace DevJoy.GuardClauses;

public static class GuardAgainstTrue
{

    public static bool True(this IGuardClause guardClause, Func<bool> predicate, string? message = null)
    {
        Guard.Against.Null(predicate, message);

        if (predicate())
        {
            throw new ArgumentException(message ?? "The input matched an exclusion case in the requirements.");
        }

        return false;
    }



    public static bool False(this IGuardClause guardClause, Func<bool> predicate, string? message = null)
    {
        Guard.Against.Null(predicate, message);

        if (!predicate())
        {
            throw new ArgumentException(message ?? "The input did not satisfy the requirements.");
        }

        return true;
    }

}
