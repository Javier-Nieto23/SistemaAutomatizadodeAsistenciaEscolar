using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SAAE
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();

            this.Resize += Dashboard_Resize;
            this.Load += Dashboard_Load;
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            CenterPictureBox();
        }

        private void Dashboard_Resize(object sender, EventArgs e)
        {
            CenterPictureBox();
        }

        private void CenterPictureBox()
        {
            if (pictureBox1 != null)
            {
                pictureBox1.Location = new Point(
                    (this.ClientSize.Width - pictureBox1.Width) / 2,
                    (this.ClientSize.Height - pictureBox1.Height) / 2
                );
            }
        }
    }
}
