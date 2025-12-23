using ConsoleChessGame.Chessboard;

namespace ConsoleChessGame.ChessLayer;

public class Match
{
    public Board Board { get; private set; }
    public int _turn { get; private set; }
    public Color _currentPlayer { get; private set; }
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

    public void MakePlay(Position origin, Position destination)
    {
        ExecuteMove(origin, destination);
        _turn++;
        ChangePlayer();
    }
    
    public void ValidateOrigin(Position position)
    {
        if (Board.Piece(position) == null)
        {
            throw new ChessboardException("Não existe peça na posição de origem escolhida!");
        }

        if (_currentPlayer != Board.Piece(position).Color)
        {
            throw new ChessboardException("A peça de origem escolhida não é sua!");
        }

        if (!Board.Piece(position).ExistPossibleMoves())
        {
            throw new ChessboardException("Não há movimentos possíveis para a peça de origem escolhida!");
        }
    }

    public void ValidateDestination(Position origin, Position destination)
    {
        if (!Board.Piece(origin).CanMoveTo(destination))
        {
            throw new ChessboardException("Posição de destino inválida!");
        }
    }

    public string TranslateTeam(Color currentPlayer)
    {
        if (_currentPlayer == Color.Black) return "Preta";
        if (_currentPlayer == Color.White) return "Branca";
        else
        {
            return "Escolha uma cor disponível!";
        }
    }
    
    private void ChangePlayer()
    {
        if (_currentPlayer == Color.White)
        {
            _currentPlayer = Color.Black;
        }
        else
        {
            _currentPlayer = Color.White;
        }
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