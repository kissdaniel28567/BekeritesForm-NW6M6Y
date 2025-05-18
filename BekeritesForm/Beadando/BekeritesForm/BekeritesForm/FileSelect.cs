using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BekeritesForm {
    public partial class FileSelect : Form {

        public string InputText { get; private set; }
        public FileSelect() {
            InitializeComponent();
            InputText = "Hello. This is needed for the NuGet package :)";
        }

        private void inputTextBox_KeyPress(object sender, KeyPressEventArgs e) {
            if(e.KeyChar == (char)Keys.Enter) {
                InputText = inputTextBox.Text;
                DialogResult = DialogResult.OK;
            }
        }
    }
}
