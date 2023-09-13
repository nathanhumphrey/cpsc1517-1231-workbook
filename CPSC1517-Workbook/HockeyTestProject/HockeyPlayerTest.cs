using FluentAssertions;
using Hockey.Data;
using System.Collections;
using System.Numerics;

namespace Hockey.Test
{
    public class HockeyPlayerTest
    {
        // Constants for test HockeyPlayer
        const string FIRST_NAME = "Connor";
        const string LAST_NAME = "Brown";
        const string BIRTH_PLACE = "Toronto, ON, CAN";
        static readonly DateOnly DATE_OF_BIRTH = new DateOnly(1994, 01, 14);
        const int HEIGHT_IN_INCHES = 72;
        const int WEIGHT_IN_LBS = 188;
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

        // Test data generateor for class data (see line 85 below)
        private class BadHockeyPlayerTestDataGenerator : IEnumerable<object[]>
        {
            private readonly List<object[]> _data = new List<object[]>
            {
                // First Name tests
                new object[]{"", LAST_NAME, BIRTH_PLACE, DATE_OF_BIRTH, HEIGHT_IN_INCHES, WEIGHT_IN_LBS, POSITION, SHOT, "First name cannot be null or empty." },
                new object[]{" ", LAST_NAME, BIRTH_PLACE, DATE_OF_BIRTH, HEIGHT_IN_INCHES, WEIGHT_IN_LBS, POSITION, SHOT, "First name cannot be null or empty." },
                new object[]{null, LAST_NAME, BIRTH_PLACE, DATE_OF_BIRTH, HEIGHT_IN_INCHES, WEIGHT_IN_LBS, POSITION, SHOT, "First name cannot be null or empty." },
            };

            public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        // Alternative test data generator for member data (see line 97 below)
        public static IEnumerable<object[]> GetTestHockeyPlayer()
        {
            // Add as many test objects as desired/required
            yield return new object[]
            {
                new HockeyPlayer(FIRST_NAME, LAST_NAME, BIRTH_PLACE, DATE_OF_BIRTH, HEIGHT_IN_INCHES, WEIGHT_IN_LBS, POSITION, SHOT)
            };
        }

        // ===================================================================
        // =               LEFT HERE FOR POSTERITY, NOT IN USE               =
        // ===================================================================
        //[Fact]
        //public void HockeyPlayer_DefaultConstructor_ReturnsHockeyPlayer()
        //{
        //    HockeyPlayer sut = new HockeyPlayer();

        //    // We're not testing the properties ... need to test the data fields, but they're private! So, what to do? Simply test that this
        //    // constructor returns a HockeyPlayer instance.

        //    sut.Should().NotBeNull();
        //}

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
        [ClassData(typeof(BadHockeyPlayerTestDataGenerator))]
        public void HockeyPlayer_GreedyConstructor_ThrowsException(string firstName, string lastName, string birthPlace, 
            DateOnly dateOfBirth, int weightInPounds, int heightInInches, Position position, Shot shot, string errMsg)
        {
            // Arrange
            Action act = () => new HockeyPlayer(firstName, lastName, birthPlace, dateOfBirth, weightInPounds, heightInInches, position, shot);

            // Act/Assert
            act.Should().Throw<ArgumentException>().WithMessage(errMsg);
        }

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