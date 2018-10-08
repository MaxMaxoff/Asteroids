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
            form.Show();
            SplashScreen.Init(form);
            SplashScreen.Draw();
            Application.Run(form);

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
        }
    }
}
