﻿using ChessGameConsoleApp;
using ChessGameConsoleApp.Board;
using ChessGameConsoleApp.Board.Enums;
using ChessGameConsoleApp.Board.Exceptions;
using ChessGameConsoleApp.Chess;

ChessPosition chessPosition = new('f', 2);
Console.WriteLine(chessPosition);

Console.WriteLine(chessPosition.ToPosition());

//try
//{
//    //GameBoard gameBoard = new(8, 8);
//    //gameBoard.PlacePiece(new Tower(Color.White, gameBoard), new Position(0, 0));
//    //gameBoard.PlacePiece(new Tower(Color.White, gameBoard), new Position(1, 5));
//    //gameBoard.PlacePiece(new King(Color.White, gameBoard), new Position(0, 2));

//    //Display.DisplayGameBoard(gameBoard);
//}
//catch (GameBoardException e)
//{
//    Console.WriteLine(e.Message);
//}
