using System;

namespace Krafted.IntegrationTest.Krafted.Data.SqlBuilder
{
    public class EntityDummy : Entity
    {
        public string Name { get; }

        public DateTime StartDate { get; }

        public DateTime EndDate { get; }

        public bool Canceled { get; }
    }
}