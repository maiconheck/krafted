using System;
using Xunit;

namespace Krafted.UnitTest.Krafted
{
    [Trait(nameof(UnitTest), nameof(Krafted))]
    public class StringExtensionTest
    {
        [Theory(Skip = "wip")]
        [InlineData("aaa", @"(?<=SET).*?\,|(AND.*?\)\))|(?<=WHERE.)\(|(Original_)")]
        public void Remove_Input_Pattern_ShouldBeRemoved(string input, string pattern)
        {
            var actual = input.Remove(pattern);
            Assert.Equal("aaa", actual);
        }
    }
}