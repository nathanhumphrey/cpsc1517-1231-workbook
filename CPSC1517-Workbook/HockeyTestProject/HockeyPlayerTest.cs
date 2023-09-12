using FluentAssertions;
using Hockey.Data;
using System.Collections;

namespace Hockey.Test
{
    public class HockeyPlayerTest
    {
        // Constants for test HockeyPlayer
        const string FIRST_NAME = "Connor";
        const string LAST_NAME = "Brown";
        const string BIRTH_PLACE = "Toronto, ON, CAN";
        static readonly DateOnly DATE_OF_BIRTH = new DateOnly(1994, 01, 14);
        const int HEIGHT_IN_CM = 183;
        const int WEIGHT_IN_KG = 82;
        const Position POSITION = Position.Center;
        const Shot SHOT = Shot.Left;
        // The following relies on our being correct here - not writing a test for the test expected value
        readonly int AGE = (DateOnly.FromDateTime(DateTime.Now).DayNumber - DATE_OF_BIRTH.DayNumber) / 365;
        const string TOSTRING_VALUE = $"{FIRST_NAME} {LAST_NAME}";

        // Can quickly run a test to check our method for AGE above
        //[Fact]
        //public void AGE_Is_Correct()
        //{
        //    AGE.Should().Be(29);
        //}

        // Test data generateor for class data (see line 53 below)
        private class TestHockeyPlayerGenerator : IEnumerable<object[]>
        {
            private readonly List<object[]> _data = new List<object[]>
            {
                new object[]
                {
                    new HockeyPlayer(FIRST_NAME, LAST_NAME, BIRTH_PLACE, DATE_OF_BIRTH, HEIGHT_IN_CM, WEIGHT_IN_KG, POSITION, SHOT)
                }
            };

            public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        // Alternative test data generator for member data (see line 54 below)
        public static IEnumerable<object[]> GetTestHockeyPlayer()
        {
            // Add as many test objects as desired/required
            yield return new object[]
            {
                new HockeyPlayer("Connor", "Brown", "Toronto, ON, CAN", new DateOnly(1994, 01, 14), 82, 183, Position.Center, Shot.Right)
            };
        }

        // Helper to create a default HockeyPlayer instance
        private HockeyPlayer CreateDefaultHockeyPlayer()
        {
            return new HockeyPlayer();
        }

        [Fact]
        public void HockeyPlayer_DefaultConstructor_ReturnsHockeyPlayer()
        {
            HockeyPlayer sut = CreateDefaultHockeyPlayer();

            // We're not testing the properties ... need to test the data fields, but they're private! So, what to do? Simply test that this
            // constructor returns a HockeyPlayer instance.

            sut.Should().NotBeNull();
        }

        // Switched the following from an original Fact test (relying on line 58 below) to a Theory test 
        // with two options: ClassData and MemberData
        //[Fact]
        [Theory]
        //[ClassData(typeof(TestHockeyPlayerGenerator))]
        [MemberData(nameof(GetTestHockeyPlayer))]
        public void HockeyPlayer_GreedyConstructor_ReturnsHockeyPlayer(HockeyPlayer sut)
        {
            // TODO: describe and explain the issue(s) with performing the test in this way - use a ClassData or MemberData option
            //HockeyPlayer sut = new HockeyPlayer("Connor", "Brown", "Toronto, ON, CAN", new DateOnly(1994, 01, 14), 82, 183, Position.Center, Shot.Right);

            sut.Should().NotBeNull();

        }

        [Theory]
        [InlineData("Bobby")]
        public void HockeyPlayer_FirstName_GoodSet(string firstName)
        {
            // Arrange
            HockeyPlayer player = CreateDefaultHockeyPlayer();

            // Act
            player.FirstName = firstName;

            // Assert
            player.FirstName.Should().Be(firstName);

        }

        const string INVALID_FIRST_NAME_MESSAGE = "First name cannot be null or empty.";
        [Theory]
        [InlineData("", INVALID_FIRST_NAME_MESSAGE)]
        [InlineData(" ", INVALID_FIRST_NAME_MESSAGE)]
        [InlineData(null, INVALID_FIRST_NAME_MESSAGE)]
        public void HockeyPlayer_FirstName_BadSet(string firstName, string message)
        {
            // Arrange
            HockeyPlayer player = CreateDefaultHockeyPlayer();
            Action act = () => player.FirstName = firstName;

            // Act/Assert
            act.Should().Throw<ArgumentException>().WithMessage(message);
        }

        // TODO: complete remaining string properties
        // TODO: complete remaining int properties

        [Theory]
        [MemberData(nameof(GetTestHockeyPlayer))]
        public void HockeyPlayer_Age_ReturnsCorrectAge(HockeyPlayer sut)
        {
            // Act
            int actual = sut.Age;

            // Assert
            actual.Should().Be(AGE);
        }

        [Theory]
        [MemberData(nameof(GetTestHockeyPlayer))]
        public void HockeyPlayer_ToString_ReturnsCorrectValue(HockeyPlayer sut)
        {
            // Act
            string actual = sut.ToString();

            // Assert
            actual.Should().Be(TOSTRING_VALUE);
        }
    }
}