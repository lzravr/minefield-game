using Minefield.Game;
using Minefield.Game.Exceptions;
using Minefield.Game.Models;

namespace Minefield.Tests.Unit;

public class GameTests
{
    [Fact]
    public void CanDetectMine()
    {
        var game = new MinefieldGame(3, 3, 8, 3);
        game.InitializeGame();

        Assert.Throws<YouExploadedException>(() => game.Move(Constants.Moves.Down));
    }

    [Fact]
    public void CanDie()
    {
        var game = new Game.Models.MinefieldGame(3, 3, 8, 0);
        game.InitializeGame();

        Assert.Throws<YouExploadedException>(() => game.Move(Constants.Moves.Down));
        Assert.Equal(-1, game.Lives);
    }

    [Fact]
    public void CantLeaveTheField()
    {
        var game = new Game.Models.MinefieldGame(3, 3, 8, 3);
        game.InitializeGame();

        Assert.Throws<IndexOutOfRangeException>(() => game.Move(Constants.Moves.Up));
    }

    [Fact]
    public void CanWin()
    {
        var game = new Game.Models.MinefieldGame(2, 2, 0, 3);
        game.InitializeGame();
        game.Move(Constants.Moves.Down);

        Assert.False(game.IsActive);
        Assert.Equal(3, game.Lives);
    }

    [Fact]
    // check if path through the minefield exists
    // we could use a backtracking algorithm
    // or find any spanning tree
    public void DoesPathExist()
    {
        Assert.True(true);
    }
}