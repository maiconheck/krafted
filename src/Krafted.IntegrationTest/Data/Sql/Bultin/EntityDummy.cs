using System;

namespace Krafted.IntegrationTest.Data.Sql.Bultin
{
    public class EntityDummy : Entity
    {
        public string Name { get; }

        public DateTime StartDate { get; }

        public DateTime EndDate { get; }

        public bool Canceled { get; }
    }
}