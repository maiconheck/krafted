using System;

namespace Krafted.IntegrationTest.Infrastructure.Sql.Builtin
{
    public class DummyModel : Entity
    {
        public string Name { get; }

        public DateTime StartDate { get; }

        public DateTime EndDate { get; }

        public bool Canceled { get; }
    }
}