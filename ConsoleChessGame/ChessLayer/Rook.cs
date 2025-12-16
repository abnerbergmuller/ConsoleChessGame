using ConsoleChessGame.Chessboard;

namespace ConsoleChessGame.ChessLayer;

public class Rook : Piece
{
    public Rook(Color color, Board board) : base(color, board)
    {
    }

    public override string ToString()
    {
        return ChessSet[2];
    }
}