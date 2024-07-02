namespace Minefield.Game.Models;
public class Cell
{
    public int X;
    public int Y;

    private string _content = Constants.Cell.Empty;

    public Cell(int x, int y)
    {
        X = x;
        Y = y;
    }

    public bool IsEmpty => _content == Constants.Cell.Empty;
    public bool IsMine => _content == Constants.Cell.Mine;

    public void SetMine()
    {
        _content = Constants.Cell.Mine;
    }

    public void SetEmpty()
    {
        _content = Constants.Cell.Empty;
    }

    public void SetPlayer()
    {
        _content = Constants.Cell.Player;
    }

    public override string ToString()
    {
        return _content;
    }
}
