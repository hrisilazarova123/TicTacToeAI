using System.Diagnostics;
using TicTacToe.GameLogic;

// Тестова програма за сравнение на трите нива на изкуствения интелект.
// Компютърът винаги играе с O, а противникът - с X.
// Началният играч се сменя след всяка игра, както в самото приложение.

namespace Experiment
{
    internal class Program
    {
        static Random random = new Random(42);
        static HardAi perfectPlayer = new HardAi();

        static void Main()
        {
            RandomAi easy = new RandomAi();
            MediumAi medium = new MediumAi();
            HardAi hard = new HardAi();

            Console.WriteLine("Противник, който играе случайно (по 1000 игри):");
            PlayGames("Лесно ", easy.GetMove, false, 1000);
            PlayGames("Средно", medium.GetMove, false, 1000);
            PlayGames("Трудно", hard.GetMove, false, 1000);

            Console.WriteLine();
            Console.WriteLine("Противник, който играе перфектно (по 200 игри):");
            PlayGames("Лесно ", easy.GetMove, true, 200);
            PlayGames("Средно", medium.GetMove, true, 200);
            PlayGames("Трудно", hard.GetMove, true, 200);

            Console.WriteLine();
            Console.WriteLine("Minimax без и с алфа-бета отсичане (брой разгледани позиции и време):");

            Board emptyBoard = new Board();
            ComparePruning("Празно поле (компютърът е първи)", emptyBoard);

            Board centerBoard = new Board();
            centerBoard.MakeMove(1, 1, CellState.X);
            ComparePruning("X е в центъра", centerBoard);

            Board cornerBoard = new Board();
            cornerBoard.MakeMove(0, 0, CellState.X);
            ComparePruning("X е в ъгъла", cornerBoard);
        }

        // Пуска HardAi два пъти върху едно и също поле - веднъж без отсичане
        // и веднъж с отсичане - и отпечатва колко позиции е разгледал всеки път.
        static void ComparePruning(string name, Board board)
        {
            HardAi withoutPruning = new HardAi();
            withoutPruning.UseAlphaBeta = false;

            HardAi withPruning = new HardAi();
            withPruning.UseAlphaBeta = true;

            Stopwatch timer = Stopwatch.StartNew();
            (int row, int col) move1 = withoutPruning.GetMove(board);
            double time1 = timer.Elapsed.TotalMilliseconds;

            timer.Restart();
            (int row, int col) move2 = withPruning.GetMove(board);
            double time2 = timer.Elapsed.TotalMilliseconds;

            Console.WriteLine($"{name}:");
            Console.WriteLine($"   без отсичане: {withoutPruning.PositionsChecked} позиции, {time1:F1} ms, ход {move1}");
            Console.WriteLine($"   с отсичане:   {withPruning.PositionsChecked} позиции, {time2:F1} ms, ход {move2}");
        }

        static void PlayGames(string name, Func<Board, (int row, int col)> getAiMove,
                              bool perfectOpponent, int gamesCount)
        {
            int wins = 0;
            int draws = 0;
            int losses = 0;
            Stopwatch aiTime = new Stopwatch();
            int aiMoves = 0;

            for (int game = 0; game < gamesCount; game++)
            {
                Board board = new Board();
                bool opponentTurn = game % 2 == 0;

                while (true)
                {
                    CellState winner = board.CheckWinner();

                    if (winner == CellState.O) { wins++; break; }
                    if (winner == CellState.X) { losses++; break; }
                    if (board.IsFull()) { draws++; break; }

                    if (opponentTurn)
                    {
                        (int row, int col) move = perfectOpponent
                            ? GetPerfectMove(board)
                            : GetRandomMove(board);
                        board.MakeMove(move.row, move.col, CellState.X);
                    }
                    else
                    {
                        aiTime.Start();
                        (int row, int col) move = getAiMove(board);
                        aiTime.Stop();
                        aiMoves++;
                        board.MakeMove(move.row, move.col, CellState.O);
                    }

                    opponentTurn = !opponentTurn;
                }
            }

            Console.WriteLine($"{name}: победи {Percent(wins, gamesCount)}, " +
                              $"равни {Percent(draws, gamesCount)}, " +
                              $"загуби {Percent(losses, gamesCount)}, " +
                              $"среден ход {aiTime.Elapsed.TotalMilliseconds / aiMoves:F2} ms");
        }

        static string Percent(int count, int total)
        {
            return $"{100.0 * count / total:F1}%";
        }

        // Случаен ход за противника (X).
        static (int row, int col) GetRandomMove(Board board)
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

            return emptyCells[random.Next(emptyCells.Count)];
        }

        // Перфектен ход за противника (X).
        // HardAi винаги играе с O, затова разменяме X и O в едно копие на полето,
        // питаме HardAi за най-добрия ход и го изиграваме като X.
        static (int row, int col) GetPerfectMove(Board board)
        {
            Board swapped = new Board();

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    CellState cell = board.GetCell(row, col);

                    if (cell == CellState.X)
                    {
                        swapped.MakeMove(row, col, CellState.O);
                    }
                    else if (cell == CellState.O)
                    {
                        swapped.MakeMove(row, col, CellState.X);
                    }
                }
            }

            return perfectPlayer.GetMove(swapped);
        }
    }
}
