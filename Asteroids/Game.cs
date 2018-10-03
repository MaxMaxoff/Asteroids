using System;
using System.Drawing;
using System.Windows.Forms;

namespace Asteroids
{
    static class Game
    {
        
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;

        private static int speed;

        /// <summary>
        /// Properties of game field
        /// </summary>
        public static int Width { get; set; }
        public static int Height { get; set; }

        public static int Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public static Random rnd;
        
        /// <summary>
        /// Default ctor
        /// </summary>
        static Game()
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
            Speed = (Width + Height) / 30;

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
            // Проверяем вывод графики
            //Buffer.Graphics.Clear(Color.Black);
            //Buffer.Graphics.DrawRectangle(Pens.White, new Rectangle(100, 100, 200, 200));
            //Buffer.Graphics.FillEllipse(Brushes.Wheat, new Rectangle(100, 100, 200, 200));
            //Buffer.Render();

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
                _objs[i] = new BaseObject(new Point(Width / 2, Height / 2), new Point(rnd.Next(0, 20) - 10, rnd.Next(0, 20) - 10), new Size(2, 2));

            for (int i = _objs.Length / 4; i < _objs.Length / 4 * 2; i++)
                _objs[i] = new Star(new Point(Width / 2, Height / 2), new Point(Game.rnd.Next(0, Speed + 1) - Speed / 2, Game.rnd.Next(0, Speed + 1) - Speed / 2), new Size(3, 3));

            for (int i = _objs.Length / 4 * 2; i < _objs.Length / 4 * 3; i++)
                _objs[i] = new UFO(new Point(Width / 2, Height / 2), new Point(Game.rnd.Next(0, Speed + 1) - Speed / 2, Game.rnd.Next(0, Speed + 1) - Speed / 2), new Size(6, 8));

            for (int i = _objs.Length / 4 * 3; i < _objs.Length; i++)
                _objs[i] = new Asteroid(new Point(Width / 2, Height / 2), new Point(Game.rnd.Next(0, Speed + 1) - Speed / 2, Game.rnd.Next(0, Speed + 1) - Speed / 2), new Size(6, 8));
        }
    }
}
