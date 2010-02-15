using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Gibbed.MassEffect2.AudioExtract
{
    public partial class SearchBox : Form
    {
        public SearchBox()
        {
            this.InitializeComponent();
        }

        public string InputText
        {
            get { return this.textBox.Text; }
            set { this.textBox.Text = value; }
        }

        private void OnKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r' || e.KeyChar == '\n')
            {
                this.DialogResult = DialogResult.OK;
            }
            else if (e.KeyChar == '\x1B')
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private void OnShown(object sender, EventArgs e)
        {
            this.textBox.Focus();
        }
    }
}
