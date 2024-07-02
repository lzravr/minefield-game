using Minefield.Game.Exceptions;
using System.Text;

namespace Minefield.Game.Models;

public class MinefieldGame : Game
{
    public int Height { get; init; }
    public int Width { get; init; }
    public int NumberOfMines { get; init; }
    public Cell[,] Board { get; set; }
    public Cell Player { get; set; }
    public int Lives { get; set; }
    public Stack<Cell> Path { get; set; } = new();
    public string? Status = null;

    public MinefieldGame(int height, int width, int numberOfMines, int lives)
    {
        Height = height;
        Width = width;
        Board = new Cell[Width, Height];
        NumberOfMines = numberOfMines;
        Lives = lives;
    }

    public override void InitializeGame()
    {
        InitializeBoard();
        InitializePlayer();
        PlaceMines();

        IsActive = true;
    }

    public override void Move(string move)
    {
        if (move.Equals(Constants.Moves.Up))
        {
            CheckMove(Board[Player.X - 1, Player.Y]);
            Board[Player.X, Player.Y].SetEmpty();
            Player = Board[Player.X - 1, Player.Y];
        }
        else if (move.Equals(Constants.Moves.Down))
        {
            CheckMove(Board[Player.X + 1, Player.Y]);
            Board[Player.X, Player.Y].SetEmpty();
            Player = Board[Player.X + 1, Player.Y];
        }
        else if (move.Equals(Constants.Moves.Left))
        {
            CheckMove(Board[Player.X, Player.Y - 1]);
            Board[Player.X, Player.Y].SetEmpty();
            Player = Board[Player.X, Player.Y - 1];
        }
        else if (move.Equals(Constants.Moves.Right))
        {
            CheckMove(Board[Player.X, Player.Y + 1]);
            Board[Player.X, Player.Y].SetEmpty();
            Player = Board[Player.X, Player.Y + 1];
        }

        Player.SetPlayer();
        Path.Push(Player);

        if (Player.X == Height - 1)
        {
            IsActive = false;
        }
    }

    public override void SetStatus(string status)
    {
        Status = status;
    }

    public override string GetState()
    {
        StringBuilder print = new StringBuilder($"Turn: {Path.Count,3}, Lives: {Lives,3}, Position: {(char)(Player.Y + 65)}{Player.X + 1}\n");

        print.Append(Status);
        Status = null;

        return print.ToString();
    }

    public override string ToString()
    {
        StringBuilder print = new StringBuilder();
        print.AppendLine(string.Format($"Turn: {Path.Count,3}, Lives: {Lives,3}"));
        for (int i = 0; i < Width; i++)
        {
            for (int j = 0; j < Height; j++)
            {
                if (Board[i, j].IsMine)
                {
                    print.Append(string.Format($"{Constants.Cell.Empty,2}"));
                }
                else
                {
                    print.Append(string.Format($"{Board[i, j],2}"));
                }
            }
            print.AppendLine();
        }

        print.AppendLine(Status);

        Status = null;

        return print.ToString();
    }

    public override string GetResultMessage()
    {
        if (Lives < 0)
        {
            return "You died.";
        }

        return $"Congrats! It took you {Path.Count} turns to escape.";
    }

    private void InitializePlayer()
    {
        Player = Board[0, Width / 2];
        Player.SetPlayer();
    }

    private void InitializeBoard()
    {
        for (int i = 0; i < Width; i++)
        {
            for (int j = 0; j < Height; j++)
            {
                Board[i, j] = new Cell(i, j);
            }
        }
    }

    // we need to ensure that the path through the minefield exists
    // we could first create a random path and poulate the rest of the field with mines
    // due to time limitation this was not implemented
    // we assume there is always a path
    private void PlaceMines()
    {
        int minesPlaced = 0;
        Random random = new Random();

        while (minesPlaced < NumberOfMines)
        {
            var x = random.Next(Width);
            var y = random.Next(Height);

            if (Board[x, y].IsEmpty)
            {
                Board[x, y].SetMine();
                minesPlaced++;
            }
        }
    }

    private void CheckMove(Cell cell)
    {
        if (Board[cell.X, cell.Y].IsMine)
        {
            Lives--;
            if (Lives < 0)
            {
                IsActive = false;
            }
            throw new YouExploadedException();
        }
    }

}
