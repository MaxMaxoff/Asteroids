using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Asteroids.Objects;

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

        /// <summary>
        /// Property of Object
        /// </summary>
        public static int TypicalSize
        {
            get { return rnd.Next(1, 11); }
        }

        public static Random rnd;


        /// <summary>
        /// Property start X
        /// </summary>
        public static int StartX
        {
            //get { return Width / 2 + rnd.Next(-20, 21); }
            get { return Width; }
        }

        /// <summary>
        /// Property start Y
        /// </summary>
        public static int StartY
        {
            //get { return Height / 2 + rnd.Next(-20, 21); }
            get { return rnd.Next(20, Height - 40); }
        }
        
        /// <summary>
        /// Property Speed
        /// </summary>
        public static int Speed
        {
            //get { return (Width + Height) / 60; }
            get { return TypicalSize * 3; }
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
            Width = 800; // form.Width;
            Height = 600; // form.Height;

            // Связываем буфер в памяти с графическим объектом, чтобы рисовать в буфере
            Buffer = _context.Allocate(g, new Rectangle(10, 10, Width, Height));

            Load();

            Timer timer = new Timer {Interval = 50};
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

            foreach (BaseObject obj in _objsBackgound)
                obj.Draw();

            foreach (BaseObject obj in _objsInteraction)
                obj.Draw();

            foreach (BaseObject obj in _objsTranspost)
                obj.Draw();

            try
            {
                foreach (BaseObject obj in _objsBullets)
                    obj.Draw();
            }
            catch (Exception e)
            {
                //Console.WriteLine(e);
                //throw;
            }


            Buffer.Render();
        }

        /// <summary>
        /// Method Update
        /// </summary>
        public static void Update()
        {
            foreach (BaseObject obj in _objsBackgound)
                obj.Update();

            foreach (BaseObject obj in _objsInteraction)
                obj.Update();

            foreach (BaseObject obj in _objsTranspost)
                obj.Update();

            try
            {
                foreach (BaseObject obj in _objsBullets)
                    obj.Update();
            }
            catch (Exception e)
            {
                //Console.WriteLine(e);
                //throw;
            }
            

        }

        /// <summary>
        /// Array of objects
        /// </summary>
        //public static BaseObject[] _objs;
        public static List<BaseObject> _objsBackgound;
        public static List<BaseObject> _objsInteraction;
        public static List<BaseObject> _objsTranspost;
        public static List<BaseObject> _objsBullets;

        /// <summary>
        /// Method Load
        /// </summary>
        public static void Load()
        {
            _objsBackgound = new List<BaseObject>();
            _objsBullets = new List<BaseObject>();
            _objsInteraction = new List<BaseObject>();
            _objsTranspost = new List<BaseObject>();

            int qty = 40;
            int qtyTypes = 4;

            int qtyObjects = qty / qtyTypes;

            for (int i = 0; i < 15; i++)
            {
                _objsBackgound.Add(new Star(new Point(StartX, StartY),
                    new Point(SplashScreen.rnd.Next(TypicalSize), 0),
                    new Size(3, 3)));

                _objsBackgound.Add(new Circle(new Point(StartX, StartY),
                    new Point(SplashScreen.rnd.Next(Speed), 0),
                    new Size(5, 5)));
            }

            for (int i = 0; i < 7; i++)
            {
                _objsInteraction.Add(new UFO(new Point(StartX, StartY),
                    new Point(SplashScreen.rnd.Next(Speed), 0),
                    new Size(10, 10)));
            }

            for (int i = 0; i < 8; i++)
            {
            _objsInteraction.Add(new Asteroid(new Point(StartX, StartY),
                    new Point(SplashScreen.rnd.Next(Speed), 0),
                    new Size(6, 8)));
            }

            _objsBackgound.Add(new SplashScreenLabels(new Point(0, 0), new Point(0, 0), new Size(0, 0)));
            _objsTranspost.Add(new Transport(new Point(Height / 2, 20), new Point(0, 0), new Size(64, 64)));
            //_objsBullets.Add(new Bullet(new Point(Transport.positionX + 65, Transport.positionY + 32),
            //    new Point(Transport.positionX + 65, Transport.positionY + 32), new Size(5, 5)));
        }
    }
}
