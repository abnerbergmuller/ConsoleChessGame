namespace ConsoleChessGame.Chessboard;

public abstract class Piece
{
    public Position Position { get; set; }
    public Color Color { get; protected set; }
    public int MovementsAmount { get; protected set; }
    public Board Board { get; protected set; }
    public List<string> ChessSet { get; set; }

    public Piece(Color color, Board board)
    {
        Position = null;
        Color = color;
        MovementsAmount = 0;
        Board = board;
        ChessSet = ChessSet;
    }

    public void AddMovesAmount()
    {
        MovementsAmount++;
    }

    public bool ExistPossibleMoves()
    {
        bool[,] matrix = PossibleMoves();
        for (int i = 0; i < Board.Lines; i++)
        {
            for (int j = 0; j < Board.Columns; j++)
            {
                if (matrix[i, j])
                {
                    return true;
                }
            }
        }

        return false;
    }

    public bool CanMoveTo(Position position)
    {
        return PossibleMoves()[position.Line, position.Column];
    }

public abstract bool[,] PossibleMoves();
}