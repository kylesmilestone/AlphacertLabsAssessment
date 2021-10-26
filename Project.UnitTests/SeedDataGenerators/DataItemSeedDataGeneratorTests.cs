using System;
using System.Linq;
using Project.SeedDataGenerators;
using Xunit;

namespace Project.UnitTests.SeedDataGenerators
{
    public class DataItemSeedDataGeneratorTests
    {
        [Fact]
        public void GetValueStringByNumber_ReturnsCorrectString()
        {
            // Arrange
            var stringMultipleOf3 = "stringMultipleOfThree";
            var stringMultipleOf5 = "stringMultipleOfFive";
            var stringMultipleOf3And5 = stringMultipleOf3 + stringMultipleOf5;

            // Act & Asset
            for (int i = 1; i < 50000; i++)
            {
                var dataItem = DataItemSeedDataGenerator.GetValueStringByNumber(stringMultipleOf3, stringMultipleOf5, i);

                if (i % 15 == 0)
                {
                    Assert.Equal(stringMultipleOf3And5, dataItem.Value);
                }
                else if (i % 3 == 0)
                {
                    Assert.Equal(stringMultipleOf3, dataItem.Value);
                }
                else if (i % 5 == 0)
                {
                    Assert.Equal(stringMultipleOf5, dataItem.Value);
                }
            }
        }

        [Fact]
        public void GetValueStringByNumber_NumberLessThan0_ThrowsArgumentException()
        {
            // Arrange
            var stringMultipleOf3 = "stringMultipleOfThree";
            var stringMultipleOf5 = "stringMultipleOfFive";

            // Act & Asset
            for (int i = -50000; i < 0; i++)
            {
                try
                {
                    DataItemSeedDataGenerator.GetValueStringByNumber(stringMultipleOf3, stringMultipleOf5, i);
                }
                catch (ArgumentException)
                {
                    Assert.True(true);
                }
                catch
                {
                    // wrong type of exception
                    Assert.True(false, "Wrong Type of Exception");
                }
            }
        }

        [Fact]
        public void GetSeedData_ReturnsCorrectAmountOfSeedDataItems()
        {
            // Art
            var data = DataItemSeedDataGenerator.GetSeedData();

            Assert.Equal(100, data.Count());
        }

        [Fact]
        public void GetSeedData_ReturnsCorrectAmountOfMultipleOf15()
        {
            // Arrange
            var stringMultipleOf3 = "Fizz";
            var stringMultipleOf5 = "Buzz";
            var stringMultipleOf3And5 = stringMultipleOf3 + stringMultipleOf5;
            var data = DataItemSeedDataGenerator.GetSeedData();

            // Arc
            var multipleOf15Items = data.Where(d => d.Value == stringMultipleOf3And5);

            Assert.Equal(6, multipleOf15Items.Count());
        }

        [Fact]
        public void GetSeedData_ReturnsCorrectAmountOfMultipleOf3()
        {
            // Arrange
            var stringMultipleOf3 = "Fizz";
            var data = DataItemSeedDataGenerator.GetSeedData();

            // Arc
            var multipleOf15Items = data.Where(d => d.Value == stringMultipleOf3);

            // Assert
            Assert.Equal(27, multipleOf15Items.Count());
        }

        [Fact]
        public void GetSeedData_ReturnsCorrectAmountOfMultipleOf5()
        {
            // Arrange
            var stringMultipleOf5 = "Buzz";
            var data = DataItemSeedDataGenerator.GetSeedData();

            // Arc
            var multipleOf15Items = data.Where(d => d.Value == stringMultipleOf5);

            // Assert
            Assert.Equal(14, multipleOf15Items.Count());
        }
    }
}
