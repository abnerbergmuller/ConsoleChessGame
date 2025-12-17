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

    private bool CanMove(Position position)
    {
        Piece piece = Board.Piece(position);
        return piece == null || piece.Color != Color;
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

        return matrix;
    }
}