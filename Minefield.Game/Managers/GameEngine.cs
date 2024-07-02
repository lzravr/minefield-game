
using Minefield.Game.Exceptions;
using Minefield.Game.Models;

namespace Minefield.Game.Managers;
public class GameEngine : IGameEngine
{
    public Models.Game InitializeMinefieldGame()
    {
        MinefieldGame game = new MinefieldGame(8, 8, 10, 3);
        game.InitializeGame();

        return game;
    }

    public void Move(Models.Game game, string move)
    {
        try
        {
            game.Move(move);
        }
        catch (YouExploadedException)
        {
            game.SetStatus("BOOOOOM");
        }
        catch (Exception)
        {
            game.SetStatus("You got eaten by a crocodile.");
        }
    }
}
