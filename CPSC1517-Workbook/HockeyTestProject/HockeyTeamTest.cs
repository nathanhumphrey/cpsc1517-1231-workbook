using FluentAssertions;
using Hockey.Data;
using System.Collections;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Hockey.Test
{
    public class HockeyTeamTest
    {
        // Constants for test HockeyTeam
        const string City = "Fake City";
        const string TeamName = "Fakers";

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

        public HockeyPlayer CreateTestHockeyPlayer()
        {
            return new HockeyPlayer(FirstName, LastName, BirthPlace, DateOfBirth, HeightInInches, WeightInPounds, JerseyNumber, PlayerPosition, PlayerShot);
        }

        /// <summary>
        /// Generates dummy hockey player data for a hockey team
        /// </summary>
        /// <param name="numOfPlayers">number of total players to add to the team</param>
        /// <param name="numOfGoalies">number of goalies to include in the total, defaults to zero</param>
        /// <returns>A HockeyTeam instance</returns>
        private static HockeyTeam CreateTestHockeyTeam(int numOfPlayers, int numOfGoalies = 0)
        {
            string firstName = "FristName";
            string lastName = "LastName";
            string birthPlace = "BirthPlace";
            DateOnly dateOfBirth = new DateOnly(2000, 01, 01);
            int jerseyNumber = 0;
            int weight = 0;
            int height = 0;
            Shot shot = Shot.Left;

            int number = 0;

            HockeyTeam team = new HockeyTeam(City, TeamName);

            // Generate test players
            for (number = 1; number <= numOfPlayers - numOfGoalies; number += 1)
            {
                Position position;

                if (number < 5)
                {
                    position = Position.LeftWing;
                }
                else if (number < 9)
                {
                    position = Position.RightWing;
                }
                else if (number < 13)
                {
                    position = Position.Center;
                }
                else
                {
                    position = Position.Defense;
                }

                team.AddPlayer(new HockeyPlayer($"{firstName}{number}", $"{lastName}{number}", $"{birthPlace}{number}", 
                    dateOfBirth.AddDays(1), weight + number, height + number, jerseyNumber + number, position, shot));
            }

            // Generate test goalies, if any
            for (; number <= numOfPlayers; number += 1)
            {
                team.AddPlayer(new HockeyPlayer($"{firstName}{number}", $"{lastName}{number}", $"{birthPlace}{number}",
                    dateOfBirth.AddDays(1), weight + number, height + number, jerseyNumber + number, Position.Goalie, shot));
            }

            return team;
        }

        [Fact]
        public void HockeyTeam_Constructor_ReturnsHockeyTeam()
        {
            HockeyTeam actual;

            actual = new HockeyTeam(City, TeamName);

            actual.Should().BeOfType(typeof(HockeyTeam));
        }

        [Theory]
        [InlineData("", TeamName)]
        [InlineData(" ", TeamName)]
        [InlineData(null, TeamName)]
        [InlineData(City, "")]
        [InlineData(City, " ")]
        [InlineData(City, null)]
        public void HockeyTeam_Constructor_ThrowsForEmptyCityOrName(string city, string name)
        {
            HockeyTeam team;

            Action act = () => team = new HockeyTeam(city, name);

            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void HockeyTeam_AddPlayer_Success()
        {
            HockeyTeam team = CreateTestHockeyTeam(0);
            HockeyPlayer player = CreateTestHockeyPlayer();
            HockeyPlayer actual;

            team.AddPlayer(player);
            actual = team.Players.First();

            actual.Should().Be(player);
        }

        [Fact]
        public void HockeyTeam_AddPlayer_ThrowsForNullArgument()
        {
            HockeyTeam team = CreateTestHockeyTeam(0);

            Action act = () => team.AddPlayer(null);
            
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void HockeyTeam_RemovePlayer_Success()
        {
            HockeyTeam team = CreateTestHockeyTeam(1);
            HockeyPlayer player = team.Players.First();
            int actual;

            team.RemovePlayer(player);
            actual = team.Players.Count;

            actual.Should().Be(0);
        }

        [Fact]
        public void HockeyTeam_RemovePlayer_ThrowsForPlayerNotOnTeam()
        {
            HockeyTeam team = CreateTestHockeyTeam(1);
            HockeyPlayer player = CreateTestHockeyPlayer();
            Action act;

            act = () => team.RemovePlayer(player);
            
            act.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void HockeyTeam_RemovePlayer_ThrowsForNullArgument()
        {
            HockeyTeam team = CreateTestHockeyTeam(1);
            Action act;

            act = () => team.RemovePlayer(null);

            act.Should().Throw<ArgumentNullException>();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void HockeyTeam_TotalPlayers_ReturnsCorrectCount(int numOfPlayers)
        {
            HockeyTeam team = CreateTestHockeyTeam(numOfPlayers);
            int actual;

            actual = team.TotalPlayers;

            actual.Should().Be(numOfPlayers);
        }

        [Theory]
        [InlineData(19, 1, false)] // players low, goalie low
        [InlineData(19, 2, false)] // players low, goalie ok
        [InlineData(20, 1, false)] // players ok, goalie low
        [InlineData(20, 2, true)] // players ok, goalie ok
        [InlineData(20, 3, true)] // players ok, goalie ok
        [InlineData(23, 3, true)] // players ok, goalie ok
        [InlineData(20, 4, false)] // players ok, goalie high
        [InlineData(24, 3, false)] // players high, goalie ok
        [InlineData(24, 4, false)] // players high, goalie high
        public void HockeyTeam_IsValidRoster_ReturnsCorrectValue(int numOfPlayers, int numOfGoalies, bool expected)
        {
            HockeyTeam team = CreateTestHockeyTeam(numOfPlayers, numOfGoalies);
            bool actual;

            actual = team.IsValidRoster;

            actual.Should().Be(expected);
        }
    }
}