﻿using System;
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
            Width = 800; // form.Width;
            Height = 600; // form.Height;

            // Связываем буфер в памяти с графическим объектом, чтобы рисовать в буфере
            Buffer = _context.Allocate(g, new Rectangle(10, 10, Width, Height));

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
            int qty = 40;
            int qtyTypes = 4;

            int qtyObjects = qty / qtyTypes;
            _objs = new BaseObject[qty + 3];

            for (int i = 0; i < qtyObjects; i++)
            {
                _objs[i] = new Star(new Point(StartX, StartY),
                    new Point(SplashScreen.rnd.Next(Speed), 0),
                    new Size(3, 3));

                _objs[i + qtyObjects] = new Circle(new Point(StartX, StartY),
                    new Point(SplashScreen.rnd.Next(Speed), 0),
                    new Size(5, 5));

                _objs[i + qtyObjects * 2] = new UFO(new Point(StartX, StartY),
                    new Point(SplashScreen.rnd.Next(Speed), 0),
                    new Size(10, 10));

                _objs[i + qtyObjects * 3] = new Asteroid(new Point(StartX, StartY),
                    new Point(SplashScreen.rnd.Next(Speed), 0),
                    new Size(6, 8));
            }

            _objs[qty] = new SplashScreenLabels(new Point(0, 0), new Point(0, 0), new Size(0, 0));
            _objs[qty + 1] = new Transport(new Point(Height / 2, 20), new Point(0, 0), new Size(64, 64));
        }
    }
}
