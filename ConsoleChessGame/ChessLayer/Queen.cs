using ConsoleChessGame.Chessboard;

namespace ConsoleChessGame.ChessLayer;

public class Queen : Piece
{
    public Queen(Color color, Board board) : base(color, board)
    {
    }

    public override string ToString()
    {
        return ChessSet[1];
    }
    
    private bool CanMove(Position position)
    {
        Piece piece = Board.Piece(position);
        return piece == null || piece.Color != Color;
    }
    
    public override bool[,] PossibleMoves()
    {
        bool[,] matrix = new bool[Board.Lines, Board.Columns];

        Position position = new Position(0, 0);
        
        //VERIFICANDO ESQUERDA
        position.SetValues(Position.Line, Position.Column - 1);
        while (Board.ValidPosition(position) && CanMove(position))
        {
            matrix[position.Line, position.Column] = true;
            if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
            {
                break;
            }
            position.SetValues(position.Line, position.Column - 1);
        }
        
        //VERIFICANDO DIREITA
        position.SetValues(Position.Line, Position.Column + 1);
        while (Board.ValidPosition(position) && CanMove(position))
        {
            matrix[position.Line, position.Column] = true;
            if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
            {
                break;
            }
            position.SetValues(position.Line, position.Column + 1);
        }
        
        //VERIFICANDO ACIMA  
        position.SetValues(Position.Line - 1, Position.Column);
        while (Board.ValidPosition(position) && CanMove(position))
        {
            matrix[position.Line, position.Column] = true;
            if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
            {
                break;
            }
            position.SetValues(position.Line - 1, position.Column);
        }
        
        //VERIFICANDO ABAIXO  
        position.SetValues(Position.Line + 1, Position.Column);
        while (Board.ValidPosition(position) && CanMove(position))
        {
            matrix[position.Line, position.Column] = true;
            if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
            {
                break;
            }
            position.SetValues(position.Line + 1, position.Column);
        }
        
        //VERIFICANDO NOROESTE  
        position.SetValues(Position.Line - 1, Position.Column - 1);
        while (Board.ValidPosition(position) && CanMove(position))
        {
            matrix[position.Line, position.Column] = true;
            if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
            {
                break;
            }
            position.SetValues(position.Line - 1, position.Column - 1);
        }

        //VERIFICANDO NORDESTE  
        position.SetValues(Position.Line - 1, Position.Column + 1);
        while (Board.ValidPosition(position) && CanMove(position))
        {
            matrix[position.Line, position.Column] = true;
            if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
            {
                break;
            }
            position.SetValues(position.Line - 1, position.Column + 1);
        }
        
        //VERIFICANDO SUDESTE  
        position.SetValues(Position.Line + 1, Position.Column + 1);
        while (Board.ValidPosition(position) && CanMove(position))
        {
            matrix[position.Line, position.Column] = true;
            if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
            {
                break;
            }
            position.SetValues(position.Line + 1, position.Column + 1);
        }
        
        //VERIFICANDO SUDOESTE  
        position.SetValues(Position.Line + 1, Position.Column - 1);
        while (Board.ValidPosition(position) && CanMove(position))
        {
            matrix[position.Line, position.Column] = true;
            if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
            {
                break;
            }
            position.SetValues(position.Line + 1, position.Column - 1);
        }
        
        return matrix;
    }
}