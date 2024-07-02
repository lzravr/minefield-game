using Minefield.Game;

namespace Minefield.Console.Extensions;
public static class MovesExtension
{
    public static ConsoleKey ToConsoleKey(this string move)
    => move switch
    {
        Constants.Moves.Up => ConsoleKey.UpArrow,
        Constants.Moves.Down => ConsoleKey.DownArrow,
        Constants.Moves.Left => ConsoleKey.LeftArrow,
        Constants.Moves.Right => ConsoleKey.RightArrow,
        _ => ConsoleKey.None
    };
}
