using System.Collections.Generic;
using Krafted.DataAnnotations;
using Krafted.DataAnnotations.Pt;

namespace Krafted.UnitTest.Krafted.DataAnnotations
{
    public class NotEmptyCollectionModelDummy
    {
        [NotEmptyCollection]
        public IEnumerable<int> MyProperty1 { get; set; }

        [NotEmptyCollection(ErrorMessage = "Provide at least one item.")]
        public IEnumerable<int> MyProperty2 { get; set; }
    }

    public class MinOneIntModelDummy
    {
        [MinOne]
        public int MyProperty1 { get; set; }

        [MinOne(ErrorMessage = "The number should be positive.")]
        public int MyProperty2 { get; set; }
    }

    public class MinOneLongModelDummy
    {
        [MinOne]
        public long MyProperty1 { get; set; }

        [MinOne(ErrorMessage = "The number should be positive.")]
        public long MyProperty2 { get; set; }
    }

    public class MinOneDecimalModelDummy
    {
        [MinOne]
        public decimal MyProperty1 { get; set; }

        [MinOne(ErrorMessage = "The number should be positive.")]
        public decimal MyProperty2 { get; set; }
    }

    public class NifModelDummy
    {
        [Nif]
        public string MyProperty1 { get; set; }

        [Nif(ErrorMessage = "The nif should be valid.")]
        public string MyProperty2 { get; set; }
    }
}
