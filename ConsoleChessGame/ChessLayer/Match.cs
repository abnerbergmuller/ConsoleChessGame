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
    public bool Check { get; private set; }
    public Piece EnPassant { get; private set; }

    public Match()
    {
        Board = new Board(8, 8);
        _turn = 1;
        _currentPlayer = Color.White;
        IsEnded = false;
        Check = false;
        EnPassant = null;
        _pieces = new HashSet<Piece>();
        _capturedPieces = new HashSet<Piece>();
        InsertPieces();
    }

    public Piece ExecuteMove(Position origin, Position destination)
    {
        Piece piece = Board.RemovePiece(origin);
        piece.AddMovesAmount();
        Piece capturedPiece = Board.RemovePiece(destination);
        Board.InsertPiece(piece, destination);
        if (capturedPiece != null)
        {
            _capturedPieces.Add(capturedPiece);
        }

        //ROQUE PEQUENO
        if (piece is King && destination.Column == origin.Column + 2)
        {
            Position rookOrigin = new Position(origin.Line, origin.Column + 3);
            Position rookDestination = new Position(origin.Line, origin.Column + 1);
            Piece rook = Board.RemovePiece(rookOrigin);
            rook.AddMovesAmount();
            Board.InsertPiece(rook, rookDestination);
        }

        //ROQUE GRANDE
        if (piece is King && destination.Column == origin.Column - 2)
        {
            Position rookOrigin = new Position(origin.Line, origin.Column - 4);
            Position rookDestination = new Position(origin.Line, origin.Column - 1);
            Piece rook = Board.RemovePiece(rookOrigin);
            rook.AddMovesAmount();
            Board.InsertPiece(rook, rookDestination);
        }

        //EN PASSANT
        if (piece is Pawn)
        {
            if (origin.Column != destination.Column && capturedPiece == null)
            {
                Position pawnPosition;
                if (piece.Color == Color.White)
                {
                    pawnPosition = new Position(destination.Line + 1, destination.Column);
                }
                else
                {
                    pawnPosition = new Position(destination.Line - 1, destination.Column);
                }

                capturedPiece = Board.RemovePiece(pawnPosition);
                _capturedPieces.Add(capturedPiece);
            }
        }

        return capturedPiece;
    }

    public void UndoMove(Position origin, Position destination, Piece capturedPiece)
    {
        Piece piece = Board.RemovePiece(destination);
        piece.DecreaseMovesAmount();
        if (capturedPiece != null)
        {
            Board.InsertPiece(capturedPiece, destination);
            _capturedPieces.Remove(capturedPiece);
        }

        Board.InsertPiece(piece, origin);

        //ROQUE PEQUENO
        if (piece is King && destination.Column == origin.Column + 2)
        {
            Position rookOrigin = new Position(origin.Line, origin.Column + 3);
            Position rookDestination = new Position(origin.Line, origin.Column + 1);
            Piece rook = Board.RemovePiece(rookDestination);
            rook.DecreaseMovesAmount();
            Board.InsertPiece(rook, rookOrigin);
        }

        //ROQUE GRANDE
        if (piece is King && destination.Column == origin.Column - 2)
        {
            Position rookOrigin = new Position(origin.Line, origin.Column - 4);
            Position rookDestination = new Position(origin.Line, origin.Column - 1);
            Piece rook = Board.RemovePiece(rookDestination);
            rook.DecreaseMovesAmount();
            Board.InsertPiece(rook, rookOrigin);
        }

        //EN PASSANT
        if (piece is Pawn)
        {
            if (origin.Column != destination.Column && capturedPiece == EnPassant)
            {
                Piece pawn = Board.RemovePiece(destination);
                Position pawnPosition;
                if (piece.Color == Color.White)
                {
                    pawnPosition = new Position(3, destination.Column);
                }
                else
                {
                    pawnPosition = new Position(4, destination.Column);
                }
                Board.InsertPiece(pawn, pawnPosition);
            }
        }
    }

    public void MakePlay(Position origin, Position destination)
    {
        Piece capturedPiece = ExecuteMove(origin, destination);

        if (IsInCheck(_currentPlayer))
        {
            UndoMove(origin, destination, capturedPiece);
            throw new ChessboardException("Você não pode se colocar em xeque!");
        }

        if (IsInCheck(Opponent(_currentPlayer)))
        {
            Check = true;
        }
        else
        {
            Check = false;
        }

        if (TestCheckmate(Opponent(_currentPlayer)))
        {
            IsEnded = true;
        }
        else
        {
            _turn++;
            ChangePlayer();
        }

        Piece piece = Board.Piece(destination);

        //EN PASSANT
        if (piece is Pawn && (destination.Line == origin.Line - 2 || destination.Line == origin.Line + 2))
        {
            EnPassant = piece;
        }
        else
        {
            EnPassant = null;
        }
    }

    public void ValidateOrigin(Position position)
    {
        Board.ValidatePosition(position);

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
        Board.ValidatePosition(destination);

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

    private Color Opponent(Color color)
    {
        if (color == Color.White)
        {
            return Color.Black;
        }
        else
        {
            return Color.White;
        }
    }

    private Piece King(Color color)
    {
        foreach (Piece x in PiecesInGame(color))
        {
            if (x is King)
            {
                return x;
            }
        }

        return null;
    }

    public bool IsInCheck(Color color)
    {
        Piece king = King(color);
        if (king == null)
        {
            throw new ChessboardException("Não há nenhum rei da cor " + color + " no tabuleiro!");
        }

        foreach (Piece x in PiecesInGame(Opponent(color)))
        {
            bool[,] mat = x.PossibleMoves();
            if (mat[king.Position.Line, king.Position.Column])
            {
                return true;
            }
        }

        return false;
    }

    public bool TestCheckmate(Color color)
    {
        if (!IsInCheck(color))
        {
            return false;
        }

        foreach (Piece x in PiecesInGame(color))
        {
            bool[,] mat = x.PossibleMoves();
            for (int i = 0; i < Board.Lines; i++)
            {
                for (int j = 0; j < Board.Columns; j++)
                {
                    if (mat[i, j])
                    {
                        Position origin = x.Position;
                        Position destination = new Position(i, j);
                        Piece capturedPiece = ExecuteMove(origin, destination);
                        bool testCheck = IsInCheck(color);
                        UndoMove(origin, destination, capturedPiece);
                        if (!testCheck)
                        {
                            return false;
                        }
                    }
                }
            }
        }

        return true;
    }

    public void InsertNewPiece(char column, int line, Piece piece)
    {
        Board.InsertPiece(piece, new ChessPosition(column, line).ToPosition());
        _pieces.Add(piece);
    }

    private void InsertPieces()
    {
        InsertNewPiece('a', 1, new Rook(Color.White, Board));
        InsertNewPiece('b', 1, new Knight(Color.White, Board));
        InsertNewPiece('c', 1, new Bishop(Color.White, Board));
        InsertNewPiece('d', 1, new Queen(Color.White, Board));
        InsertNewPiece('e', 1, new King(Color.White, Board, this));
        InsertNewPiece('f', 1, new Bishop(Color.White, Board));
        InsertNewPiece('g', 1, new Knight(Color.White, Board));
        InsertNewPiece('h', 1, new Rook(Color.White, Board));
        InsertNewPiece('a', 2, new Pawn(Color.White, Board, this));
        InsertNewPiece('b', 2, new Pawn(Color.White, Board, this));
        InsertNewPiece('c', 2, new Pawn(Color.White, Board, this));
        InsertNewPiece('d', 2, new Pawn(Color.White, Board, this));
        InsertNewPiece('e', 2, new Pawn(Color.White, Board, this));
        InsertNewPiece('f', 2, new Pawn(Color.White, Board, this));
        InsertNewPiece('g', 2, new Pawn(Color.White, Board, this));
        InsertNewPiece('h', 2, new Pawn(Color.White, Board, this));

        InsertNewPiece('a', 8, new Rook(Color.Black, Board));
        InsertNewPiece('b', 8, new Knight(Color.Black, Board));
        InsertNewPiece('c', 8, new Bishop(Color.Black, Board));
        InsertNewPiece('d', 8, new Queen(Color.Black, Board));
        InsertNewPiece('e', 8, new King(Color.Black, Board, this));
        InsertNewPiece('f', 8, new Bishop(Color.Black, Board));
        InsertNewPiece('g', 8, new Knight(Color.Black, Board));
        InsertNewPiece('h', 8, new Rook(Color.Black, Board));
        InsertNewPiece('a', 7, new Pawn(Color.Black, Board, this));
        InsertNewPiece('b', 7, new Pawn(Color.Black, Board, this));
        InsertNewPiece('c', 7, new Pawn(Color.Black, Board, this));
        InsertNewPiece('d', 7, new Pawn(Color.Black, Board, this));
        InsertNewPiece('e', 7, new Pawn(Color.Black, Board, this));
        InsertNewPiece('f', 7, new Pawn(Color.Black, Board, this));
        InsertNewPiece('g', 7, new Pawn(Color.Black, Board, this));
        InsertNewPiece('h', 7, new Pawn(Color.Black, Board, this));
    }
}