namespace TicTacToe.GameLogic
{
    public class HardAi
    {
        public (int row, int col) GetMove(Board board)
        {
            int bestScore = int.MinValue;
            (int row, int col) bestMove = (-1, -1);

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (!board.IsEmpty(row, col))
                    {
                        continue;
                    }

                    Board testBoard = CopyBoard(board);

                    testBoard.MakeMove(row, col, CellState.O);

                    int score = Minimax(testBoard, false);

                    if (score > bestScore)
                    {
                        bestScore = score;
                        bestMove = (row, col);
                    }
                }
            }

            return bestMove;
        }

        private int Minimax(Board board, bool maximizing)
        {
            CellState winner = board.CheckWinner();

            if (winner == CellState.O)
            {
                return 10;
            }

            if (winner == CellState.X)
            {
                return -10;
            }

            if (board.IsFull())
            {
                return 0;
            }

            if (maximizing)
            {
                int bestScore = int.MinValue;

                for (int row = 0; row < 3; row++)
                {
                    for (int col = 0; col < 3; col++)
                    {
                        if (!board.IsEmpty(row, col))
                        {
                            continue;
                        }

                        Board testBoard = CopyBoard(board);

                        testBoard.MakeMove(row, col, CellState.O);

                        int score = Minimax(testBoard, false);

                        if (score > bestScore)
                        {
                            bestScore = score;
                        }
                    }
                }

                return bestScore;
            }
            else
            {
                int bestScore = int.MaxValue;

                for (int row = 0; row < 3; row++)
                {
                    for (int col = 0; col < 3; col++)
                    {
                        if (!board.IsEmpty(row, col))
                        {
                            continue;
                        }

                        Board testBoard = CopyBoard(board);

                        testBoard.MakeMove(row, col, CellState.X);

                        int score = Minimax(testBoard, true);

                        if (score < bestScore)
                        {
                            bestScore = score;
                        }
                    }
                }

                return bestScore;
            }
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