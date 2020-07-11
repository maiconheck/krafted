using System;
using System.Collections.Generic;
using System.Linq;
using Krafted.Data;
using Krafted.Data.SqlServer.Dapper;
using Xunit;
using Assert = Krafted.Test.UnitTest.Xunit.AssertExtension;

namespace Krafted.UnitTest.Krafted.Data.SqlServer.Dapper
{
    public class EntityDummy : Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityDummy"/> class.
        /// </summary>
        public EntityDummy()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityDummy"/> class.
        /// </summary>
        /// <param name="foo">The foo.</param>
        /// <param name="bar">The bar.</param>
        public EntityDummy(string foo, string bar = "")
        {
            Foo = foo;
            Bar = bar;
        }

        public string Foo { get; }

        public string Bar { get; }
    }
}
