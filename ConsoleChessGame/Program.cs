using ConsoleChessGame;
using ConsoleChessGame.Chessboard;
using ConsoleChessGame.ChessLayer;
Console.OutputEncoding = System.Text.Encoding.Unicode; 

Board board = new Board(8, 8);

board.InsertPiece(new Rook(Color.Preta, board), new Position(0, 0));
board.InsertPiece(new Rook(Color.Preta, board), new Position(1, 3));
board.InsertPiece(new King(Color.Preta, board), new Position(2, 4));

Screen.PrintBoard(board);
Console.ReadLine();