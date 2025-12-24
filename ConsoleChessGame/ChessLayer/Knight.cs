using ConsoleChessGame.Chessboard;

namespace ConsoleChessGame.ChessLayer;

public class Knight : Piece
{
    public Knight(Color color, Board board) : base(color, board)
    {
    }

    public override string ToString()
    {
        return ChessSet[4];
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
        
        //VERIFICANDO POSIÇÕES
        position.SetValues(Position.Line - 1, Position.Column - 2);
        if (Board.ValidPosition(position) && CanMove(position))
        {
            matrix[position.Line, position.Column] = true;
        }
        
        position.SetValues(Position.Line - 2, Position.Column - 1);
        if (Board.ValidPosition(position) && CanMove(position))
        {
            matrix[position.Line, position.Column] = true;
        }
        
        position.SetValues(Position.Line - 2, Position.Column + 1);
        if (Board.ValidPosition(position) && CanMove(position))
        {
            matrix[position.Line, position.Column] = true;
        }
        
        position.SetValues(Position.Line - 1, Position.Column + 2);
        if (Board.ValidPosition(position) && CanMove(position))
        {
            matrix[position.Line, position.Column] = true;
        }
        
        position.SetValues(Position.Line + 1, Position.Column + 2);
        if (Board.ValidPosition(position) && CanMove(position))
        {
            matrix[position.Line, position.Column] = true;
        }
        
        position.SetValues(Position.Line + 2, Position.Column + 1);
        if (Board.ValidPosition(position) && CanMove(position))
        {
            matrix[position.Line, position.Column] = true;
        }
        
        position.SetValues(Position.Line + 2, Position.Column - 1);
        if (Board.ValidPosition(position) && CanMove(position))
        {
            matrix[position.Line, position.Column] = true;
        }
        
        position.SetValues(Position.Line + 1, Position.Column - 2);
        if (Board.ValidPosition(position) && CanMove(position))
        {
            matrix[position.Line, position.Column] = true;
        }

        return matrix;
    }
}