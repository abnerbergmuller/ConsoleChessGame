using ConsoleChessGame.Chessboard;

namespace ConsoleChessGame.ChessLayer;

public class Match
{
    public Board Board { get; private set; }
    public int _turn { get; private set; }
    public Color _currentPlayer { get; private set; }
    public bool IsEnded { get; private set; }
    private HashSet<Piece> _pieces;
    private HashSet<Piece> _capturedPieces;

    public Match()
    {
        Board = new Board(8,8);
        _turn = 1;
        _currentPlayer = Color.White;
        IsEnded = false;
        _pieces = new HashSet<Piece>();
        _capturedPieces = new HashSet<Piece>();
        InsertPieces();
    }

    public void ExecuteMove(Position origin, Position destination)
    {
        Piece piece = Board.RemovePiece(origin);
        piece.AddMovesAmount();
        Piece capturedPiece = Board.RemovePiece(destination);
        Board.InsertPiece(piece, destination);
        if (capturedPiece != null)
        {
            _capturedPieces.Add(capturedPiece);
        }
        
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

    public HashSet<Piece> CapturedPieces(Color color)
    {
        HashSet<Piece> aux = new HashSet<Piece>();
        foreach (Piece x in _capturedPieces)
        {
            if (x.Color == color)
            {
                aux.Add(x);
            }
        }

        return aux;
    }

    public HashSet<Piece> PiecesInGame(Color color)
    {
        HashSet<Piece> aux = new HashSet<Piece>();
        foreach (Piece x in _pieces)
        {
            if (x.Color == color)
            {
                aux.Add(x);
            }
        }
        aux.ExceptWith(CapturedPieces(color));
        return aux;
    }
    
    public void InsertNewPiece(char column, int line, Piece piece)
    {
        Board.InsertPiece(piece, new ChessPosition(column, line).ToPosition());
        _pieces.Add(piece);
    }
    
    private void InsertPieces()
    {
        InsertNewPiece('c', 1, new Rook(Color.White, Board));
        InsertNewPiece('c', 2, new Rook(Color.White, Board));
        InsertNewPiece('d', 2, new Rook(Color.White, Board));
        InsertNewPiece('e', 2, new Rook(Color.White, Board));
        InsertNewPiece('e', 1, new Rook(Color.White, Board));
        InsertNewPiece('d', 1, new King(Color.White, Board));
        
        InsertNewPiece('c', 7, new Rook(Color.Black, Board));
        InsertNewPiece('c', 8, new Rook(Color.Black, Board));
        InsertNewPiece('d', 7, new Rook(Color.Black, Board));        
        InsertNewPiece('e', 7, new Rook(Color.Black, Board));
        InsertNewPiece('e', 8, new Rook(Color.Black, Board));
        InsertNewPiece('d', 8, new King(Color.Black, Board));
    }
}