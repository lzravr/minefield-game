using Minefield.Game.Models;

public interface IGameEngine
{
    Game InitializeMinefieldGame();
    void Move(Game game, string move);
}
