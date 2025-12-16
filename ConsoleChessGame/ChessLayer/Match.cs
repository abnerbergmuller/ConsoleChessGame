using ConsoleChessGame.Chessboard;

namespace ConsoleChessGame.ChessLayer;

public class Match
{
    public Board Board { get; private set; }
    private int _turn;
    private Color _currentPlayer;
    public bool IsEnded { get; private set; }

    public Match()
    {
        Board = new Board(8,8);
        _turn = 1;
        _currentPlayer = Color.White;
        IsEnded = false;
        InsertPieces();
    }

    public void ExecuteMove(Position origin, Position destination)
    {
        Piece piece = Board.RemovePiece(origin);
        piece.AddMovesAmount();
        Piece capturedPiece = Board.RemovePiece(destination);
        Board.InsertPiece(piece, destination);
    }

    private void InsertPieces()
    {
        Board.InsertPiece(new Rook(Color.White, Board), new ChessPosition('c', 1).ToPosition());
        Board.InsertPiece(new Rook(Color.White, Board), new ChessPosition('c', 2).ToPosition());
        Board.InsertPiece(new Rook(Color.White, Board), new ChessPosition('d', 2).ToPosition());
        Board.InsertPiece(new Rook(Color.White, Board), new ChessPosition('e', 2).ToPosition());
        Board.InsertPiece(new Rook(Color.White, Board), new ChessPosition('e', 1).ToPosition());
        Board.InsertPiece(new King(Color.White, Board), new ChessPosition('d', 1).ToPosition());

        
        Board.InsertPiece(new Rook(Color.Black, Board), new ChessPosition('c', 7).ToPosition());
        Board.InsertPiece(new Rook(Color.Black, Board), new ChessPosition('c', 8).ToPosition());
        Board.InsertPiece(new Rook(Color.Black, Board), new ChessPosition('d', 7).ToPosition());
        Board.InsertPiece(new Rook(Color.Black, Board), new ChessPosition('e', 7).ToPosition());
        Board.InsertPiece(new Rook(Color.Black, Board), new ChessPosition('e', 8).ToPosition());
        Board.InsertPiece(new King(Color.Black, Board), new ChessPosition('d', 8).ToPosition());
    }
}