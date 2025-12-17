namespace ConsoleChessGame.Chessboard;

public abstract class Piece
{
    public Position Position { get; set; }
    public Color Color { get; protected set; }
    public int MovementsAmount { get; protected set; }
    public Board Board { get; protected set; }
    public List<string> ChessSet { get; set; }

    public Piece(Color color, Board board)
    {
        Position = null;
        Color = color;
        MovementsAmount = 0;
        Board = board;
        ChessSet = ChessSet;
    }

    public void AddMovesAmount()
    {
        MovementsAmount++;
    }

    public abstract bool[,] PossibleMoves();
}