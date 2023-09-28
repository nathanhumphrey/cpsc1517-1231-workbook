using FluentAssertions;
using ObjectClassLibrary;
using System.Runtime.InteropServices;

namespace ObjectClassLibraryTest
{
    public class BodyMassIndexTest
    {
        const string Name = "Jack Black";
        const double Weight = 180;
        const double Height = 65;
        const double BmiValue = 30.0;
        const string BmiCategoryValue = "obese";

        private static BodyMassIndex GenerateBodyMassIndexInstance()
        {
            return new BodyMassIndex(Name, Weight, Height);
        }

        [Fact]
        public void BodyMassIndex_Bmi_ReturnsCorrectBmiValue()
        {
            // Arrange
            BodyMassIndex bmi = GenerateBodyMassIndexInstance();
            double actual;

            // Act
            actual = bmi.Bmi();

            // Assert
            actual.Should().Be(BmiValue);
        }

        [Fact]
        public void BodyMassIndex_BmiCategory_ReturnsCorrectBmiCategory()
        {
            // Arrange
            BodyMassIndex bmi = GenerateBodyMassIndexInstance();
            string actual;

            // Act
            actual = bmi.BmiCategory();

            // Assert
            actual.Should().Be(BmiCategoryValue);
        }

        [Theory]
        [InlineData("", Weight, Height)]
        [InlineData("  ", Weight, Height)]
        public void BodyMassIndex_Constructor_ThrowsForEmptyName(string name, double weight, double height)
        {
            // Arrange
            BodyMassIndex bmi;
            Action act = () => bmi = new BodyMassIndex(name, weight, height);
            
            // Act/Assert
            act.Should().Throw<ArgumentNullException>().WithMessage("Name cannot be blank");
        }

        [Theory]
        [InlineData(Name, 0, Height)]
        [InlineData(Name, -100, Height)]
        public void BodyMassIndex_Constructor_ThrowsForNonPositiveWeight(string name, double weight, double height)
        {
            // Arrange
            BodyMassIndex bmi;
            Action act = () => bmi = new BodyMassIndex(name, weight, height);

            // Act/Assert
            act.Should().Throw<ArgumentOutOfRangeException>().WithMessage("Weight must be a positive non-zero number");
        }

        [Theory]
        [InlineData(Name, Weight, 0)]
        [InlineData(Name, Weight, -100)]
        public void BodyMassIndex_Constructor_ThrowsForNonPositiveHeight(string name, double weight, double height)
        {
            // Arrange
            BodyMassIndex bmi;
            Action act = () => bmi = new BodyMassIndex(name, weight, height);

            // Act/Assert
            act.Should().Throw<ArgumentOutOfRangeException>().WithMessage("Height must be a positive non-zero number");
        }

        [Theory]
        [InlineData("Underweight Person1", 90, 60, "underweight", 17.6)]
        [InlineData("Underweight Person2", 120, 75, "underweight", 15.0)]
        public void BodyMassIndex_BmiCategory_ReturnsUnderweightCategory(string name, double weight, double height, string expectedCategory, double expectedBmi)
        {
            // Arrange
            BodyMassIndex bmi;
            string actualBmiCategory;
            double actualBmi;

            // Act
            bmi = new BodyMassIndex(name, weight, height);
            actualBmiCategory = bmi.BmiCategory();
            actualBmi = bmi.Bmi();

            // Assert
            actualBmiCategory.Should().Be(expectedCategory);
            actualBmi.Should().Be(expectedBmi);
        }

        [Theory]
        [InlineData("Normal weight Person1", 111, 65, "normal", 18.5)]
        [InlineData("Normal weight Person2", 149, 65, "normal", 24.8)]
        public void BodyMassIndex_BmiCategory_ReturnsNormalWeightCategory(string name, double weight, double height, string expectedCategory, double expectedBmi)
        {
            // Arrange
            BodyMassIndex bmi;
            string actualBmiCategory;
            double actualBmi;

            // Act
            bmi = new BodyMassIndex(name, weight, height);
            actualBmiCategory = bmi.BmiCategory();
            actualBmi = bmi.Bmi();

            // Assert
            actualBmiCategory.Should().Be(expectedCategory);
            actualBmi.Should().Be(expectedBmi);
        }

        [Theory]
        [InlineData("Overweight Person1", 150, 65, "overweight", 25.0)]
        [InlineData("Overweight Person2", 179, 65, "overweight", 29.8)]
        public void BodyMassIndex_BmiCategory_ReturnsOverweightCategory(string name, double weight, double height, string expectedCategory, double expectedBmi)
        {
            // Arrange
            BodyMassIndex bmi;
            string actualBmiCategory;
            double actualBmi;

            // Act
            bmi = new BodyMassIndex(name, weight, height);
            actualBmiCategory = bmi.BmiCategory();
            actualBmi = bmi.Bmi();

            // Assert
            actualBmiCategory.Should().Be(expectedCategory);
            actualBmi.Should().Be(expectedBmi);
        }

        [Theory]
        [InlineData("Obese Person1", 180, 65, "obese", 30.0)]
        [InlineData("Obese Person2", 210, 65, "obese", 34.9)]
        public void BodyMassIndex_BmiCategory_ReturnsObeseCategory(string name, double weight, double height, string expectedCategory, double expectedBmi)
        {
            // Arrange
            BodyMassIndex bmi;
            string actualBmiCategory;
            double actualBmi;

            // Act
            bmi = new BodyMassIndex(name, weight, height);
            actualBmiCategory = bmi.BmiCategory();
            actualBmi = bmi.Bmi();

            // Assert
            actualBmiCategory.Should().Be(expectedCategory);
            actualBmi.Should().Be(expectedBmi);
        }
    }
}