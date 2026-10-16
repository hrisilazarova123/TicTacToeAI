using TicTacToe.GameLogic;

namespace TicTacToeAI
{
    public partial class Form1 : Form
    {
        // =========================
        // GAME FIELDS
        // =========================

        private Board board = new Board();

        private CellState currentPlayer = CellState.X;
        private CellState startingPlayer = CellState.X;

        private bool isVsAI = false;
        private bool gameStarted = false;

        private int player1Score = 0;
        private int player2Score = 0;

        private RandomAi randomAi = new RandomAi();
        private MediumAi mediumAi = new MediumAi();
        private HardAi hardAi = new HardAi();

        private System.Windows.Forms.Timer aiTimer;


        // =========================
        // FORM CONSTRUCTOR
        // =========================

        public Form1()
        {
            InitializeComponent();

            cmbMode.SelectedIndex = 0;
            cmbDifficulty.SelectedIndex = 0;

            lblPlayer.Text = "PLAYER 1";
            lblAI.Text = "PLAYER 2";

            lblDifficulty.Enabled = false;
            cmbDifficulty.Enabled = false;

            UpdateScoreDisplay();

            startingPlayer = CellState.X;
            currentPlayer = CellState.X;

            lblStatus.Text = "PLAYER 1'S TURN";

            aiTimer = new System.Windows.Forms.Timer();
            aiTimer.Interval = 700;
            aiTimer.Tick += AiTimer_Tick;

            // NEW ROUND is unavailable until the round ends
            btnNewGame.Enabled = false;
        }


        // =========================
        // GAME LOGIC
        // =========================

        private void MakePlayerMove(int row, int col, Button button)
        {
            // Prevent the player from moving while the AI is thinking
            if (isVsAI && currentPlayer == CellState.O)
            {
                return;
            }

            if (!gameStarted)
            {
                gameStarted = true;
                LockGameSettings();
            }

            if (!board.MakeMove(row, col, currentPlayer))
            {
                return;
            }

            button.Text = currentPlayer.ToString();

            CellState winner = board.CheckWinner();

            if (winner != CellState.Empty)
            {
                if (winner == CellState.X)
                {
                    player1Score++;
                }
                else
                {
                    player2Score++;
                }

                UpdateScoreDisplay();

                if (cmbMode.SelectedIndex == 0)
                {
                    lblStatus.Text = winner == CellState.X
                        ? "PLAYER 1 WINS!"
                        : "PLAYER 2 WINS!";
                }
                else
                {
                    lblStatus.Text = winner == CellState.X
                        ? "YOU WIN!"
                        : "AI WINS!";
                }

                // Round has ended
                btnNewGame.Enabled = true;

                return;
            }

            if (board.IsFull())
            {
                lblStatus.Text = "DRAW!";

                // Round has ended
                btnNewGame.Enabled = true;

                return;
            }

            if (currentPlayer == CellState.X)
            {
                currentPlayer = CellState.O;
            }
            else
            {
                currentPlayer = CellState.X;
            }

            if (cmbMode.SelectedIndex == 0)
            {
                lblStatus.Text = currentPlayer == CellState.X
                    ? "PLAYER 1'S TURN"
                    : "PLAYER 2'S TURN";
            }
            else
            {
                if (currentPlayer == CellState.O)
                {
                    lblStatus.Text = "AI'S TURN";
                    aiTimer.Start();
                }
                else
                {
                    lblStatus.Text = "YOUR TURN";
                }
            }
        }


        private void AiTimer_Tick(object sender, EventArgs e)
        {
            aiTimer.Stop();
            MakeAIMove();
        }


        private void MakeAIMove()
        {
            (int row, int col) move;

            if (cmbDifficulty.SelectedIndex == 0)
            {
                // Easy AI
                move = randomAi.GetMove(board);
            }
            else if (cmbDifficulty.SelectedIndex == 1)
            {
                // Medium AI
                move = mediumAi.GetMove(board);
            }
            else
            {
                // Hard AI
                move = hardAi.GetMove(board);
            }

            if (move.row == -1)
            {
                return;
            }

            board.MakeMove(move.row, move.col, CellState.O);

            Button button = GetBoardButton(move.row, move.col);

            button.Text = "O";

            CellState winner = board.CheckWinner();

            if (winner == CellState.O)
            {
                player2Score++;
                UpdateScoreDisplay();

                lblStatus.Text = "AI WINS!";

                // Round has ended
                btnNewGame.Enabled = true;

                return;
            }

            if (board.IsFull())
            {
                lblStatus.Text = "DRAW!";

                // Round has ended
                btnNewGame.Enabled = true;

                return;
            }

            currentPlayer = CellState.X;

            lblStatus.Text = "YOUR TURN";
        }


