namespace Hockey.Data
{
    /// <summary>
    /// Represents a Hockey Team
    /// </summary>
    public class HockeyTeam
    {
        private static int MinPlayers = 20;
        private static int MaxPlayers = 23;
        private static int MaxGoalies = 3;

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
                
                return TotalPlayers >= MinPlayers && TotalPlayers <= MaxPlayers && numOfGoalies >= 2 && numOfGoalies <= 3;
            }
        }

        /// <summary>
        /// Creates a default instance of a HockeyTeam
        /// </summary>
        public HockeyTeam() { }

        /// <summary>
        /// Adds a hockey player to the roster.
        /// </summary>
        /// <param name="player">The HockeyPlayer to add</param>
        /// <exception cref="InvalidOperationException">If the maximum number of players has already been reached</exception>
        public void AddPlayer(HockeyPlayer player)
        {
            if (TotalPlayers == MaxPlayers)
            {
                throw new InvalidOperationException($"Cannot exceed {MaxPlayers} on a team.");
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
            if (!Players.Contains(player))
            {
                throw new InvalidOperationException($"Player {player} is not on the team.");
            }

            Players.Remove(player);
        }
    }
}
