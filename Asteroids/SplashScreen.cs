using System;
using System.Drawing;
using System.Windows.Forms;

namespace Asteroids
{
    class SplashScreen
    {

        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;

        /// <summary>
        /// Properties of SplashScreen field
        /// </summary>
        public static int Width { get; set; }
        public static int Height { get; set; }

        public static Random rnd;


        /// <summary>
        /// Property start X
        /// </summary>
        public static int StartX
        {
            get { return Width / 2 + rnd.Next(-20, 21); }
        }

        /// <summary>
        /// Property start Y
        /// </summary>
        public static int StartY
        {
            get { return Height / 2 + rnd.Next(-20, 21); }
        }
        
        /// <summary>
        /// Property Speed
        /// </summary>
        public static int Speed
        {
            get { return (Width + Height) / 60; }
        }
        
        /// <summary>
        /// Default ctor
        /// </summary>
        static SplashScreen()
        {
            rnd = new Random();
        }

        /// <summary>
        /// Method Init
        /// </summary>
        /// <param name="form">form object</param>
        public static void Init(Form form)
        {
            Graphics g;
            
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();

            // Создаем объект (поверхность рисования) и связываем его с формой
            // Запоминаем размеры формы
            Width = form.Width;
            Height = form.Height;

            // Связываем буфер в памяти с графическим объектом, чтобы рисовать в буфере
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));

            Load();

            Timer timer = new Timer {Interval = 100};
            timer.Start();
            timer.Tick += Timer_Tick;

        }

        /// <summary>
        /// Method time tick
        /// Draw and update on tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        /// <summary>
        /// Method Draw
        /// </summary>
        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in _objs)
                obj.Draw();
            Buffer.Render();

        }

        /// <summary>
        /// Method Update
        /// </summary>
        public static void Update()
        {
            foreach (BaseObject obj in _objs)
                obj.Update();
        }

        /// <summary>
        /// Array of objects
        /// </summary>
        public static BaseObject[] _objs;

        /// <summary>
        /// Method Load
        /// </summary>
        public static void Load()
        {
            _objs = new BaseObject[100];
            
            for (int i = 0; i < _objs.Length / 4; i++)
                _objs[i] = new BaseObject(new Point(StartX, StartY), new Point(SplashScreen.rnd.Next(-Speed, Speed), SplashScreen.rnd.Next(-Speed, Speed)), new Size(5, 5));

            for (int i = _objs.Length / 4; i < _objs.Length / 4 * 2; i++)
                _objs[i] = new Star(new Point(StartX, StartY), new Point(SplashScreen.rnd.Next(-Speed, Speed), SplashScreen.rnd.Next(-Speed, Speed)), new Size(3, 3));

            for (int i = _objs.Length / 4 * 2; i < _objs.Length / 4 * 3; i++)
                _objs[i] = new UFO(new Point(StartX, StartY), new Point(SplashScreen.rnd.Next(-Speed, Speed), SplashScreen.rnd.Next(-Speed, Speed)), new Size(10, 10));

            for (int i = _objs.Length / 4 * 3; i < _objs.Length; i++)
                _objs[i] = new Asteroid(new Point(StartX, StartY), new Point(SplashScreen.rnd.Next(-Speed, Speed), SplashScreen.rnd.Next(-Speed, Speed)), new Size(6, 8));
        }
    }
}
