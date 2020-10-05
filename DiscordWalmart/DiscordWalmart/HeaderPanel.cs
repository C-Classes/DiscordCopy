using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace DiscordWalmart
{
    public class HeaderPanel : Panel
    {
        public Form ParentForm;
        public HeaderPanel(Form form)
        {
            this.Location = new Point(0, 0);
            this.Width = form.Width;
            this.Height = 25;
            this.BackColor = Color.Black;

            ParentForm = form;

            form.Controls.Add(this);
            CloseButton closeButton = new CloseButton(this);
            closeButton.Click += delegate (object sender, EventArgs e)
            {
                closeButton.ThisClick(sender, e, ParentForm);
            };
        }
    }

    public class CloseButton : Button
    {
        private Color _defaultBackColor;

        public void ThisClick(object sender, EventArgs e, Form form)
        {
            form.Close();
        }

        private void CloseButton_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.Red;
        }

        private void CloseButton_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = _defaultBackColor;
        }

        public CloseButton(Panel panel)
        {
            this.Width = 25;
            this.Text = "X";
            this.Height = panel.Height;

            this._defaultBackColor = panel.BackColor;
            this.BackColor = this._defaultBackColor;
            this.ForeColor = Color.White;

            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;

            this.Location = new Point(panel.Width - this.Width, 0);
            panel.Controls.Add(this);

            this.MouseEnter += new EventHandler(CloseButton_MouseEnter);
            this.MouseLeave += new EventHandler(CloseButton_MouseLeave);
        }
    }
}
