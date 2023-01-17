namespace TicTacToe;

public class GameConsole
{
    public Board _board;

    public GameConsole(Board board)
    {
        _board = board;
    }
    public void Show()
    {
        Console.WriteLine($@"  a b c
 ┌─────┐
1│{GetChar(0)} {GetChar(1)} {GetChar(2)}│
2│{GetChar(3)} {GetChar(4)} {GetChar(5)}│
3│{GetChar(6)} {GetChar(7)} {GetChar(8)}│
 └─────┘");
    }

    private char GetChar(int cellIndex)
    {
        var cell = _board.Cells[cellIndex];
        
        return cell.CheckEmpty() ? ' ' : cell.CheckPlayer1() ? 'X' : 'O';
    }
}