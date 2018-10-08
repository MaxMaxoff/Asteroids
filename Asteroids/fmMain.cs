using System;
using System.Windows.Forms;
using Asteroids.Objects;

namespace Asteroids
{
    public partial class fmMain : Form
    {
        public fmMain()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {

        }

        private void fmMain_KeyDown(object sender, KeyEventArgs e)
        {
            Transport.UpdateOnKeyPress(e);
        }

        private void fmMain_KeyUp(object sender, KeyEventArgs e)
        {
            // Transport.UpdateOnKeyPress(e);
        }

        private void fmMain_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
    }
}
