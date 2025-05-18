namespace BekeritesForm {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            radio6 = new RadioButton();
            radio8 = new RadioButton();
            radio10 = new RadioButton();
            startButton = new Button();
            gameBoard = new Panel();
            debugLabel = new Label();
            button1 = new Button();
            button2 = new Button();
            playerAdderButton = new Button();
            player1NameLabel = new Label();
            player1PointLabel = new Label();
            player2PointLabel = new Label();
            player2NameLabel = new Label();
            SuspendLayout();
            // 
            // radio6
            // 
            radio6.AutoSize = true;
            radio6.Location = new Point(73, 318);
            radio6.Name = "radio6";
            radio6.Size = new Size(78, 29);
            radio6.TabIndex = 0;
            radio6.Text = "6 X 6";
            radio6.UseVisualStyleBackColor = true;
            radio6.Click += RadioHandler;
            // 
            // radio8
            // 
            radio8.AutoSize = true;
            radio8.Checked = true;
            radio8.Location = new Point(73, 373);
            radio8.Name = "radio8";
            radio8.Size = new Size(78, 29);
            radio8.TabIndex = 1;
            radio8.TabStop = true;
            radio8.Text = "8 X 8";
            radio8.UseVisualStyleBackColor = true;
            radio8.Click += RadioHandler;
            // 
            // radio10
            // 
            radio10.AutoSize = true;
            radio10.Location = new Point(73, 428);
            radio10.Name = "radio10";
            radio10.Size = new Size(98, 29);
            radio10.TabIndex = 2;
            radio10.Text = "10 X 10";
            radio10.UseVisualStyleBackColor = true;
            radio10.Click += RadioHandler;
            // 
            // startButton
            // 
            startButton.Location = new Point(73, 557);
            startButton.Margin = new Padding(4, 5, 4, 5);
            startButton.Name = "startButton";
            startButton.Size = new Size(107, 38);
            startButton.TabIndex = 3;
            startButton.Text = "Start";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += startButton_Click;
            // 
            // gameBoard
            // 
            gameBoard.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            gameBoard.Location = new Point(354, 20);
            gameBoard.Margin = new Padding(4, 5, 4, 5);
            gameBoard.MaximumSize = new Size(714, 833);
            gameBoard.MinimumSize = new Size(714, 833);
            gameBoard.Name = "gameBoard";
            gameBoard.Size = new Size(714, 833);
            gameBoard.TabIndex = 4;
            // 
            // debugLabel
            // 
            debugLabel.AccessibleRole = AccessibleRole.None;
            debugLabel.AutoSize = true;
            debugLabel.Location = new Point(17, 772);
            debugLabel.Margin = new Padding(4, 0, 4, 0);
            debugLabel.Name = "debugLabel";
            debugLabel.Size = new Size(105, 25);
            debugLabel.TabIndex = 5;
            debugLabel.Text = "debugLabel";
            debugLabel.Visible = false;
            // 
            // button1
            // 
            button1.Location = new Point(73, 605);
            button1.Margin = new Padding(4, 5, 4, 5);
            button1.Name = "button1";
            button1.Size = new Size(107, 38);
            button1.TabIndex = 6;
            button1.Text = "Save Game";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(73, 653);
            button2.Margin = new Padding(4, 5, 4, 5);
            button2.Name = "button2";
            button2.Size = new Size(107, 38);
            button2.TabIndex = 7;
            button2.Text = "Load Game";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // playerAdderButton
            // 
            playerAdderButton.Location = new Point(73, 492);
            playerAdderButton.Margin = new Padding(4, 5, 4, 5);
            playerAdderButton.Name = "playerAdderButton";
            playerAdderButton.Size = new Size(107, 38);
            playerAdderButton.TabIndex = 9;
            playerAdderButton.Text = "Add PLayer";
            playerAdderButton.UseVisualStyleBackColor = true;
            playerAdderButton.Click += playerAdderButton_Click;
            // 
            // player1NameLabel
            // 
            player1NameLabel.AutoSize = true;
            player1NameLabel.Font = new Font("Segoe UI", 11.25F);
            player1NameLabel.Location = new Point(17, 20);
            player1NameLabel.Margin = new Padding(4, 0, 4, 0);
            player1NameLabel.Name = "player1NameLabel";
            player1NameLabel.Size = new Size(125, 31);
            player1NameLabel.TabIndex = 10;
            player1NameLabel.Text = "Add Player";
            // 
            // player1PointLabel
            // 
            player1PointLabel.AutoSize = true;
            player1PointLabel.Enabled = false;
            player1PointLabel.Font = new Font("Segoe UI", 11.25F);
            player1PointLabel.Location = new Point(44, 73);
            player1PointLabel.Margin = new Padding(4, 0, 4, 0);
            player1PointLabel.Name = "player1PointLabel";
            player1PointLabel.Size = new Size(87, 31);
            player1PointLabel.TabIndex = 11;
            player1PointLabel.Text = "Points: ";
            // 
            // player2PointLabel
            // 
            player2PointLabel.AutoSize = true;
            player2PointLabel.Enabled = false;
            player2PointLabel.Font = new Font("Segoe UI", 11.25F);
            player2PointLabel.Location = new Point(44, 187);
            player2PointLabel.Margin = new Padding(4, 0, 4, 0);
            player2PointLabel.Name = "player2PointLabel";
            player2PointLabel.Size = new Size(87, 31);
            player2PointLabel.TabIndex = 13;
            player2PointLabel.Text = "Points: ";
            // 
            // player2NameLabel
            // 
            player2NameLabel.AutoSize = true;
            player2NameLabel.Font = new Font("Segoe UI", 11.25F);
            player2NameLabel.Location = new Point(17, 133);
            player2NameLabel.Margin = new Padding(4, 0, 4, 0);
            player2NameLabel.Name = "player2NameLabel";
            player2NameLabel.Size = new Size(125, 31);
            player2NameLabel.TabIndex = 12;
            player2NameLabel.Text = "Add Player";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1134, 877);
            Controls.Add(player2PointLabel);
            Controls.Add(player2NameLabel);
            Controls.Add(player1PointLabel);
            Controls.Add(player1NameLabel);
            Controls.Add(playerAdderButton);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(debugLabel);
            Controls.Add(gameBoard);
            Controls.Add(startButton);
            Controls.Add(radio10);
            Controls.Add(radio8);
            Controls.Add(radio6);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            Text = " Bekerites Jatek";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RadioButton radio6;
        private RadioButton radio8;
        private RadioButton radio10;
        private Button startButton;
        private Panel gameBoard;
        private Label debugLabel;
        private Button button1;
        private Button button2;
        private Button playerAdderButton;
        private Label player1NameLabel;
        private Label player1PointLabel;
        private Label player2PointLabel;
        private Label player2NameLabel;
    }
}
