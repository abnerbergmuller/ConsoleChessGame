namespace ConsoleChessGame.Board;

public class Position
{
    public int Line { get; set; }
    public int Column { get; set; }

    public Position(int line, int column)
    {
        Line = line;
        Column = column;
    }

    public Position()
    {
    }

    public override string ToString()
    {
        return Line
            + ", "
            + Column;
    }
}