        private Button GetBoardButton(int row, int col)
        {
            if (row == 0 && col == 0) return btn00;
            if (row == 0 && col == 1) return btn01;
            if (row == 0 && col == 2) return btn02;

            if (row == 1 && col == 0) return btn10;
            if (row == 1 && col == 1) return btn11;
            if (row == 1 && col == 2) return btn12;

            if (row == 2 && col == 0) return btn20;
            if (row == 2 && col == 1) return btn21;
            if (row == 2 && col == 2) return btn22;

            return null;
        }


        private void StartNewRound()
        {
            // Cancel any pending AI move
            aiTimer.Stop();

            // NEW ROUND is disabled while the round is active
            btnNewGame.Enabled = false;

            board.Reset();

            ClearBoardButtons();

            currentPlayer = startingPlayer;

            if (cmbMode.SelectedIndex == 0)
            {
                if (currentPlayer == CellState.X)
                {
                    lblStatus.Text = "PLAYER 1'S TURN";
                }
                else
                {
                    lblStatus.Text = "PLAYER 2'S TURN";
                }
            }
            else
            {
                if (currentPlayer == CellState.X)
                {
                    lblStatus.Text = "YOUR TURN";
                }
                else
                {
                    lblStatus.Text = "AI'S TURN";
                    aiTimer.Start();
                }
            }
        }


        private void SwitchStartingPlayer()
        {
            if (startingPlayer == CellState.X)
            {
                startingPlayer = CellState.O;
            }
            else
            {
                startingPlayer = CellState.X;
            }
        }


        // =========================
        // BOARD / DISPLAY
        // =========================

        private void ClearBoardButtons()
        {
            btn00.Text = "";
            btn01.Text = "";
            btn02.Text = "";

            btn10.Text = "";
            btn11.Text = "";
            btn12.Text = "";

            btn20.Text = "";
            btn21.Text = "";
            btn22.Text = "";
        }


        private void UpdateScoreDisplay()
        {
            lblPlayerScore.Text = player1Score.ToString();
            lblAIScore.Text = player2Score.ToString();
        }


        // =========================
        // SETTINGS
        // =========================

        private void LockGameSettings()
        {
            cmbMode.Enabled = false;
            cmbDifficulty.Enabled = false;
        }


        private void cmbMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMode.SelectedIndex == 0)
            {
                isVsAI = false;

                lblPlayer.Text = "PLAYER 1";
                lblAI.Text = "PLAYER 2";

                lblDifficulty.Enabled = false;
                cmbDifficulty.Enabled = false;
            }
            else
            {
                isVsAI = true;

                lblPlayer.Text = "YOU";
                lblAI.Text = "AI";

                lblDifficulty.Enabled = true;
                cmbDifficulty.Enabled = true;
            }
        }


        // =========================
        // BOARD BUTTONS
        // =========================

        private void btn00_Click(object sender, EventArgs e)
        {
            MakePlayerMove(0, 0, btn00);
        }

        private void btn01_Click(object sender, EventArgs e)
        {
            MakePlayerMove(0, 1, btn01);
        }

        private void btn02_Click(object sender, EventArgs e)
        {
            MakePlayerMove(0, 2, btn02);
        }

        private void btn10_Click(object sender, EventArgs e)
        {
            MakePlayerMove(1, 0, btn10);
        }

        private void btn11_Click(object sender, EventArgs e)
        {
            MakePlayerMove(1, 1, btn11);
        }

        private void btn12_Click(object sender, EventArgs e)
        {
            MakePlayerMove(1, 2, btn12);
        }

        private void btn20_Click(object sender, EventArgs e)
        {
            MakePlayerMove(2, 0, btn20);
        }

        private void btn21_Click(object sender, EventArgs e)
        {
            MakePlayerMove(2, 1, btn21);
        }

        private void btn22_Click(object sender, EventArgs e)
        {
            MakePlayerMove(2, 2, btn22);
        }


        // =========================
        // GAME CONTROL BUTTONS
        // =========================

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            SwitchStartingPlayer();
            StartNewRound();
        }


        private void btnMenu_Click(object sender, EventArgs e)
        {
            // Stop any pending AI move
            aiTimer.Stop();

            player1Score = 0;
            player2Score = 0;

            UpdateScoreDisplay();

            startingPlayer = CellState.X;
            currentPlayer = CellState.X;

            gameStarted = false;

            cmbMode.Enabled = true;

            if (cmbMode.SelectedIndex == 0)
            {
                cmbDifficulty.Enabled = false;
            }
            else
            {
                cmbDifficulty.Enabled = true;
            }

            lblStatus.Text = "PLAYER 1'S TURN";

            // RESET MATCH starts a completely new round
            StartNewRound();
        }
    }
}