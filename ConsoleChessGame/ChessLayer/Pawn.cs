using ConsoleChessGame.Chessboard;

namespace ConsoleChessGame.ChessLayer;

public class Pawn : Piece
{
    private Match _match;

    public Pawn(Color color, Board board, Match match) : base(color, board)
    {
        _match = match;
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

            //EN PASSANT - BRANCAS
            if (Position.Line == 3)
            {
                Position left = new Position(Position.Line, Position.Column - 1);
                if (Board.ValidPosition(left) && HaveOpponent(left) && Board.Piece(left) == _match.EnPassant)
                {
                    matrix[left.Line - 1, left.Column] = true;
                }
                Position right = new Position(Position.Line, Position.Column + 1);
                if (Board.ValidPosition(right) && HaveOpponent(right) && Board.Piece(right) == _match.EnPassant)
                {
                    matrix[right.Line - 1, right.Column] = true;
                }
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
            //EN PASSANT - PRETAS
            if (Position.Line == 4)
            {
                Position left = new Position(Position.Line, Position.Column - 1);
                if (Board.ValidPosition(left) && HaveOpponent(left) && Board.Piece(left) == _match.EnPassant)
                {
                    matrix[left.Line + 1, left.Column] = true;
                }
                Position right = new Position(Position.Line, Position.Column + 1);
                if (Board.ValidPosition(right) && HaveOpponent(right) && Board.Piece(right) == _match.EnPassant)
                {
                    matrix[right.Line + 1, right.Column] = true;
                }
            }
        }


        return matrix;
    }
}