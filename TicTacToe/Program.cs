
using TicTacToe;

var board = new Board();
var gameConsole = new GameConsole(board);

while (gameConsole.IsGameRunning)
{
    if (board.CheckWin(1) || board.CheckWin(2))
    {
        Console.Clear();
        gameConsole.Show();
        gameConsole.IsGameRunning = false;
        string winner = board.CheckWin(1) ? "Du" : "CPU-en";
        Console.WriteLine($@" {winner} vant!
        Vil du starte på nytt? 
        y - for ja,
        n - for nei");
        var restart = Console.ReadLine()!.ToLower();
        if (board.CheckRestart(restart)) gameConsole.IsGameRunning = true;
        if (restart == "n") break;
    }
    Console.Clear();
    gameConsole.Show();
    Console.Write("Skriv inn hvor du vil sette kryss (f.eks. \"a2\"): ");
    var position = Console.ReadLine()!.ToLower();
    if (board.Mark(position) && !board.CheckWin(1))
    {
        Thread.Sleep(2000);
        board.MarkRandom(false);
    }
}