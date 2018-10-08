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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //Form form = new fmMain();
            ////form.Width = 800;
            ////form.Height = 600;

            //SplashScreen.Init(form);
            //form.KeyPreview = true;

            //form.Show();

            

            //SplashScreen.Draw();
        }

        private void fmMain_KeyDown(object sender, KeyEventArgs e)
        {
            Transport.UpdateOnKeyPress(e);
        }
    }
}
