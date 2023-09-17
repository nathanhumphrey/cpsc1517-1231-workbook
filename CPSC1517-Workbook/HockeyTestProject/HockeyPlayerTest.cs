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
        const int HEIGHT_IN_INCHES = 72;
        const int WEIGHT_IN_LBS = 188;
        const int JERSEY_NUMBER = 28;
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

        public HockeyPlayer CreateTestHockeyPlayer()
        {
            return new HockeyPlayer(FIRST_NAME, LAST_NAME, BIRTH_PLACE, DATE_OF_BIRTH, HEIGHT_IN_INCHES, WEIGHT_IN_LBS, JERSEY_NUMBER, POSITION, SHOT);
        }

        // Test data generateor for class data (see line 85 below)
        private class BadHockeyPlayerTestDataGenerator : IEnumerable<object[]>
        {
            private readonly List<object[]> _data = new List<object[]>
            {
                // First Name tests
                new object[]{"", LAST_NAME, BIRTH_PLACE, DATE_OF_BIRTH, HEIGHT_IN_INCHES, WEIGHT_IN_LBS, JERSEY_NUMBER, POSITION, SHOT, "First name cannot be null or empty." },
                new object[]{" ", LAST_NAME, BIRTH_PLACE, DATE_OF_BIRTH, HEIGHT_IN_INCHES, WEIGHT_IN_LBS, JERSEY_NUMBER, POSITION, SHOT, "First name cannot be null or empty." },
                new object[]{null, LAST_NAME, BIRTH_PLACE, DATE_OF_BIRTH, HEIGHT_IN_INCHES, WEIGHT_IN_LBS, JERSEY_NUMBER, POSITION, SHOT, "First name cannot be null or empty." },

                // TODO: complete remaining private set tests
            };

            public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        // Alternative test data generator for member data (see line 97 below)
        public static IEnumerable<object[]> GoodHockeyPlayerTestDataGenerator()
        {
            // Yield as many test objects as desired/required
            yield return new object[]
            {
               FIRST_NAME, LAST_NAME, BIRTH_PLACE, DATE_OF_BIRTH, HEIGHT_IN_INCHES, WEIGHT_IN_LBS, JERSEY_NUMBER, POSITION, SHOT,
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
        [MemberData(nameof(GoodHockeyPlayerTestDataGenerator))]
        public void HockeyPlayer_GreedyConstructor_ReturnsHockeyPlayer(string firstName, string lastName, string birthPlace,
            DateOnly dateOfBirth, int weightInPounds, int heightInInches, int jerseyNumber, Position position, Shot shot)
        {
            // TODO: describe and explain the issue(s) with performing the test in this way - use a ClassData or MemberData option
            //HockeyPlayer sut = new HockeyPlayer("Connor", "Brown", "Toronto, ON, CAN", new DateOnly(1994, 01, 14), 82, 183, Position.Center, Shot.Right);

            HockeyPlayer actual;
            
            actual = new HockeyPlayer(firstName, lastName, birthPlace, dateOfBirth, weightInPounds, heightInInches, jerseyNumber ,position, shot);
            
            actual.Should().NotBeNull();
        }

        [Theory]
        [ClassData(typeof(BadHockeyPlayerTestDataGenerator))]
        public void HockeyPlayer_GreedyConstructor_ThrowsException(string firstName, string lastName, string birthPlace,
            DateOnly dateOfBirth, int weightInPounds, int heightInInches, int jerseyNumber, Position position, Shot shot, string errMsg)
        {
            // Arrange
            Action act = () => new HockeyPlayer(firstName, lastName, birthPlace, dateOfBirth, weightInPounds, heightInInches, jerseyNumber, position, shot);

            // Act/Assert
            act.Should().Throw<ArgumentException>().WithMessage(errMsg);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(98)]
        public void HockeyPlayer_JerseyNumber_GoodSetAndGet(int value)
        {
            // Arrange 
            HockeyPlayer player = CreateTestHockeyPlayer();

            // Act
            player.JerseyNumber = value;
            int actual = player.JerseyNumber;

            // Assert
            actual.Should().Be(value);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(99)]
        public void HockeyPlayer_JerseyNumber_BadSetThrows(int value)
        {
            // Arrange 
            HockeyPlayer player = CreateTestHockeyPlayer();
            Action act = () => player.JerseyNumber = value;

            // Act/Assert
            act.Should().Throw<ArgumentException>().WithMessage("Jersey number must be between 1 and 98.");
        }

        [Fact]
        public void HockeyPlayer_Age_ReturnsCorrectAge()
        {
            // Arrange 
            HockeyPlayer player = CreateTestHockeyPlayer();

            // Act
            int actual = player.Age;

            // Assert
            actual.Should().Be(AGE);
        }

        [Fact]
        public void HockeyPlayer_ToString_ReturnsCorrectValue()
        {
            // Arrange 
            HockeyPlayer player = CreateTestHockeyPlayer();
            // Act
            string actual = player.ToString();

            // Assert
            actual.Should().Be(TOSTRING_VALUE);
        }
    }
}