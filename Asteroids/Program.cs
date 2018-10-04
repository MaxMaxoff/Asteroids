using System;
using System.Windows.Forms;

namespace Asteroids
{
    class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Form form = new fmMain();
            //form.Width = 940;
            //form.Height = 660;

            //Game.Init(form);
            //form.Show();
            //Game.Draw();
            //Application.Run(form);

            SplashScreen.Init(form);
            form.Show();
            SplashScreen.Draw();
            Application.Run(form);

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
        }
    }
}
