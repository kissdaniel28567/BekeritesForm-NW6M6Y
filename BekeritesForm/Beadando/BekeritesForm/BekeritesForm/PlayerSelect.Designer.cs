namespace BekeritesForm {
    partial class PlayerSelect {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            player1Label = new Label();
            Player1NameLabel = new Label();
            Player1NameTextBox = new TextBox();
            Player1ColorLabel = new Label();
            Player1ColorTextBox = new TextBox();
            Player2ColorTextBox = new TextBox();
            Player2ColorLabel = new Label();
            Player2NameTextBox = new TextBox();
            Player2NameLabel = new Label();
            Player2Label = new Label();
            submitButton = new Button();
            SuspendLayout();
            // 
            // player1Label
            // 
            player1Label.AutoSize = true;
            player1Label.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            player1Label.Location = new Point(12, 27);
            player1Label.Name = "player1Label";
            player1Label.Size = new Size(74, 25);
            player1Label.TabIndex = 0;
            player1Label.Text = "Player1";
            // 
            // Player1NameLabel
            // 
            Player1NameLabel.AutoSize = true;
            Player1NameLabel.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            Player1NameLabel.Location = new Point(49, 83);
            Player1NameLabel.Name = "Player1NameLabel";
            Player1NameLabel.Size = new Size(52, 20);
            Player1NameLabel.TabIndex = 1;
            Player1NameLabel.Text = "Name:";
            // 
            // Player1NameTextBox
            // 
            Player1NameTextBox.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            Player1NameTextBox.Location = new Point(107, 80);
            Player1NameTextBox.Name = "Player1NameTextBox";
            Player1NameTextBox.Size = new Size(407, 27);
            Player1NameTextBox.TabIndex = 2;
            // 
            // Player1ColorLabel
            // 
            Player1ColorLabel.AutoSize = true;
            Player1ColorLabel.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            Player1ColorLabel.Location = new Point(53, 124);
            Player1ColorLabel.Name = "Player1ColorLabel";
            Player1ColorLabel.Size = new Size(48, 20);
            Player1ColorLabel.TabIndex = 3;
            Player1ColorLabel.Text = "Color:";
            // 
            // Player1ColorTextBox
            // 
            Player1ColorTextBox.Location = new Point(107, 125);
            Player1ColorTextBox.Name = "Player1ColorTextBox";
            Player1ColorTextBox.Size = new Size(407, 23);
            Player1ColorTextBox.TabIndex = 4;
            // 
            // Player2ColorTextBox
            // 
            Player2ColorTextBox.Location = new Point(107, 289);
            Player2ColorTextBox.Name = "Player2ColorTextBox";
            Player2ColorTextBox.Size = new Size(407, 23);
            Player2ColorTextBox.TabIndex = 9;
            // 
            // Player2ColorLabel
            // 
            Player2ColorLabel.AutoSize = true;
            Player2ColorLabel.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            Player2ColorLabel.Location = new Point(53, 288);
            Player2ColorLabel.Name = "Player2ColorLabel";
            Player2ColorLabel.Size = new Size(48, 20);
            Player2ColorLabel.TabIndex = 8;
            Player2ColorLabel.Text = "Color:";
            // 
            // Player2NameTextBox
            // 
            Player2NameTextBox.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            Player2NameTextBox.Location = new Point(107, 244);
            Player2NameTextBox.Name = "Player2NameTextBox";
            Player2NameTextBox.Size = new Size(407, 27);
            Player2NameTextBox.TabIndex = 7;
            // 
            // Player2NameLabel
            // 
            Player2NameLabel.AutoSize = true;
            Player2NameLabel.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            Player2NameLabel.Location = new Point(49, 247);
            Player2NameLabel.Name = "Player2NameLabel";
            Player2NameLabel.Size = new Size(52, 20);
            Player2NameLabel.TabIndex = 6;
            Player2NameLabel.Text = "Name:";
            // 
            // Player2Label
            // 
            Player2Label.AutoSize = true;
            Player2Label.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            Player2Label.Location = new Point(12, 191);
            Player2Label.Name = "Player2Label";
            Player2Label.Size = new Size(74, 25);
            Player2Label.TabIndex = 5;
            Player2Label.Text = "Player2";
            // 
            // submitButton
            // 
            submitButton.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            submitButton.Location = new Point(188, 359);
            submitButton.Name = "submitButton";
            submitButton.Size = new Size(157, 52);
            submitButton.TabIndex = 10;
            submitButton.Text = "Submit";
            submitButton.UseVisualStyleBackColor = true;
            submitButton.Click += submitButton_Click;
            // 
            // PlayerSelect
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(547, 432);
            Controls.Add(submitButton);
            Controls.Add(Player2ColorTextBox);
            Controls.Add(Player2ColorLabel);
            Controls.Add(Player2NameTextBox);
            Controls.Add(Player2NameLabel);
            Controls.Add(Player2Label);
            Controls.Add(Player1ColorTextBox);
            Controls.Add(Player1ColorLabel);
            Controls.Add(Player1NameTextBox);
            Controls.Add(Player1NameLabel);
            Controls.Add(player1Label);
            Name = "PlayerSelect";
            Text = "PlayerSelect";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label player1Label;
        private Label Player1NameLabel;
        private TextBox Player1NameTextBox;
        private Label Player1ColorLabel;
        private TextBox Player1ColorTextBox;
        private TextBox Player2ColorTextBox;
        private Label Player2ColorLabel;
        private TextBox Player2NameTextBox;
        private Label Player2NameLabel;
        private Label Player2Label;
        private Button submitButton;
    }
}