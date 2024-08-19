using ChessGameConsoleApp;
using ChessGameConsoleApp.Board;
using ChessGameConsoleApp.Board.Enums;
using ChessGameConsoleApp.Chess;


GameBoard gameBoard = new(8, 8);
gameBoard.PlacePiece(new Tower(Color.White, gameBoard), new Position(0, 0));
gameBoard.PlacePiece(new Tower(Color.White, gameBoard), new Position(1, 3));
gameBoard.PlacePiece(new King(Color.White, gameBoard), new Position(2, 4));

Display.DisplayGameBoard(gameBoard);