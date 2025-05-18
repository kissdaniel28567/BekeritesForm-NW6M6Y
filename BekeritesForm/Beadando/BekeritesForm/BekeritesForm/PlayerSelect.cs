using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BekeritesForm {
    public partial class PlayerSelect : Form {
        public String[] Players { get; private set; }
        public PlayerSelect() {
            InitializeComponent();
            Players = new string[2];
        }

        private void submitButton_Click(object sender, EventArgs e) {
            if (Player1NameTextBox.Text != "" && Player1ColorTextBox.Text != ""
            && Player2NameTextBox.Text != "" && Player2ColorTextBox.Text != ""
            && IsColor(Player1ColorTextBox.Text) && IsColor(Player2ColorTextBox.Text)
            && Player1ColorTextBox.Text != Player2ColorTextBox.Text
            && Color.FromName(Player1ColorTextBox.Text) != Color.FromName(Player2ColorTextBox.Text.ToLower())) {

                Players[0] = $"{Player1NameTextBox.Text},{Player1ColorTextBox.Text}";
                Players[1] = $"{Player2NameTextBox.Text},{Player2ColorTextBox.Text}";
                //MessageBox.Show("!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.DialogResult = DialogResult.OK;


            } else {
                Player1NameTextBox.Text = "";
                Player2NameTextBox.Text = "";
                Player1ColorTextBox.Text = "";
                Player2ColorTextBox.Text = "";
                MessageBox.Show("Something is wrong! Please enter valid values!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static bool IsColor(string colorName) {
            var colorProperties = typeof(Color).GetProperties(BindingFlags.Static | BindingFlags.Public)
                .Where(p => p.PropertyType == typeof(Color)); 
            foreach (var prop in colorProperties) { 
                if (prop.Name.Equals(colorName, StringComparison.OrdinalIgnoreCase)) { 
                    return colorName.ToLower() != "white"; 
                }
            }
            return false;
        }
    }
}
