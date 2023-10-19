using FluentAssertions;
using Hockey.Data;
using System.Collections;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace Hockey.Test
{
    public class HockeyPlayerTest
    {
        // Constants for test HockeyPlayer
        const string FirstName = "Connor";
        const string LastName = "Brown";
        const string BirthPlace = "Toronto, ON, CAN";
        static readonly DateOnly DateOfBirth = new DateOnly(1994, 01, 14);
        const int HeightInInches = 72;
        const int WeightInPounds = 188;
        const int JerseyNumber = 28;
        const Position PlayerPosition = Position.Center;
        const Shot PlayerShot = Shot.Left;
        // The following relies on our being correct here - not writing a test for the test expected value
        readonly int Age = (DateOnly.FromDateTime(DateTime.Now).DayNumber - DateOfBirth.DayNumber) / 365;
        string ToStringValue = $"{FirstName},{LastName},{JerseyNumber},{PlayerPosition},{PlayerShot},{HeightInInches},{WeightInPounds},Jan-14-1994,{BirthPlace.Replace(", ", "-")}";

        // Can quickly run a test to check our method for AGE above
        //[Fact]
        //public void AGE_Is_Correct()
        //{
        //    AGE.Should().Be(29);
        //}

        public HockeyPlayer CreateTestHockeyPlayer()
        {
            return new HockeyPlayer(FirstName, LastName, BirthPlace, DateOfBirth, WeightInPounds, HeightInInches, JerseyNumber, PlayerPosition, PlayerShot);
        }

        // Test data generateor for class data (see line 85 below)
        private class BadHockeyPlayerTestDataGenerator : IEnumerable<object[]>
        {
            private readonly List<object[]> _data = new List<object[]>
            {
                // First Name tests
                new object[]{"", LastName, BirthPlace, DateOfBirth, WeightInPounds, HeightInInches,JerseyNumber, PlayerPosition, PlayerShot, "First name cannot be null or empty." },
                new object[]{" ", LastName, BirthPlace, DateOfBirth, WeightInPounds, HeightInInches, JerseyNumber, PlayerPosition, PlayerShot, "First name cannot be null or empty." },
                new object[]{null, LastName, BirthPlace, DateOfBirth, WeightInPounds, HeightInInches, JerseyNumber, PlayerPosition, PlayerShot, "First name cannot be null or empty." },

                // Last Name tests
                new object[]{FirstName, "", BirthPlace, DateOfBirth, WeightInPounds, HeightInInches, JerseyNumber, PlayerPosition, PlayerShot, "Last name cannot be null or empty." },
                new object[]{FirstName, " ", BirthPlace, DateOfBirth, WeightInPounds, HeightInInches, JerseyNumber, PlayerPosition, PlayerShot, "Last name cannot be null or empty." },
                new object[]{FirstName, null, BirthPlace, DateOfBirth, WeightInPounds, HeightInInches, JerseyNumber, PlayerPosition, PlayerShot, "Last name cannot be null or empty." },

                // Birth Place tests
                new object[]{FirstName, LastName, "", DateOfBirth, WeightInPounds, HeightInInches, JerseyNumber, PlayerPosition, PlayerShot, "Birth place cannot be null or empty." },
                new object[]{FirstName, LastName, " ", DateOfBirth, WeightInPounds, HeightInInches, JerseyNumber, PlayerPosition, PlayerShot, "Birth place cannot be null or empty." },
                new object[]{FirstName, LastName, null, DateOfBirth, WeightInPounds, HeightInInches, JerseyNumber, PlayerPosition, PlayerShot, "Birth place cannot be null or empty." },

                // Date of Birth test
                new object[]{FirstName, LastName, BirthPlace, DateOnly.FromDateTime(DateTime.Now.AddDays(1)), WeightInPounds, HeightInInches, JerseyNumber, PlayerPosition, PlayerShot, "Date of birth cannot be in the future." },

                // Height test
                new object[]{FirstName, LastName, BirthPlace, DateOfBirth, WeightInPounds , - 1, JerseyNumber, PlayerPosition, PlayerShot, "Height must be positive." },

                // Weight test
                new object[]{FirstName, LastName, BirthPlace, DateOfBirth, -1, HeightInInches, JerseyNumber, PlayerPosition, PlayerShot, "Weight must be positive." },

                // Jersey number tests
                new object[]{FirstName, LastName, BirthPlace, DateOfBirth, HeightInInches, WeightInPounds, 0, PlayerPosition, PlayerShot, "Jersey number must be between 1 and 98." },
                new object[]{FirstName, LastName, BirthPlace, DateOfBirth, HeightInInches, WeightInPounds, 99, PlayerPosition, PlayerShot, "Jersey number must be between 1 and 98." },

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
               FirstName, LastName, BirthPlace, DateOfBirth, HeightInInches, WeightInPounds, JerseyNumber, PlayerPosition, PlayerShot,
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

            actual = new HockeyPlayer(firstName, lastName, birthPlace, dateOfBirth, weightInPounds, heightInInches, jerseyNumber, position, shot);

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
            actual.Should().Be(Age);
        }

        [Fact]
        public void HockeyPlayer_ToString_ReturnsCorrectValue()
        {
            // Arrange 
            HockeyPlayer player = CreateTestHockeyPlayer();
            // Act
            string actual = player.ToString();

            // Assert
            actual.Should().Be(ToStringValue);
        }

        [Fact]
        public void HockeyPlayer_Parse_ParsesCorrectly()
        {
            HockeyPlayer actual;
            string line = $"{FirstName},{LastName},{JerseyNumber},{PlayerPosition},{PlayerShot},{HeightInInches},{WeightInPounds},Jan-14-1994,{BirthPlace.Replace(", ", "-")}";

            actual = HockeyPlayer.Parse(line);

            actual.Should().BeOfType<HockeyPlayer>();

        }

        [Theory]
        [InlineData(null, "Line cannot be null or empty.")]
        [InlineData("", "Line cannot be null or empty.")]
        [InlineData(" ", "Line cannot be null or empty.")]

		public void HockeyPlayer_Parse_ThrowsForNullEmptyOrWhiteSpaceLine(string line, string errMsg)
        {
            Action act = () => HockeyPlayer.Parse(line);

            act.Should().Throw<ArgumentNullException>().WithMessage(errMsg);

        }

        [Theory]
		[InlineData("one", "Incorrect number of fieds.")]
		public void HockeyPlayer_Parse_ThrowsForInvalidNumberOfFields(string line, string errMsg)
		{
			Action act = () => HockeyPlayer.Parse(line);

			act.Should().Throw<InvalidDataException>().WithMessage(errMsg);

		}

        [Theory]
		[InlineData("one,two,three,four,five,six,seven,eight,nine", "Error parsing line")]
		public void HockeyPlayer_Parse_ThrowsForFormatError(string line, string errMsg)
		{
			Action act = () => HockeyPlayer.Parse(line);

			act.Should().Throw<FormatException>().WithMessage($"*{errMsg}*");

		}

        [Fact]
        public void HockeyPlayer_TryParse_ParsesCorrectly()
        {
            HockeyPlayer? actual = null;
            bool result;

            result = HockeyPlayer.TryParse(ToStringValue, out actual);

            result.Should().BeTrue();
            actual.Should().NotBeNull();
        }
	}
}