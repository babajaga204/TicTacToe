
namespace TicTacToe;

public class Board
{
    public Cell[] Cells { get; }
    private readonly Random _random = new Random();
    public Board()
    {
        Cells = new Cell[9];
        for (var i = 0; i < Cells.Length; i++)
        {
            Cells[i] = new Cell();
        }
    }

    public bool Mark(string position)
    {
        var colChar = position[0];
        var rowChar = position[1];

        int colIndex = colChar - 'a';
        int rowIndex = rowChar - '1';

        var index = rowIndex * 3 + colIndex;

        if (!Cells[index].CheckEmpty())
        {
            // Console.WriteLine("Velg en tom rute!");
            return false;
        }
        Cells[index].SetValue(true);
        return true;
    }

    public void MarkRandom(bool player)
    
    {
        var availableIndexes = FindEmptyCells();
        var random = _random.Next(0, availableIndexes.Count);
        int index = availableIndexes[random];
        Cells[index].SetValue(player);
    }

    private List<int> FindEmptyCells()
    {
        var availableIndexes = new List<int>();
        for (var i = 0; i < Cells.Length; i++)
        {
            if (Cells[i].CheckEmpty()) availableIndexes.Add(i);
        }
        return availableIndexes;
    }

    // Cells [1,1,1,0,0,0,0,0]
    public bool CheckWin(int player)
    {
        if (CheckRowsWin(player)) return true;
        if (CheckDiagonalWin(player)) return true;
        if (CheckColsWin(player)) return true;
        return false;
    }

    private bool CheckRowsWin(int player)
    {
        if (Cells[0].IsTaken == player && Cells[1].IsTaken == player && Cells[2].IsTaken == player) return true;
        if (Cells[3].IsTaken == player && Cells[4].IsTaken == player && Cells[5].IsTaken == player) return true;
        if (Cells[6].IsTaken == player && Cells[7].IsTaken == player && Cells[8].IsTaken == player) return true;
        return false;
    }
    private bool CheckColsWin(int player)
    {
        if (Cells[0].IsTaken == player && Cells[3].IsTaken == player && Cells[6].IsTaken == player) return true;
        if (Cells[1].IsTaken == player && Cells[4].IsTaken == player && Cells[7].IsTaken == player) return true;
        if (Cells[2].IsTaken == player && Cells[5].IsTaken == player && Cells[8].IsTaken == player) return true;
        return false;
    }
    
    private bool CheckDiagonalWin(int player)
    {
        if (Cells[0].IsTaken == player && Cells[4].IsTaken == player && Cells[8].IsTaken == player) return true;
        if (Cells[2].IsTaken == player && Cells[4].IsTaken == player && Cells[6].IsTaken == player) return true;
        return false;
    }
    
    public bool CheckRestart(string? restart)
    {
        if (restart == "y")
        {
            RestartGame();
            return true;
        }

        if (restart == "n")
        {
            Console.Clear();
        }

        return false;
    }

    public  void RestartGame()
    {
        foreach (var cell in Cells)
        {
            cell.ClearValue();
        }
    }
}
