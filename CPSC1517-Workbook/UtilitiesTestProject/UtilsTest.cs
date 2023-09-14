using FluentAssertions;
using Utils;

namespace UtilitiesTestProject
{
    public class UtilsTest
    {
        // Numeric Tests
        [Fact]
        public void Utils_IsPositive_ReturnsTrueForPositive()
        {
            // Arrange
            int positive = 1;
            bool expected;

            // Act
            expected = Utils.Utilities.IsPositive(positive);

            // Assert
            expected.Should().BeTrue();
        }

        [Fact]
        public void Utils_IsPositive_ReturnsFalseForZero()
        {
            // Arrange
            int zero = 0;
            bool expected;

            // Act
            expected = Utils.Utilities.IsPositive(zero);

            // Assert
            expected.Should().BeFalse();
        }

        [Fact]
        public void Utils_IsPositive_ReturnsFalseForNegative()
        {
            // Arrange
            int negative = -1;
            bool expected;

            // Act
            expected = Utils.Utilities.IsPositive(negative);

            // Assert
            expected.Should().BeFalse();
        }

        // String Tests

        // Date Tests
        public static IEnumerable<object[]> GenerateAgeTestData()
        {
            // DateTime
            yield return new object[]
            {
                DateTime.Now,
                false,
            };
            yield return new object[]
            {
                DateTime.Now.Subtract(TimeSpan.FromMilliseconds(100)),
                false,
            };
            yield return new object[]
            {
                DateTime.Now.Add(TimeSpan.FromMilliseconds(100)),
                true,
            };
            // DateOnly
            yield return new object[]
            {
                DateOnly.FromDateTime(DateTime.Now),
                false,
            };
            yield return new object[]
            {
                DateOnly.FromDateTime(DateTime.Now).AddDays(-1),
                false,
            };
            yield return new object[]
            {
                DateOnly.FromDateTime(DateTime.Now).AddDays(1),
                true,
            };
        }

        [Theory]
        [MemberData(nameof(GenerateAgeTestData))]
        public void Utils_IsInTheFuture_ReturnsTrueForFutureFalseOtherwise(object date, bool expected)
        {
            // Arrange
            bool actual;

            // Act
            //if (typeof(DateTime).IsAssignableTo(date.GetType()))
            if (date.GetType() == typeof(DateTime))
            {
                actual = Utils.Utilities.IsInTheFuture((DateTime)date);
            }
            else
            {
                actual = Utils.Utilities.IsInTheFuture((DateOnly)date);
            }

            // Assert
            actual.Should().Be(expected);

        }
    }
}