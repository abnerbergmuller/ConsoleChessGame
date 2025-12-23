using ConsoleChessGame.Chessboard;
using ConsoleChessGame.ChessLayer;

namespace ConsoleChessGame;

public class Screen
{
    private static readonly Dictionary<Color, List<string>> Colors = new Dictionary<Color, List<string>>
    {
        //PEÇAS DEVEM SER CHAMADAS PELO INDEX:  0  ,  1  ,  2 ,  3  ,  4 ,  5
        { Color.White, new List<string> { "♔", "♕", "♖", "♗", "♘", "♙" } },
        { Color.Black, new List<string> { "♚", "♛", "♜", "♝", "♞", "♟" } }
    };

    public static void PrintMatch(Match chessMatch)
    {
        PrintBoard(chessMatch.Board);
        Console.WriteLine();
        PrintCapturedPieces(chessMatch);
        Console.WriteLine();
        Console.WriteLine("Turno: " + chessMatch._turn);
        Console.WriteLine("Aguardando jogada: " + chessMatch.TranslateTeam(chessMatch._currentPlayer));
    }

    public static void PrintCapturedPieces(Match chessMatch)
    {
        Console.WriteLine("Peças capturadas: ");
        Console.Write("Brancas: ");
        PrintSet(chessMatch.CapturedPieces(Color.White));
        Console.WriteLine();
        Console.Write("Pretas: ");
        PrintSet(chessMatch.CapturedPieces(Color.Black));
        Console.WriteLine();
    }

    public static void PrintSet(HashSet<Piece> set)
    {
        Console.Write("[");
        foreach (Piece x in set)
        {
            Console.Write(x + " ");
        }

        Console.Write("]");
    }

    public static void PrintBoard(Board board)
    {
        for (int i = 0; i < board.Lines; i++)
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

        for (int i = 0; i < board.Lines; i++)
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