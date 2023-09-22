﻿namespace Hockey.Data
{
    /// <summary>
    /// Represents a Hockey Team
    /// </summary>
    public class HockeyTeam
    {
        private int MinPlayers = 20;
        private int MaxPlayers = 23;
        private int MinGoalies = 2;
        private int MaxGoalies = 3;

        /// <summary>
        /// Hockey team roster
        /// </summary>
        public List<HockeyPlayer> Players { get; private set; } = new List<HockeyPlayer>();

        /// <summary>
        /// The name of the hockey team
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The hockey team home city
        /// </summary>
        public string City { get; private set; }

        /// <summary>
        /// Total number of players on the roster
        /// </summary>
        public int TotalPlayers => Players.Count;

        /// <summary>
        /// Whether the team has the required number of players. 20-23 are required,
        /// with at least two goalies, but no more than three.
        /// </summary>
        public bool IsValidRoster
        {
            get
            {
                int numOfGoalies = Players.FindAll(
                    delegate (HockeyPlayer player)
                    {
                        return player.Position == Position.Goalie;
                    }
                ).Count;
                
                return TotalPlayers >= MinPlayers && TotalPlayers <= MaxPlayers && numOfGoalies >= MinGoalies && numOfGoalies <= MaxGoalies;
            }
        }

        /// <summary>
        /// Creates a new hockey team
        /// </summary>
        /// <param name="city">Home city for the team</param>
        /// <param name="name">Team name</param>
        /// <exception cref="ArgumentException">Throws if eitehr the city or name are empty</exception>
        public HockeyTeam(string city, string name) { 
            if (string.IsNullOrWhiteSpace(city))
            {
                throw new ArgumentException("City cannot be empty.");
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be empty.");
            }

            City = city;
            Name = name;
        }

        /// <summary>
        /// Adds a hockey player to the roster.
        /// </summary>
        /// <param name="player">The HockeyPlayer to add</param>
        public void AddPlayer(HockeyPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentNullException("Player cannot be null.");
            }

            Players.Add(player);
        }

        /// <summary>
        /// Removes a player from the roster.
        /// </summary>
        /// <param name="player">The HockeyPlayer to remove</param>
        /// <exception cref="InvalidOperationException">If the player is not on the team</exception>
        public void RemovePlayer(HockeyPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentNullException("Player cannot be null.");
            }

            if (!Players.Contains(player))
            {
                throw new InvalidOperationException($"Player {player} is not on the team.");
            }

            Players.Remove(player);
        }
    }
}
