#nullable enable

using Krafted.Guards;

namespace Krafted.UnitTest.Krafted.UnitTests.Xunit
{
    public class ModelDummy
    {
        public string Param1 { get; protected set; } = default!;

        public string Param2 { get; protected set; } = default!;

        public string Param3 { get; protected set; } = default!;

        public string Param4 { get; protected set; } = default!;

        public string Param5 { get; protected set; } = default!;
    }

    public class ModelWithNullGuardClausesForAllParameters : ModelDummy
    {
        public ModelWithNullGuardClausesForAllParameters(string? param1, string? param2, string? param3, string? param4, string? param5)
        {
            Guard.Against
                .Null(param1)
                .Null(param2)
                .Null(param3)
                .Null(param4)
                .Null(param5);

            Param1 = param1;
            Param2 = param2;
            Param3 = param3;
            Param4 = param4;
            Param5 = param5;
        }
    }

    public class ModelWithNullGuardClausesForSomeParameters : ModelDummy
    {
        public ModelWithNullGuardClausesForSomeParameters(string? param1, string? param2, string? param3, string? param4, string? param5)
        {
            Guard.Against
                .Null(param1)
                .Null(param2)
                .Null(param3)
                .Null(param5);

            Param1 = param1;
            Param2 = param2;
            Param3 = param3;
            Param4 = param4!;
            Param5 = param5;
        }
    }

    public class ModelWithoutNullGuardClauses : ModelDummy
    {
        public ModelWithoutNullGuardClauses(string? param1, string? param2, string? param3, string? param4, string? param5)
        {
            Param1 = param1!;
            Param2 = param2!;
            Param3 = param3!;
            Param4 = param4!;
            Param5 = param5!;
        }
    }
}
