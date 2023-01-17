
namespace TicTacToe;

public class Board
{
    public Cell[] Cells;
    private readonly Random _random = new Random();
    public Board()
    {
        Cells = new Cell[9];
        for (var i = 0; i < Cells.Length; i++)
        {
            Cells[i] = new Cell();
        }
    }

    public void Mark(string position)
    {
        var colChar = position[0];
        var rowChar = position[1];

        int colIndex = colChar - 'a';
        int rowIndex = rowChar - '1';

        var index = rowIndex * 3 + colIndex;
        
        Cells[index].SetValue(true);
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
}
