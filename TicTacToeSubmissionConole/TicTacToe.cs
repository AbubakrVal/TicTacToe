using System;
using System.Collections.Generic;
using System.Text;
using TicTacToeRendererLib.Enums;
using TicTacToeRendererLib.Renderer;


namespace TicTacToeSubmissionConole
{
    public class TicTacToe
    {
        private TicTacToeConsoleRenderer _boardRenderer;
        private Board _gameBoard = new Board();
        private PlayerEnum _currentPlayer = PlayerEnum.X;


        private int GetValidatedInput(string prompt)
        {
            int value;
            bool isValid;
            do
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                isValid = int.TryParse(input, out value) && value >= 0 && value <= 2;
                if (!isValid) Console.WriteLine("Invalid input! Enter 0, 1, or 2.");
            } while (!isValid);
            return value;
        }

        public TicTacToe()
        {
            _boardRenderer = new TicTacToeConsoleRenderer(10, 6);
            _boardRenderer.Render();
        }

        public void Run()
        {
            bool gameOver = false;

            while (!gameOver)
            {
                Console.Clear();
                _boardRenderer.Render();

                int inputStartY = 15;

                Console.SetCursorPosition(2, inputStartY);
                Console.Write($"player {_currentPlayer}'s turn");

                Console.SetCursorPosition(2, inputStartY + 2);
                int row = GetValidatedInput("Enter row (0-2): ");

                Console.SetCursorPosition(2, inputStartY + 4);
                int column = GetValidatedInput("Enter column (0-2): ");

                
                if (_gameBoard.IsCellEmpty(row, column))  
                {
                    
                    _gameBoard.PlaceMove(row, column, _currentPlayer);

                    
                    _boardRenderer.AddMove(row, column, _currentPlayer, true);


                    if (_gameBoard.CheckForWin(_currentPlayer))
                    {
                        Console.WriteLine($"{_currentPlayer} wins!");
                        gameOver = true;
                    }
                    else if (_gameBoard.CheckForTie())
                    {
                        Console.WriteLine("Tie game!");
                        gameOver = true;
                    }
                    else
                    {
                        _currentPlayer = (_currentPlayer == PlayerEnum.X) ? PlayerEnum.O : PlayerEnum.X;
                    }
                }
                else
                {
                    Console.SetCursorPosition(2, inputStartY + 6);
                    Console.WriteLine("Cell already taken! Press any key to retry.");
                    Console.ReadKey();
                }
            }
        }
    }
}
