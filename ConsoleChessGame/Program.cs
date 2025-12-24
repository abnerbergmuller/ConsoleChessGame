using ConsoleChessGame;
using ConsoleChessGame.Chessboard;
using ConsoleChessGame.ChessLayer;

Console.OutputEncoding = System.Text.Encoding.Unicode;

try
{
    Match chessMatch = new Match();

    while (!chessMatch.IsEnded)
    {
        try
        {
            Console.Clear();
            Screen.PrintMatch(chessMatch);

            Console.WriteLine();
            Console.Write("Origem: ");
            Position origin = Screen.ReadPosition().ToPosition();
            chessMatch.ValidateOrigin(origin);

            bool[,] possiblePositions = chessMatch.Board.Piece(origin).PossibleMoves();

            Console.Clear();
            Screen.PrintBoard(chessMatch.Board, possiblePositions);

            Console.WriteLine();
            Console.Write("Destino: ");
            Position destination = Screen.ReadPosition().ToPosition();
            chessMatch.ValidateDestination(origin, destination);

            chessMatch.MakePlay(origin, destination);
        }
        catch (ChessboardException e)
        {
            Console.WriteLine(e.Message);
            Console.ReadLine();
        } 
    }
    
    Console.Clear();
    Screen.PrintMatch(chessMatch);
}
catch (ChessboardException e)
{
    Console.WriteLine(e.Message);
}

Console.ReadLine();