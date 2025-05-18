namespace BekeritesForm {
    partial class FileSelect {
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
            InfoLabel = new Label();
            inputTextBox = new TextBox();
            SuspendLayout();
            // 
            // InfoLabel
            // 
            InfoLabel.AutoSize = true;
            InfoLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            InfoLabel.Location = new Point(88, 9);
            InfoLabel.Name = "InfoLabel";
            InfoLabel.Size = new Size(182, 25);
            InfoLabel.TabIndex = 0;
            InfoLabel.Text = "Type in the filename";
            // 
            // inputTextBox
            // 
            inputTextBox.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            inputTextBox.Location = new Point(12, 51);
            inputTextBox.Name = "inputTextBox";
            inputTextBox.Size = new Size(314, 35);
            inputTextBox.TabIndex = 1;
            inputTextBox.KeyPress += inputTextBox_KeyPress;
            // 
            // FileSelect
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(338, 113);
            Controls.Add(inputTextBox);
            Controls.Add(InfoLabel);
            Name = "FileSelect";
            Text = "FileSelect";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label InfoLabel;
        private TextBox inputTextBox;
    }
}