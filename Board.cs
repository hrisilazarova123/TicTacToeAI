namespace TicTacToe.GameLogic
{
    public enum CellState
    {
        Empty,
        X,
        O
    }

    public class Board
    {
        private CellState[,] cells = new CellState[3, 3];

        public Board()
        {
            Reset();
        }

        public void Reset()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    cells[row, col] = CellState.Empty;
                }
            }
        }

        public CellState GetCell(int row, int col)
        {
            return cells[row, col];
        }

        public bool IsEmpty(int row, int col)
        {
            return cells[row, col] == CellState.Empty;
        }

        public bool MakeMove(int row, int col, CellState player)
        {
            if (!IsEmpty(row, col))
            {
                return false;
            }

            cells[row, col] = player;
            return true;
        }

        public CellState CheckWinner()
        {
            // Check rows
            for (int row = 0; row < 3; row++)
            {
                if (cells[row, 0] != CellState.Empty &&
                    cells[row, 0] == cells[row, 1] &&
                    cells[row, 1] == cells[row, 2])
                {
                    return cells[row, 0];
                }
            }

            // Check columns
            for (int col = 0; col < 3; col++)
            {
                if (cells[0, col] != CellState.Empty &&
                    cells[0, col] == cells[1, col] &&
                    cells[1, col] == cells[2, col])
                {
                    return cells[0, col];
                }
            }

            // Check main diagonal
            if (cells[0, 0] != CellState.Empty &&
                cells[0, 0] == cells[1, 1] &&
                cells[1, 1] == cells[2, 2])
            {
                return cells[0, 0];
            }

            // Check other diagonal
            if (cells[0, 2] != CellState.Empty &&
                cells[0, 2] == cells[1, 1] &&
                cells[1, 1] == cells[2, 0])
            {
                return cells[0, 2];
            }

            return CellState.Empty;
        }

        public bool IsFull()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (cells[row, col] == CellState.Empty)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}