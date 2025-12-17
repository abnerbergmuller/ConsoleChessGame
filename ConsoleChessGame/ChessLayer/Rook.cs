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
        while (Board.ValidPosition(position) && CanMove(position))
        {
            matrix[position.Line, position.Column] = true;
            if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
            {
                break;
            }
            position.Line -= 1;
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
            position.Line += 1;
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
            position.Column += 1;
        }
        
        //VERIFICANDO ESQUERDA  
        position.SetValues(Position.Line, Position.Column - 1);
        while (Board.ValidPosition(position) && CanMove(position))
        {
            matrix[position.Line, position.Column] = true;
            if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
            {
                break;
            }
            position.Column -= 1;
        }
        
        return matrix;
    }
}