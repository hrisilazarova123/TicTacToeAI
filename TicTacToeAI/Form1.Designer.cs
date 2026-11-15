namespace TicTacToeAI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblPlayer = new Label();
            lblVS = new Label();
            lblAI = new Label();
            lblPlayerScore = new Label();
            lblAIScore = new Label();
            gameBoard = new TableLayoutPanel();
            btn22 = new Button();
            btn21 = new Button();
            btn20 = new Button();
            btn12 = new Button();
            btn11 = new Button();
            btn10 = new Button();
            btn01 = new Button();
            btn00 = new Button();
            btn02 = new Button();
            lblStatus = new Label();
            lblDifficulty = new Label();
            cmbDifficulty = new ComboBox();
            btnNewGame = new Button();
            btnMenu = new Button();
            lblMode = new Label();
            cmbMode = new ComboBox();
            gameBoard.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI", 28F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(50, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(500, 60);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "TIC TAC TOE";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPlayer
            // 
            lblPlayer.BackColor = Color.Transparent;
            lblPlayer.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPlayer.ForeColor = Color.White;
            lblPlayer.Location = new Point(100, 90);
            lblPlayer.Name = "lblPlayer";
            lblPlayer.Size = new Size(140, 30);
            lblPlayer.TabIndex = 1;
            lblPlayer.Text = "YOU";
            lblPlayer.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblVS
            // 
            lblVS.BackColor = Color.Transparent;
            lblVS.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblVS.ForeColor = Color.LightGray;
            lblVS.Location = new Point(250, 90);
            lblVS.Name = "lblVS";
            lblVS.Size = new Size(100, 30);
            lblVS.TabIndex = 2;
            lblVS.Text = "VS";
            lblVS.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblAI
            // 
            lblAI.BackColor = Color.Transparent;
            lblAI.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAI.ForeColor = Color.White;
            lblAI.Location = new Point(360, 90);
            lblAI.Name = "lblAI";
            lblAI.Size = new Size(140, 30);
            lblAI.TabIndex = 3;
            lblAI.Text = "AI";
            lblAI.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPlayerScore
            // 
            lblPlayerScore.BackColor = Color.Transparent;
            lblPlayerScore.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblPlayerScore.ForeColor = Color.White;
            lblPlayerScore.Location = new Point(120, 115);
            lblPlayerScore.Name = "lblPlayerScore";
            lblPlayerScore.Size = new Size(100, 45);
            lblPlayerScore.TabIndex = 4;
            lblPlayerScore.Text = "0";
            lblPlayerScore.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblAIScore
            // 
            lblAIScore.BackColor = Color.Transparent;
            lblAIScore.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblAIScore.ForeColor = Color.White;
            lblAIScore.Location = new Point(380, 115);
            lblAIScore.Name = "lblAIScore";
            lblAIScore.Size = new Size(100, 45);
            lblAIScore.TabIndex = 5;
            lblAIScore.Text = "0";
            lblAIScore.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // gameBoard
            // 
            gameBoard.BackColor = Color.FromArgb(42, 42, 64);
            gameBoard.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            gameBoard.ColumnCount = 3;
            gameBoard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            gameBoard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            gameBoard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            gameBoard.Controls.Add(btn22, 2, 2);
            gameBoard.Controls.Add(btn21, 1, 2);
            gameBoard.Controls.Add(btn20, 0, 2);
            gameBoard.Controls.Add(btn12, 2, 1);
            gameBoard.Controls.Add(btn11, 1, 1);
            gameBoard.Controls.Add(btn10, 0, 1);
            gameBoard.Controls.Add(btn01, 1, 0);
            gameBoard.Controls.Add(btn00, 0, 0);
            gameBoard.Controls.Add(btn02, 2, 0);
            gameBoard.Location = new Point(120, 170);
            gameBoard.Name = "gameBoard";
            gameBoard.Padding = new Padding(2);
            gameBoard.RowCount = 3;
            gameBoard.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            gameBoard.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            gameBoard.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            gameBoard.Size = new Size(360, 360);
            gameBoard.TabIndex = 6;
            // 
            // btn22
            // 
            btn22.Dock = DockStyle.Fill;
            btn22.FlatStyle = FlatStyle.Flat;
            btn22.Font = new Font("Segoe UI", 32F, FontStyle.Bold);
            btn22.ForeColor = Color.White;
            btn22.Location = new Point(242, 242);
            btn22.Name = "btn22";
            btn22.Size = new Size(112, 112);
            btn22.TabIndex = 8;
            btn22.UseVisualStyleBackColor = false;
            btn22.Click += btn22_Click;
            // 
            // btn21
            // 
            btn21.Dock = DockStyle.Fill;
            btn21.FlatStyle = FlatStyle.Flat;
            btn21.Font = new Font("Segoe UI", 32F, FontStyle.Bold);
            btn21.ForeColor = Color.White;
            btn21.Location = new Point(124, 242);
            btn21.Name = "btn21";
            btn21.Size = new Size(111, 112);
            btn21.TabIndex = 7;
            btn21.UseVisualStyleBackColor = false;
            btn21.Click += btn21_Click;
            // 
            // btn20
            // 
            btn20.Dock = DockStyle.Fill;
            btn20.FlatStyle = FlatStyle.Flat;
            btn20.Font = new Font("Segoe UI", 32F, FontStyle.Bold);
            btn20.ForeColor = Color.White;
            btn20.Location = new Point(6, 242);
            btn20.Name = "btn20";
            btn20.Size = new Size(111, 112);
            btn20.TabIndex = 6;
            btn20.UseVisualStyleBackColor = false;
            btn20.Click += btn20_Click;
            // 
            // btn12
            // 
            btn12.Dock = DockStyle.Fill;
            btn12.FlatStyle = FlatStyle.Flat;
            btn12.Font = new Font("Segoe UI", 32F, FontStyle.Bold);
            btn12.ForeColor = Color.White;
            btn12.Location = new Point(242, 124);
            btn12.Name = "btn12";
            btn12.Size = new Size(112, 111);
            btn12.TabIndex = 5;
            btn12.UseVisualStyleBackColor = false;
            btn12.Click += btn12_Click;
            // 
            // btn11
            // 
            btn11.Dock = DockStyle.Fill;
            btn11.FlatStyle = FlatStyle.Flat;
            btn11.Font = new Font("Segoe UI", 32F, FontStyle.Bold);
            btn11.ForeColor = Color.White;
            btn11.Location = new Point(124, 124);
            btn11.Name = "btn11";
            btn11.Size = new Size(111, 111);
            btn11.TabIndex = 4;
            btn11.UseVisualStyleBackColor = false;
            btn11.Click += btn11_Click;
            // 
            // btn10
            // 
            btn10.Dock = DockStyle.Fill;
            btn10.FlatStyle = FlatStyle.Flat;
            btn10.Font = new Font("Segoe UI", 32F, FontStyle.Bold);
            btn10.ForeColor = Color.White;
            btn10.Location = new Point(6, 124);
            btn10.Name = "btn10";
            btn10.Size = new Size(111, 111);
            btn10.TabIndex = 3;
            btn10.UseVisualStyleBackColor = false;
            btn10.Click += btn10_Click;
            // 
            // btn01
            // 
            btn01.Dock = DockStyle.Fill;
            btn01.FlatStyle = FlatStyle.Flat;
            btn01.Font = new Font("Segoe UI", 32F, FontStyle.Bold);
            btn01.ForeColor = Color.White;
            btn01.Location = new Point(124, 6);
            btn01.Name = "btn01";
            btn01.Size = new Size(111, 111);
            btn01.TabIndex = 1;
            btn01.UseVisualStyleBackColor = false;
            btn01.Click += btn01_Click;
            // 
            // btn00
            // 
            btn00.Dock = DockStyle.Fill;
            btn00.FlatStyle = FlatStyle.Flat;
            btn00.Font = new Font("Segoe UI", 32F, FontStyle.Bold);
            btn00.ForeColor = Color.White;
            btn00.Location = new Point(6, 6);
            btn00.Name = "btn00";
            btn00.Size = new Size(111, 111);
            btn00.TabIndex = 0;
            btn00.UseVisualStyleBackColor = false;
            btn00.Click += btn00_Click;
            // 
            // btn02
            // 
            btn02.Dock = DockStyle.Fill;
            btn02.FlatStyle = FlatStyle.Flat;
            btn02.Font = new Font("Segoe UI", 32F, FontStyle.Bold);
            btn02.ForeColor = Color.White;
            btn02.Location = new Point(242, 6);
            btn02.Name = "btn02";
            btn02.Size = new Size(112, 111);
            btn02.TabIndex = 2;
            btn02.UseVisualStyleBackColor = false;
            btn02.Click += btn02_Click;
            // 
            // lblStatus
            // 
            lblStatus.BackColor = Color.Transparent;
            lblStatus.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStatus.ForeColor = Color.White;
            lblStatus.Location = new Point(120, 545);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(360, 40);
            lblStatus.TabIndex = 7;
            lblStatus.Text = "YOUR TURN";
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDifficulty
            // 
            lblDifficulty.BackColor = Color.Transparent;
            lblDifficulty.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDifficulty.ForeColor = Color.White;
            lblDifficulty.Location = new Point(120, 630);
            lblDifficulty.Name = "lblDifficulty";
            lblDifficulty.Size = new Size(120, 30);
            lblDifficulty.TabIndex = 8;
            lblDifficulty.Text = "Difficulty";
            lblDifficulty.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cmbDifficulty
            // 
            cmbDifficulty.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDifficulty.FormattingEnabled = true;
            cmbDifficulty.Items.AddRange(new object[] { "Easy", "Medium", "Hard" });
            cmbDifficulty.Location = new Point(250, 630);
            cmbDifficulty.Name = "cmbDifficulty";
            cmbDifficulty.Size = new Size(230, 36);
            cmbDifficulty.TabIndex = 9;
            // 
            // btnNewGame
            // 
            btnNewGame.BackColor = Color.FromArgb(58, 58, 85);
            btnNewGame.Cursor = Cursors.Hand;
            btnNewGame.FlatAppearance.BorderSize = 0;
            btnNewGame.FlatStyle = FlatStyle.Flat;
            btnNewGame.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNewGame.ForeColor = Color.White;
            btnNewGame.Location = new Point(120, 680);
            btnNewGame.Name = "btnNewGame";
            btnNewGame.Size = new Size(170, 45);
            btnNewGame.TabIndex = 10;
            btnNewGame.Text = "NEW ROUND";
            btnNewGame.UseVisualStyleBackColor = false;
            btnNewGame.Click += btnNewGame_Click;
            // 
            // btnMenu
            // 
            btnMenu.BackColor = Color.FromArgb(58, 58, 85);
            btnMenu.Cursor = Cursors.Hand;
            btnMenu.FlatAppearance.BorderSize = 0;
            btnMenu.FlatStyle = FlatStyle.Flat;
            btnMenu.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMenu.ForeColor = Color.White;
            btnMenu.Location = new Point(310, 680);
            btnMenu.Name = "btnMenu";
            btnMenu.Size = new Size(170, 45);
            btnMenu.TabIndex = 11;
            btnMenu.Text = "RESET MATCH";
            btnMenu.UseVisualStyleBackColor = false;
            btnMenu.Click += btnMenu_Click;
            // 
            // lblMode
            // 
            lblMode.BackColor = Color.Transparent;
            lblMode.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMode.ForeColor = Color.White;
            lblMode.Location = new Point(120, 590);
            lblMode.Name = "lblMode";
            lblMode.Size = new Size(120, 30);
            lblMode.TabIndex = 12;
            lblMode.Text = "Mode";
            lblMode.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cmbMode
            // 
            cmbMode.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMode.FormattingEnabled = true;
            cmbMode.Items.AddRange(new object[] { "1v1", "VS AI" });
            cmbMode.Location = new Point(250, 590);
            cmbMode.Name = "cmbMode";
            cmbMode.Size = new Size(230, 36);
            cmbMode.TabIndex = 13;
            cmbMode.SelectedIndexChanged += cmbMode_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 47);
            ClientSize = new Size(578, 724);
            Controls.Add(cmbMode);
            Controls.Add(lblMode);
            Controls.Add(btnMenu);
            Controls.Add(btnNewGame);
            Controls.Add(cmbDifficulty);
            Controls.Add(lblDifficulty);
            Controls.Add(lblStatus);
            Controls.Add(gameBoard);
            Controls.Add(lblAIScore);
            Controls.Add(lblPlayerScore);
            Controls.Add(lblAI);
            Controls.Add(lblVS);
            Controls.Add(lblPlayer);
            Controls.Add(lblTitle);
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tic Tac Toe";
            gameBoard.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitle;
        private Label lblPlayer;
        private Label lblVS;
        private Label lblAI;
        private Label lblPlayerScore;
        private Label lblAIScore;
        private TableLayoutPanel gameBoard;
        private Button btn22;
        private Button btn21;
        private Button btn20;
        private Button btn12;
        private Button btn11;
        private Button btn10;
        private Button btn01;
        private Button btn00;
        private Button btn02;
        private Label lblStatus;
        private Label lblDifficulty;
        private ComboBox cmbDifficulty;
        private Button btnNewGame;
        private Button btnMenu;
        private Label lblMode;
        private ComboBox cmbMode;
    }
}
