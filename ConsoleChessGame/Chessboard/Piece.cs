namespace ConsoleChessGame.Chessboard;

public class Piece
{
    public Position Position { get; set; }
    public Color Color { get; protected set; }
    public int MovementsAmount { get; protected set; }
    public Board Board { get; protected set; }

    public Piece(Color color, Board board)
    {
        Position = null;
        Color = color;
        MovementsAmount = 0;
        Board = board;
    }
    
}