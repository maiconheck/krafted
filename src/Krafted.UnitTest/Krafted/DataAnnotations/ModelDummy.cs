using System.Collections.Generic;
using Krafted.DataAnnotations;

namespace Krafted.UnitTest.Krafted.DataAnnotations
{
    public class NotEmptyCollectionModelDummy
    {
        [NotEmptyCollection]
        public IEnumerable<int> MyProperty1 { get; set; }

        [NotEmptyCollection(ErrorMessage = "Provide at least one item.")]
        public IEnumerable<int> MyProperty2 { get; set; }
    }

    public class MinOneModelDummy
    {
        [MinOne]
        public int MyProperty1 { get; set; }

        [MinOne(ErrorMessage = "The number should be positive.")]
        public int MyProperty2 { get; set; }
    }
}
