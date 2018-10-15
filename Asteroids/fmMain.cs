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
            if (form.Width > 1200 || form.Width < 0 || form.Height > 1000 || form.Height < 0)
                throw new ArgumentOutOfRangeException("Incorrect Screen size!");

            form.KeyDown += Transport.UpdateOnKeyDown;
            form.KeyUp += Transport.UpdateOnKeyUp;
            form.FormClosing += form_FormClosing;

            form.Show();
            SplashScreen.Init(form);
            SplashScreen.Draw();
            
            SplashScreen.timer.Stop();
            SplashScreen.timer.Tick -= SplashScreen.Timer_Tick;

            SplashScreen.timer.Start();
            SplashScreen.timer.Tick += SplashScreen.Timer_Tick;
        }

        private void form_FormClosing(object sender, FormClosingEventArgs e)
        {
            SplashScreen.timer.Stop();
            MessageBox.Show($"Game Over. Your score is {SplashScreen.score}");
            SplashScreen._objsBullets.Clear();
            SplashScreen._objsBackgound.Clear();
            SplashScreen._objsInteraction.Clear();
            SplashScreen._objsTranspost.Clear();
        }
    }
}
