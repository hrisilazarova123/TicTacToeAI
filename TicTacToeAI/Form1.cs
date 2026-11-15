using System;
using System.Windows.Forms;
using TicTacToe.GameLogic;

namespace TicTacToeAI
{
    public partial class Form1 : Form
    {
        private Board board = new Board();

        private CellState currentPlayer = CellState.X;
        private CellState startingPlayer = CellState.X;

        private bool isVsAI = false;
        private bool gameStarted = false;
        private bool roundEnded = false;

        private int player1Score = 0;
        private int player2Score = 0;

        private RandomAi randomAi = new RandomAi();
        private MediumAi mediumAi = new MediumAi();
        private HardAi hardAi = new HardAi();

        // Всеки играч има свой цвят. С него се изписват символът му,
        // името му, резултатът му и съобщението, когато той е на ход.
        private Color xColor = Color.FromArgb(242, 153, 74);   // оранжево за X
        private Color oColor = Color.FromArgb(100, 170, 255);  // синьо за O

        private System.Windows.Forms.Timer aiTimer;


        public Form1()
        {
            InitializeComponent();

            // Initialize the timer before changing combo-box selections,
            // because changing a selection can trigger its event handler.
            aiTimer = new System.Windows.Forms.Timer();
            aiTimer.Interval = 700;
            aiTimer.Tick += AiTimer_Tick;

            cmbMode.SelectedIndex = 0;
            cmbDifficulty.SelectedIndex = 0;

            startingPlayer = CellState.X;
            currentPlayer = CellState.X;

            lblPlayer.Text = "PLAYER 1";
            lblAI.Text = "PLAYER 2";

            // Първият играч (X) е оранжев, а вторият (O) - син.
            lblPlayer.ForeColor = xColor;
            lblPlayerScore.ForeColor = xColor;
            lblAI.ForeColor = oColor;
            lblAIScore.ForeColor = oColor;

            lblDifficulty.Enabled = false;
            cmbDifficulty.Enabled = false;

            UpdateScoreDisplay();
            UpdateTurnStatus();

            btnNewGame.Enabled = false;
        }


        // =========================
        // STATUS AND SCORES
        // =========================

        private void UpdateTurnStatus()
        {
            if (cmbMode.SelectedIndex == 0)
            {
                lblStatus.Text = currentPlayer == CellState.X
                    ? "PLAYER 1'S TURN"
                    : "PLAYER 2'S TURN";
            }
            else
            {
                lblStatus.Text = currentPlayer == CellState.X
                    ? "YOUR TURN"
                    : "AI'S TURN";
            }

            lblStatus.ForeColor = GetPlayerColor(currentPlayer);
        }


        private Color GetPlayerColor(CellState player)
        {
            if (player == CellState.X)
            {
                return xColor;
            }

            return oColor;
        }


        private void UpdateScoreDisplay()
        {
            lblPlayerScore.Text = player1Score.ToString();
            lblAIScore.Text = player2Score.ToString();
        }


        // =========================
        // PLAYER MOVE
        // =========================

        private void MakePlayerMove(int row, int col, Button button)
        {
            if (roundEnded)
                return;

            if (isVsAI && currentPlayer == CellState.O)
                return;

            if (!gameStarted)
            {
                gameStarted = true;
                LockGameSettings();
            }

            if (!board.MakeMove(row, col, currentPlayer))
                return;

            button.Text = currentPlayer.ToString();
            button.ForeColor = GetPlayerColor(currentPlayer);

            CellState winner = board.CheckWinner();

            if (winner != CellState.Empty)
            {
                EndRound(winner);
                return;
            }

            if (board.IsFull())
            {
                EndRound(CellState.Empty);
                return;
            }

            currentPlayer = currentPlayer == CellState.X
                ? CellState.O
                : CellState.X;

            UpdateTurnStatus();

            if (isVsAI && currentPlayer == CellState.O)
                aiTimer.Start();
        }


        // =========================
        // AI MOVE
        // =========================

        private void AiTimer_Tick(object? sender, EventArgs e)
        {
            aiTimer.Stop();

            if (roundEnded)
                return;

            MakeAIMove();
        }


