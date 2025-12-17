using ConsoleChessGame.Chessboard;
using ConsoleChessGame.ChessLayer;

namespace ConsoleChessGame;

public class Screen
{
    private static readonly Dictionary<Color, List<string>> Colors = new Dictionary<Color, List<string>>
    {
    //PEÇAS DEVEM SER CHAMADAS PELO INDEX:  0  ,  1  ,  2 ,  3  ,  4 ,  5
        { Color.White , new List<string> {"♔", "♕", "♖", "♗", "♘", "♙"} },
        { Color.Black , new List<string> {"♚", "♛", "♜", "♝", "♞", "♟"} }
    };
    
    public static void PrintBoard(Board board)
    {
        for (int i = 0;  i < board.Lines;  i++)
        {
            Console.Write(8 - i + " ");
            for (int j = 0; j < board.Columns; j++)
            {
               PrintPiece(board.Piece(i, j));
            }
            Console.WriteLine();
        }
        Console.WriteLine("  A B C D E F G H");
    }
    
    public static void PrintBoard(Board board, bool[,] possiblePositions)
    {
        ConsoleColor mainBackgroundColor = Console.BackgroundColor;
        ConsoleColor altBackgroundColor = ConsoleColor.DarkGray;
        
        for (int i = 0;  i < board.Lines;  i++)
        {
            Console.Write(8 - i + " ");
            for (int j = 0; j < board.Columns; j++)
            {
                if (possiblePositions[i, j] == true)
                {
                    Console.BackgroundColor = altBackgroundColor;
                }
                else
                {
                    Console.BackgroundColor = mainBackgroundColor;
                }
                PrintPiece(board.Piece(i, j));
                Console.BackgroundColor = mainBackgroundColor;
            }
            Console.WriteLine();
        }
        Console.WriteLine("  A B C D E F G H");
        Console.BackgroundColor = mainBackgroundColor;
    }

    public static ChessPosition ReadPosition()
    {
        string screenInput = Console.ReadLine();
        char column = screenInput[0];
        int line = int.Parse(screenInput[1] + "");
        return new ChessPosition(column, line);
    }
    
    public static void PrintPiece(Piece piece)
    {
        if (piece == null)
        {
            Console.Write("- ");
        }
        else
        { 
            piece.ChessSet = Colors[piece.Color];
            Console.Write(piece);
            Console.Write(" ");
        }
    }
}