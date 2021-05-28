/* Copyright (c) 2021 Rick (rick 'at' gibbed 'dot' us)
 *
 * This software is provided 'as-is', without any express or implied
 * warranty. In no event will the authors be held liable for any damages
 * arising from the use of this software.
 *
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, and to alter it and redistribute it
 * freely, subject to the following restrictions:
 *
 * 1. The origin of this software must not be misrepresented; you must not
 *    claim that you wrote the original software. If you use this software
 *    in a product, an acknowledgment in the product documentation would
 *    be appreciated but is not required.
 *
 * 2. Altered source versions must be plainly marked as such, and must not
 *    be misrepresented as being the original software.
 *
 * 3. This notice may not be removed or altered from any source
 *    distribution.
 */

using System;
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
