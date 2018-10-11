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
            Form form = new Form();
            form.Width = 900;
            form.Height = 600;
            if (form.Width > 1000 || form.Width < 0 || form.Height > 1000 || form.Height < 0)
                throw new ArgumentOutOfRangeException("Некорректный размер окна игры");

            form.KeyDown += form_KeyDown;

            form.Show();
            SplashScreen.Init(form);
            SplashScreen.Draw();
            SplashScreen.timer.Tick -= SplashScreen.Timer_Tick;
            SplashScreen.timer.Tick += SplashScreen.Timer_Tick;
        }

        private void form_KeyDown(object sender, KeyEventArgs e)
        {
            Transport.UpdateOnKeyPress(e);
        }

        private void fmMain_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void fmMain_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void fmMain_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void fmMain_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}
