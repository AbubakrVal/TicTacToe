using System;
using TicTacToeRendererLib.Enums;

namespace TicTacToeSubmissionConole
{
    public class Board
    {
        
        private PlayerEnum?[,] _cells = new PlayerEnum?[3, 3];

        
        public bool IsCellEmpty(int row, int col) => _cells[row, col] == null;

        
        public void PlaceMove(int row, int col, PlayerEnum player)
        {
            if (IsCellEmpty(row, col))
                _cells[row, col] = player;
            else
                throw new InvalidOperationException("Cell is already occupied.");
        }

        public bool CheckForWin(PlayerEnum player)
        {
           
            for (int rowIdx = 0; rowIdx < 3; rowIdx++)
            {
                if (_cells[rowIdx, 0] == player && 
                    _cells[rowIdx, 1] == player && 
                    _cells[rowIdx, 2] == player)
                    return true;
            }

           
            for (int colIdx = 0; colIdx < 3; colIdx++)
            {
                if (_cells[0, colIdx] == player && 
                    _cells[1, colIdx] == player && 
                    _cells[2, colIdx] == player)
                    return true;
            }

            
            if (_cells[0, 0] == player && 
                _cells[1, 1] == player && 
                _cells[2, 2] == player)
                return true;

            if (_cells[0, 2] == player && 
                _cells[1, 1] == player && 
                _cells[2, 0] == player)
                return true;

            return false;
        }

        public bool CheckForTie()
        {
            
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (_cells[row, col] == null)
                        return false;
                }
            }
            return true;
        }
    }
}