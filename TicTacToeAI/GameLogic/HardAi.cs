namespace TicTacToe.GameLogic
{
    public class HardAi
    {
        // Дали да се използва алфа-бета отсичане.
        // В играта винаги е true. Програмата Experiment го изключва,
        // за да сравни колко позиции се разглеждат с и без отсичане.
        public bool UseAlphaBeta = true;

        // Колко позиции е разгледал Minimax при последното извикване на GetMove().
        public int PositionsChecked = 0;

        public (int row, int col) GetMove(Board board)
        {
            PositionsChecked = 0;

            int bestScore = int.MinValue;
            (int row, int col) bestMove = (-1, -1);

            // alpha - най-добрата оценка, която компютърът (O) вече си е осигурил.
            int alpha = int.MinValue;

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

                    // Този ход вече е направен, затова започваме с дълбочина 1.
                    int score = Minimax(testBoard, false, 1, alpha, int.MaxValue);

                    if (score > bestScore)
                    {
                        bestScore = score;
                        bestMove = (row, col);
                    }

                    if (bestScore > alpha)
                    {
                        alpha = bestScore;
                    }
                }
            }

            return bestMove;
        }

        // depth показва колко хода са направени от текущата позиция.
        // Колкото по-бърза е победата, толкова по-висока е оценката,
        // а колкото по-късна е загубата, толкова по-малко лоша е тя.
        //
        // alpha - най-добрата оценка, която O вече си е осигурил по пътя дотук.
        // beta  - най-добрата (най-ниската) оценка, която X вече си е осигурил.
        // Ако alpha >= beta, тази позиция няма да бъде достигната при добра игра
        // и останалите ходове в нея не е нужно да се проверяват.
        private int Minimax(Board board, bool maximizing, int depth, int alpha, int beta)
        {
            PositionsChecked++;

            CellState winner = board.CheckWinner();

            if (winner == CellState.O)
            {
                return 10 - depth;
            }

            if (winner == CellState.X)
            {
                return depth - 10;
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

                        int score = Minimax(testBoard, false, depth + 1, alpha, beta);

                        if (score > bestScore)
                        {
                            bestScore = score;
                        }

                        if (bestScore > alpha)
                        {
                            alpha = bestScore;
                        }

                        // X вече има по-добър вариант по друг път,
                        // затова няма да допусне тази позиция.
                        if (UseAlphaBeta && alpha >= beta)
                        {
                            return bestScore;
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

                        int score = Minimax(testBoard, true, depth + 1, alpha, beta);

                        if (score < bestScore)
                        {
                            bestScore = score;
                        }

                        if (bestScore < beta)
                        {
                            beta = bestScore;
                        }

                        // O вече има по-добър вариант по друг път,
                        // затова няма да допусне тази позиция.
                        if (UseAlphaBeta && alpha >= beta)
                        {
                            return bestScore;
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
