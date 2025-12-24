using ConsoleChessGame.Chessboard;

namespace ConsoleChessGame.ChessLayer;

public class Pawn : Piece
{
    public Pawn(Color color, Board board) : base(color, board)
    {
    }

    public override string ToString()
    {
        return ChessSet[5];
    }

    private bool HaveOpponent(Position position)
    {
        Piece piece = Board.Piece(position);
        return piece != null && piece.Color != Color;
    }

    private bool IsFree(Position position)
    {
        return Board.Piece(position) == null;
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

        //VERIFICANDO DIREÇÃO
        if (Color == Color.White)
        {
            position.SetValues(Position.Line - 1, Position.Column);
            if (Board.ValidPosition(position) && IsFree(position))
            {
                matrix[position.Line, position.Column] = true;
            }

            position.SetValues(Position.Line - 2, Position.Column);
            if (Board.ValidPosition(position) && IsFree(position) && MovementsAmount == 0)
            {
                matrix[position.Line, position.Column] = true;
            }

            position.SetValues(Position.Line - 1, Position.Column - 1);
            if (Board.ValidPosition(position) && HaveOpponent(position))
            {
                matrix[position.Line, position.Column] = true;
            }

            position.SetValues(Position.Line - 1, Position.Column + 1);
            if (Board.ValidPosition(position) && HaveOpponent(position))
            {
                matrix[position.Line, position.Column] = true;
            }
        }
        else
        {
            position.SetValues(Position.Line + 1, Position.Column);
            if (Board.ValidPosition(position) && IsFree(position))
            {
                matrix[position.Line, position.Column] = true;
            }

            position.SetValues(Position.Line + 2, Position.Column);
            if (Board.ValidPosition(position) && IsFree(position) && MovementsAmount == 0)
            {
                matrix[position.Line, position.Column] = true;
            }

            position.SetValues(Position.Line + 1, Position.Column - 1);
            if (Board.ValidPosition(position) && HaveOpponent(position))
            {
                matrix[position.Line, position.Column] = true;
            }

            position.SetValues(Position.Line + 1, Position.Column + 1);
            if (Board.ValidPosition(position) && HaveOpponent(position))
            {
                matrix[position.Line, position.Column] = true;
            }
        }


        return matrix;
    }
}