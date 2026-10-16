using System;
using System.Collections.Generic;

namespace TicTacToe.GameLogic
{
    public class MediumAi
    {
        private Random random = new Random();

        public (int row, int col) GetMove(Board board)
        {
            // 1. Try to win
            var winningMove = FindWinningMove(board, CellState.O);

            if (winningMove.row != -1)
            {
                return winningMove;
            }

            // 2. Try to block the player
            var blockingMove = FindWinningMove(board, CellState.X);

            if (blockingMove.row != -1)
            {
                return blockingMove;
            }

            // 3. Otherwise, choose a random empty cell
            List<(int row, int col)> emptyCells = new List<(int row, int col)>();

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (board.IsEmpty(row, col))
                    {
                        emptyCells.Add((row, col));
                    }
                }
            }

            if (emptyCells.Count == 0)
            {
                return (-1, -1);
            }

            int index = random.Next(emptyCells.Count);

            return emptyCells[index];
        }

        private (int row, int col) FindWinningMove(
            Board board,
            CellState player)
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (!board.IsEmpty(row, col))
                    {
                        continue;
                    }

                    Board testBoard = CopyBoard(board);

                    testBoard.MakeMove(row, col, player);

                    if (testBoard.CheckWinner() == player)
                    {
                        return (row, col);
                    }
                }
            }

            return (-1, -1);
        }

        private Board CopyBoard(Board board)
        {
            Board copy = new Board();

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    CellState cell = board.GetCell(row, col);

                    if (cell != CellState.Empty)
                    {
                        copy.MakeMove(row, col, cell);
                    }
                }
            }

            return copy;
        }
    }
}