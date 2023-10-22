using System;
using System.Diagnostics.CodeAnalysis;
using Krafted.Guards;
using Krafted.ValueObjects;

namespace Krafted.UnitTest.Krafted.ValueObjects;

public sealed class DateOfBirthDummy : ValueObject<DateTime>
{
    public DateOfBirthDummy(DateTime value)
    {
        Guard.Against.True(_ => value >= DateTime.Today, $"Invalid date of birth: {value.ToShortDateString()}.");
        Value = value;
    }

    // Required for the ORM.
    [ExcludeFromCodeCoverage]
    private DateOfBirthDummy()
    {
    }

    public static explicit operator DateOfBirthDummy(in DateTime value) => new(value);

    public static DateOfBirthDummy NewDateBirth(in DateTime value) => new(value);
}
