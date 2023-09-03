using System;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace Krafted.UnitTest.Krafted.Extensions
{
    [Trait(nameof(UnitTest), "Krafted.Extensions")]
    public class EnumExtensionTest
    {
        public enum Season
        {
            [Display(Name = "The Spring!")]
            Spring,

            [Display(Name = "The Summer!")]
            Summer,

            [Display(Name = "The Autumn!")]
            Autumn,

            [Display(Name = "The Winter!")]
            Winter
        }

        public enum SeasonWithoutDisplay
        {
            Spring,
            Summer,
            Autumn,
            Winter
        }

        [Fact]
        public void GetDisplayName_Input_DisplayName()
        {
            Assert.Equal("The Spring!", Season.Spring.GetDisplayName());
            Assert.Equal("The Summer!", Season.Summer.GetDisplayName());
            Assert.Equal("The Autumn!", Season.Autumn.GetDisplayName());
            Assert.Equal("The Winter!", Season.Winter.GetDisplayName());
        }

        [Fact]
        public void GetDisplayName_InputWithoutDisplayAttribute_ThrowsException()
        {
            var ex1 = Assert.Throws<ArgumentException>(() => SeasonWithoutDisplay.Spring.GetDisplayName());
            Assert.Equal("The enum constant 'Spring' is not decorated with the DisplayAttribute. (Parameter 'input')", ex1.Message);

            var ex2 = Assert.Throws<ArgumentException>(() => SeasonWithoutDisplay.Summer.GetDisplayName());
            Assert.Equal("The enum constant 'Summer' is not decorated with the DisplayAttribute. (Parameter 'input')", ex2.Message);

            var ex3 = Assert.Throws<ArgumentException>(() => SeasonWithoutDisplay.Autumn.GetDisplayName());
            Assert.Equal("The enum constant 'Autumn' is not decorated with the DisplayAttribute. (Parameter 'input')", ex3.Message);

            var ex4 = Assert.Throws<ArgumentException>(() => SeasonWithoutDisplay.Winter.GetDisplayName());
            Assert.Equal("The enum constant 'Winter' is not decorated with the DisplayAttribute. (Parameter 'input')", ex4.Message);
        }

        [Fact]
        public void GetDisplayName_InputWithoutDisplayAttributeAndFallbackTrue_InputToString()
        {
            Assert.Equal("Spring", SeasonWithoutDisplay.Spring.GetDisplayName(fallback: true));
            Assert.Equal("Summer", SeasonWithoutDisplay.Summer.GetDisplayName(fallback: true));
            Assert.Equal("Autumn", SeasonWithoutDisplay.Autumn.GetDisplayName(fallback: true));
            Assert.Equal("Winter", SeasonWithoutDisplay.Winter.GetDisplayName(fallback: true));
        }
    }
}