        private void MakeAIMove()
        {
            if (roundEnded || !isVsAI ||
                currentPlayer != CellState.O)
            {
                return;
            }

            (int row, int col) move;

            switch (cmbDifficulty.SelectedIndex)
            {
                case 0:
                    move = randomAi.GetMove(board);
                    break;

                case 1:
                    move = mediumAi.GetMove(board);
                    break;

                default:
                    move = hardAi.GetMove(board);
                    break;
            }

            if (move.row < 0 || move.col < 0)
                return;

            if (!board.MakeMove(move.row, move.col, CellState.O))
                return;

            Button button = GetBoardButton(move.row, move.col);
            button.Text = "O";
            button.ForeColor = oColor;

            CellState winner = board.CheckWinner();

            if (winner != CellState.Empty)
            {
                EndRound(winner);
                return;
            }

            if (board.IsFull())
            {
                EndRound(CellState.Empty);
                return;
            }

            currentPlayer = CellState.X;
            UpdateTurnStatus();
        }


        // =========================
        // ROUND ENDING
        // =========================

        private void EndRound(CellState winner)
        {
            roundEnded = true;
            aiTimer.Stop();

            // Бутоните не се забраняват, защото забранен бутон показва X и O
            // с тъмен, почти нечетим цвят. Нови ходове не са възможни,
            // защото MakePlayerMove() проверява roundEnded.

            if (winner == CellState.X)
            {
                player1Score++;
            }
            else if (winner == CellState.O)
            {
                player2Score++;
            }

            UpdateScoreDisplay();

            if (winner == CellState.Empty)
            {
                lblStatus.Text = "DRAW!";
            }
            else if (isVsAI)
            {
                lblStatus.Text = winner == CellState.X
                    ? "YOU WIN!"
                    : "AI WINS!";
            }
            else
            {
                lblStatus.Text = winner == CellState.X
                    ? "PLAYER 1 WINS!"
                    : "PLAYER 2 WINS!";
            }

            // При равенство съобщението е бяло, иначе е в цвета на победителя.
            if (winner == CellState.Empty)
            {
                lblStatus.ForeColor = Color.White;
            }
            else
            {
                lblStatus.ForeColor = GetPlayerColor(winner);
            }

            btnNewGame.Enabled = true;
        }


        // =========================
        // BOARD HELPERS
        // =========================

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

            throw new ArgumentOutOfRangeException(
                nameof(row), "Invalid board position.");
        }


        private void SetBoardButtonsEnabled(bool enabled)
        {
            Button[] buttons =
            {
                btn00, btn01, btn02,
                btn10, btn11, btn12,
                btn20, btn21, btn22
            };

            foreach (Button button in buttons)
            {
                button.Enabled = enabled;
            }
        }


        private void ClearBoardButtons()
        {
            Button[] buttons =
            {
                btn00, btn01, btn02,
                btn10, btn11, btn12,
                btn20, btn21, btn22
            };

            foreach (Button button in buttons)
            {
                button.Text = "";

                // Плоският бутон рисува рамката си с цвета на текста,
                // затова връщаме началния бял цвят, за да изчезне цветната рамка.
                button.ForeColor = Color.White;
            }
        }


        // =========================
        // START A NEW ROUND
        // =========================

        private void StartNewRound()
        {
            aiTimer.Stop();

            roundEnded = false;
            SetBoardButtonsEnabled(true);
            btnNewGame.Enabled = false;

            board.Reset();
            ClearBoardButtons();

            currentPlayer = startingPlayer;

            UpdateTurnStatus();

            if (isVsAI && currentPlayer == CellState.O)
                aiTimer.Start();
        }


        private void SwitchStartingPlayer()
        {
            startingPlayer = startingPlayer == CellState.X
                ? CellState.O
                : CellState.X;
        }


        // =========================
        // SETTINGS
        // =========================

        private void LockGameSettings()
        {
            cmbMode.Enabled = false;
            cmbDifficulty.Enabled = false;
        }


        private void cmbMode_SelectedIndexChanged(
            object sender, EventArgs e)
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

            // Changing mode starts a fresh game.
            startingPlayer = CellState.X;
            currentPlayer = CellState.X;
            gameStarted = false;

            if (aiTimer != null)
                StartNewRound();
        }


        // =========================
        // BOARD BUTTON EVENTS
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
        // NEW ROUND
        // =========================

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            SwitchStartingPlayer();
            StartNewRound();
        }


        // =========================
        // RESET MATCH
        // =========================

        private void btnMenu_Click(object sender, EventArgs e)
        {
            aiTimer.Stop();

            player1Score = 0;
            player2Score = 0;

            startingPlayer = CellState.X;
            currentPlayer = CellState.X;
            gameStarted = false;
            roundEnded = false;

            UpdateScoreDisplay();

            cmbMode.Enabled = true;

            cmbDifficulty.Enabled = cmbMode.SelectedIndex != 0;
            lblDifficulty.Enabled = cmbMode.SelectedIndex != 0;

            StartNewRound();
        }
    }
}