using System;
using System.Collections.Generic;

namespace TicTacToe.GameLogic
{
    public class RandomAi
    {
        private Random random = new Random();

        public (int row, int col) GetMove(Board board)
        {
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
    }
}