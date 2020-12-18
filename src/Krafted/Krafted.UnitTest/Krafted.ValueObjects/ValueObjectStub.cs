using System.Collections.Generic;
using Krafted.ValueObjects;

namespace Krafted.UnitTest.Krafted.ValueObjects
{
    public class ValueObjectStub : ValueObject
    {
        public ValueObjectStub(string street, string city, string zipCode)
        {
            Street = street;
            City = city;
            ZipCode = zipCode;
        }

        public string Street { get; private set; }

        public string City { get; }

        public string ZipCode { get; }

        // Value objects must be read-only, this is for testing only.
        public void SetStreet(string street) => Street = street;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Street;
            yield return City;
            yield return ZipCode;
        }
    }
}
