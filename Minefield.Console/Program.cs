using Minefield.Console.Extensions;
using Minefield.Game;
using Minefield.Game.Managers;

Console.WriteLine("1) Use instructions from the assignment.");
Console.WriteLine("2) Play like a game an use arrow keys.");
Console.Write("Choose how you want to play (1 or 2): ");

var option = Console.Read();

Console.Clear();

var gameEngine = new GameEngine();
var game = gameEngine.InitializeMinefieldGame();

while (game.IsActive)
{
    var dir = ConsoleKey.None;
    if (option == '1')
    {
        Console.WriteLine(game.GetState());

        Console.WriteLine("Where do you want to go? ");
        dir = Console.ReadLine()!.ToConsoleKey();
    }
    else
    {
        Console.WriteLine(game);
        dir = Console.ReadKey().Key;
    }

    Console.Clear();

    switch (dir)
    {
        case ConsoleKey.UpArrow:
            gameEngine.Move(game, Constants.Moves.Up);
            break;
        case ConsoleKey.DownArrow:
            gameEngine.Move(game, Constants.Moves.Down);
            break;
        case ConsoleKey.LeftArrow:
            gameEngine.Move(game, Constants.Moves.Left);
            break;
        case ConsoleKey.RightArrow:
            gameEngine.Move(game, Constants.Moves.Right);
            break;
        default:
            break;
    }
}

Console.WriteLine(game.GetResultMessage());