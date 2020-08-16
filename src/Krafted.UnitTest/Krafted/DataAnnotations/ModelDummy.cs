using System.Collections.Generic;
using Krafted.DataAnnotations;

namespace Krafted.UnitTest.Krafted.DataAnnotations
{
    public class ModelDummy
    {
        [NotEmptyCollection]
        public IEnumerable<int> MyProperty1 { get; set; }

        [NotEmptyCollection(ErrorMessage = "Provide at least one item.")]
        public IEnumerable<int> MyProperty2 { get; set; }
    }
}
