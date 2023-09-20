using Hockey.Data;
using Utils;

Console.WriteLine("Welcome to the HockeyPlayer Test App");

// Test both default and greedy constructors
// HockeyPlayer player1 = new HockeyPlayer();
HockeyPlayer player2 = new HockeyPlayer("Bobby", "Orr", "Parry Sound, ON", new DateOnly(1948, 3, 20),
    196, 73, 28, Position.Defense, Shot.Right);
// Test object-initializer syntax
//HockeyPlayer player3 = new HockeyPlayer()
//{
//    FirstName = "Nathan",
//    LastName = "Humphrey",
//};

//player1.FirstName = "Test";
//player1.LastName = "Player";
//player1.DateOfBirth = new DateOnly(1979, 10, 12);

// Testing overloaded IsInTheFuture
Console.WriteLine($"Date in future? {Utilities.IsInTheFuture(new DateTime(2023, 9,12))}");

// Everything but the Age can be done day one of week two
// Console.WriteLine($"The player's name is {player1.ToString()}, they are born {player1.DateOfBirth} and are {player1.Age} years old.");
// Call to .ToString() is unnecessary, using the variable in this context will automatically call ToString()
Console.WriteLine($"The player's name is {player2}, they are born {player2.DateOfBirth} and are {player2.Age} years old.");
// Console.WriteLine($"The player's name is {player3}, they are born {player3.DateOfBirth} and are {player3.Age} years old.");
