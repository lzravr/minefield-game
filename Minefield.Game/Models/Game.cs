namespace Minefield.Game.Models;
public abstract class Game
{
    public bool IsActive;
    public abstract void InitializeGame();
    public abstract void Move(string move);
    public abstract string GetState();
    public abstract string GetResultMessage();
    public abstract void SetStatus(string status);
}
