using FluentAssertions;
using Utils;

namespace UtilitiesTestProject
{
    public class UtilitiesTest
    {
        // String Tests

        [Fact]
        public void Utilities_IsNullEmptyOrWhiteSpace_ReturnsFalseForNonEmpty()
        {
            // Arrange
            const string GoodString = "x";
            bool actual;

            // Act 
            actual = Utilities.IsNullEmptyOrWhiteSpace(GoodString);

            actual.Should().Be(false);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Utilities_IsNullEmptyOrWhiteSpace_ReturnsTrueForEmpyNullOrWhiteSpace(string value)
        {
            // Arrange
            bool actual;

            // Act 
            actual = Utilities.IsNullEmptyOrWhiteSpace(value);

            actual.Should().Be(true);
        }

        // Date Tests

        public static IEnumerable<object[]> GenerateIsInFutureTestData()
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
        [MemberData(nameof(GenerateIsInFutureTestData))]
        public void Utils_IsInTheFuture_ReturnsTrueForFutureFalseOtherwise(object date, bool expected)
        {
            // Arrange
            bool actual;

            // Act
            if (date.GetType() == typeof(DateTime))
            {
                actual = Utilities.IsInTheFuture((DateTime)date);
            }
            else
            {
                actual = Utilities.IsInTheFuture((DateOnly)date);
            }

            // Assert
            actual.Should().Be(expected);

        }

        // Numeric Tests

        [Theory]
        [InlineData(1)]
        [InlineData(1.0D)]
        [InlineData("1.0")]
        public void Utils_IsPositive_ReturnsTrueForPositive(object value)
        {
            // Arrange
            bool expected;

            // Act
            if (value.GetType() == typeof(int))
            {
                expected = Utilities.IsPositive((int)value);
            }
            else if (value.GetType() == typeof(double))
            {
                expected = Utilities.IsPositive((double)value);
            }
            else
            {
                expected = Utilities.IsPositive(Convert.ToDecimal(value));
            }


            // Assert
            expected.Should().BeTrue();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(0.0D)]
        [InlineData("0")]
        [InlineData(-1)]
        [InlineData(-1.0D)]
        [InlineData("-1.0")]
        public void Utils_IsPositive_ReturnsFalseForZeroOrNegative(object value)
        {
            // Arrange
            bool expected;

            // Act
            // Act
            if (value.GetType() == typeof(int))
            {
                expected = Utilities.IsPositive((int)value);
            }
            else if (value.GetType() == typeof(double))
            {
                expected = Utilities.IsPositive((double)value);
            }
            else
            {
                expected = Utilities.IsPositive(Convert.ToDecimal(value));
            }

            // Assert
            expected.Should().BeFalse();
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-1.0D)]
        [InlineData("-1.0")]
        public void Utils_IsNegative_ReturnsTrueForNegative(object value)
        {
            // Arrange
            bool expected;

            // Act
            if (value.GetType() == typeof(int))
            {
                expected = Utilities.IsNegative((int)value);
            }
            else if (value.GetType() == typeof(double))
            {
                expected = Utilities.IsNegative((double)value);
            }
            else
            {
                expected = Utilities.IsNegative(Convert.ToDecimal(value));
            }


            // Assert
            expected.Should().BeTrue();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(0.0D)]
        [InlineData("0")]
        [InlineData(1)]
        [InlineData(1.0D)]
        [InlineData("1.0")]
        public void Utils_IsNegative_ReturnsFalseForZeroOrPositive(object value)
        {
            // Arrange
            bool expected;

            // Act
            // Act
            if (value.GetType() == typeof(int))
            {
                expected = Utilities.IsNegative((int)value);
            }
            else if (value.GetType() == typeof(double))
            {
                expected = Utilities.IsNegative((double)value);
            }
            else
            {
                expected = Utilities.IsNegative(Convert.ToDecimal(value));
            }

            // Assert
            expected.Should().BeFalse();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(0.0D)]
        [InlineData("0")]
        [InlineData(1)]
        [InlineData(1.0D)]
        [InlineData("1.0")]
        public void Utils_IsZeroOrPositive_ReturnsTrueForZeroOrPositive(object value)
        {
            // Arrange
            bool expected;

            // Act
            if (value.GetType() == typeof(int))
            {
                expected = Utilities.IsZeroOrPositive((int)value);
            }
            else if (value.GetType() == typeof(double))
            {
                expected = Utilities.IsZeroOrPositive((double)value);
            }
            else
            {
                expected = Utilities.IsZeroOrPositive(Convert.ToDecimal(value));
            }


            // Assert
            expected.Should().BeTrue();
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-1.0D)]
        [InlineData("-1.0")]
        public void Utils_IsZeroOrPositive_ReturnsFalseForNegative(object value)
        {
            // Arrange
            bool expected;

            // Act
            // Act
            if (value.GetType() == typeof(int))
            {
                expected = Utilities.IsZeroOrPositive((int)value);
            }
            else if (value.GetType() == typeof(double))
            {
                expected = Utilities.IsZeroOrPositive((double)value);
            }
            else
            {
                expected = Utilities.IsZeroOrPositive(Convert.ToDecimal(value));
            }

            // Assert
            expected.Should().BeFalse();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(0.0D)]
        [InlineData("0")]
        [InlineData(-1)]
        [InlineData(-1.0D)]
        [InlineData("-1.0")]
        public void Utils_IsZeroOrNegative_ReturnsTrueForZeroOrNegative(object value)
        {
            // Arrange
            bool expected;

            // Act
            if (value.GetType() == typeof(int))
            {
                expected = Utilities.IsZeroOrNegative((int)value);
            }
            else if (value.GetType() == typeof(double))
            {
                expected = Utilities.IsZeroOrNegative((double)value);
            }
            else
            {
                expected = Utilities.IsZeroOrNegative(Convert.ToDecimal(value));
            }


            // Assert
            expected.Should().BeTrue();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(1.0D)]
        [InlineData("1.0")]
        public void Utils_IsZeroOrNegative_ReturnsFalseForPositive(object value)
        {
            // Arrange
            bool expected;

            // Act
            // Act
            if (value.GetType() == typeof(int))
            {
                expected = Utilities.IsZeroOrNegative((int)value);
            }
            else if (value.GetType() == typeof(double))
            {
                expected = Utilities.IsZeroOrNegative((double)value);
            }
            else
            {
                expected = Utilities.IsZeroOrNegative(Convert.ToDecimal(value));
            }

            // Assert
            expected.Should().BeFalse();
        }
    }
}