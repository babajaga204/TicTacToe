

using TicTacToe;

var board = new Board();
var console = new GameConsole(board);

while (true)
{
    console.Show();
    Console.Write("Skriv inn hvor du vil sette kryss (f.eks. \"a2\"): ");
    var position = Console.ReadLine()!.ToLower();
    board.Mark(position);
    
    Thread.Sleep(2000);
    board.MarkRandom(false);
}