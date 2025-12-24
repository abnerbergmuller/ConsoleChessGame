using ConsoleChessGame.Chessboard;

namespace ConsoleChessGame.ChessLayer;

public class King : Piece
{
    private Match _match;
    
    public King(Color color, Board board, Match match) : base(color, board)
    {
        _match = match;
    }
    

    public override string ToString()
    {
        return ChessSet[0];
    }

    private bool CanMove(Position position)
    {
        Piece piece = Board.Piece(position);
        return piece == null || piece.Color != Color;
    }

    //TESTA TORRE PARA ROQUE
    private bool RookForCastling(Position position)
    {
        if (!Board.ValidPosition(position))
        {
            return false;
        }
        Piece piece = Board.Piece(position);
        return piece != null && piece is Rook && piece.Color == Color && piece.MovementsAmount == 0;
    }
    
    public override bool[,] PossibleMoves()
    {
        bool[,] matrix = new bool[Board.Lines, Board.Columns];

        Position position = new Position(0, 0);
        
        //VERIFICANDO ACIMA
        position.SetValues(Position.Line - 1, Position.Column);
        if (Board.ValidPosition(position) && CanMove(position))
        {
            matrix[position.Line, position.Column] = true;
        }
        
        //VERIFICANDO NORDESTE
        position.SetValues(Position.Line - 1, Position.Column + 1);
        if (Board.ValidPosition(position) && CanMove(position))
        {
            matrix[position.Line, position.Column] = true;
        }
        
        //VERIFICANDO DIREITA
        position.SetValues(Position.Line, Position.Column + 1);
        if (Board.ValidPosition(position) && CanMove(position))
        {
            matrix[position.Line, position.Column] = true;
        }
        
        //VERIFICANDO SUDESTE
        position.SetValues(Position.Line + 1, Position.Column + 1);
        if (Board.ValidPosition(position) && CanMove(position))
        {
            matrix[position.Line, position.Column] = true;
        }
        
        //VERIFICANDO ABAIXO
        position.SetValues(Position.Line + 1, Position.Column);
        if (Board.ValidPosition(position) && CanMove(position))
        {
            matrix[position.Line, position.Column] = true;
        }
        
        //VERIFICANDO SUDOESTE
        position.SetValues(Position.Line + 1, Position.Column - 1);
        if (Board.ValidPosition(position) && CanMove(position))
        {
            matrix[position.Line, position.Column] = true;
        }
        
        //VERIFICANDO ESQUERDA
        position.SetValues(Position.Line, Position.Column - 1);
        if (Board.ValidPosition(position) && CanMove(position))
        {
            matrix[position.Line, position.Column] = true;
        }
        
        //VERIFICANDO NOROESTE
        position.SetValues(Position.Line - 1, Position.Column - 1);
        if (Board.ValidPosition(position) && CanMove(position))
        {
            matrix[position.Line, position.Column] = true;
        }

        //VERIFICANDO ROQUE
        if (MovementsAmount == 0 && !_match.Check)
        {
            //ROQUE PEQUENO
            Position positionR1 = new Position(Position.Line, Position.Column + 3);
            if (RookForCastling(positionR1))
            {
                Position position1 = new Position(Position.Line, Position.Column + 1);
                Position position2 = new Position(Position.Line, Position.Column + 2);
                if (Board.Piece(position1) == null && Board.Piece(position2) == null)
                {
                    matrix[Position.Line, Position.Column + 2] = true;
                }
            }
            
            //ROQUE GRANDE
            Position positionR2 = new Position(Position.Line, Position.Column - 4);
            if (RookForCastling(positionR2))
            {
                Position position1 = new Position(Position.Line, Position.Column - 1);
                Position position2 = new Position(Position.Line, Position.Column - 2);
                Position position3 = new Position(Position.Line, Position.Column - 3);
                if (Board.Piece(position1) == null && Board.Piece(position2) == null && Board.Piece(position3) == null)
                {
                    matrix[Position.Line, Position.Column - 2] = true;
                }
            }
        }
        
        return matrix;
    }
}