using ConsoleChessGame;
using ConsoleChessGame.Chessboard;
using ConsoleChessGame.ChessLayer;
Console.OutputEncoding = System.Text.Encoding.Unicode;

// try
// {
//     Board board = new Board(8, 8);
//
//     board.InsertPiece(new Rook(Color.Preta, board), new Position(0, 0));
//     board.InsertPiece(new Rook(Color.Preta, board), new Position(1, 5));
//     board.InsertPiece(new King(Color.Preta, board), new Position(3, 3));
//
//     Screen.PrintBoard(board);
// }
// catch (ChessboardException e)
// {
//     Console.WriteLine(e.Message);
// }

ChessPosition position = new ChessPosition('c', 7);

Console.WriteLine(position.ToPosition());
Console.ReadLine();
