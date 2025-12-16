using ConsoleChessGame.Chessboard;

namespace ConsoleChessGame.ChessLayer;

public class King : Piece
{
    public King(Color color, Board board) : base(color, board)
    {
    }

    public override string ToString()
    {
        return ChessSet[0];
    }
}