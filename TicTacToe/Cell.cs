namespace TicTacToe;

public class Cell
{
    public int IsTaken;

    public bool CheckEmpty()
    {
        return IsTaken == 0;
    }

    public bool CheckPlayer1()
    {
        return IsTaken == 1;
    }
    
    public void SetValue(bool player)
    {
        if (!CheckEmpty()) return;
        IsTaken = player ? 1 : 2;
    }

    public void ClearValue()
    {
        IsTaken = 0;
    }
}