using ConsoleChessGame;
using ConsoleChessGame.Chessboard;
using ConsoleChessGame.ChessLayer;
Console.OutputEncoding = System.Text.Encoding.Unicode;

try
{
    Match chessMatch = new Match();

    while (!chessMatch.IsEnded)
    {
        Console.Clear();
        Screen.PrintBoard(chessMatch.Board);

        Console.WriteLine();
        Console.Write("Origem: ");
        Position origin = Screen.ReadPosition().ToPosition();
        Console.Write("Destino: ");
        Position destination = Screen.ReadPosition().ToPosition();
        
        chessMatch.ExecuteMove(origin, destination);
    }
}
catch (ChessboardException e)
{
    Console.WriteLine(e.Message);
}

Console.ReadLine();
