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

        public static event Action<string> _events;

        /// <summary>
        /// Properties of SplashScreen field
        /// </summary>
        public static int Width { get; set; }
        public static int Height { get; set; }

        /// <summary>
        /// Timer for Update Graphics
        /// </summary>
        public static Timer timer = new Timer {Interval = 30};

        /// <summary>
        /// Game Score and lives
        /// </summary>
        public static int score;
        public static int health;
        public const int baseHealth = 100;

        public static Random rnd;

        /// <summary>
        /// Property start X
        /// </summary>
        public static int StartX
        {
            get { return Width; }
        }

        /// <summary>
        /// Property start Y
        /// </summary>
        public static int StartY
        {
            get { return rnd.Next(20, Height - 40); }
        }
        
        /// <summary>
        /// Property Speed
        /// </summary>
        public static int Speed
        {
            get { return rnd.Next(1, 6); }
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
            
            Width = form.Width - 40;
            Height = form.Height - 60;

            Buffer = _context.Allocate(g, new Rectangle(10, 10, Width, Height));

            Load();
            
            _events += Status;
        }

        /// <summary>
        /// Method time tick
        /// Draw and update on tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void Timer_Tick(object sender, EventArgs e)
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

            foreach (BaseObject obj in _objsBullets)
                obj.Draw();
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
                foreach (BaseObject obj in _objsInteraction)
                {
                    obj.Update();
                    foreach (BaseObject bullet in _objsBullets)
                    {
                        if (obj.Collision(bullet))
                        {
                            _objsInteraction.RemoveAt(_objsInteraction.IndexOf(obj));
                            _events += Attack;
                            
                            if (obj is Asteroid)
                                AddAsteroid(1);
                            else if (obj is UFO)
                                AddUFO(1);
                            else if (obj is Healthy)
                                AddHealthy(1);

                            _events += ObjectAdded;

                            _objsBullets.RemoveAt(_objsBullets.IndexOf(bullet));
                            score++;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                // Console.WriteLine(e);
                // throw;
            }

            try
            {
                foreach (BaseObject obj in _objsInteraction)
                {
                    obj.Update();
                    foreach (BaseObject transport in _objsTranspost)
                    {
                        if (obj.Collision(transport))
                        {
                            _objsInteraction.RemoveAt(_objsInteraction.IndexOf(obj));
                            if (obj is Asteroid)
                            {
                                health -= 50;
                                _events += Damage;
                                AddAsteroid(1);
                            }
                            else if (obj is UFO)
                            {
                                health -= 20;
                                _events += Damage;
                                AddUFO(1);
                            }
                            else if (obj is Healthy)
                            {
                                health += 10;
                                _events += HealyIncreased;
                                if (health > baseHealth) health = baseHealth;
                                AddHealthy(1);
                            }

                            if (health <= 0)
                            {
                                _events += TransportDied;
                                _objsTranspost.RemoveAt(_objsTranspost.IndexOf(transport));
                                Form.ActiveForm.Close();
                            }

                            score++;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                // Console.WriteLine(e);
                // throw;
            }

            try
            {
                foreach (BaseObject obj in _objsBullets)
                    obj.Update();
            }
            catch (Exception e)
            {
                // Console.WriteLine(e);
                // throw;
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
            score = 0;
            health = baseHealth;

            _objsBackgound = new List<BaseObject>();
            AddStar(15);
            AddCircle(15);

            _objsBullets = new List<BaseObject>();
            
            _objsInteraction = new List<BaseObject>();
            AddUFO(7);
            AddAsteroid(8);
            
            _objsTranspost = new List<BaseObject>();
            AddTransport();

            AddHealthy(1);

            _objsBackgound.Add(new SplashScreenLabels(new Point(0, 0), new Point(0, 0), new Size(0, 0)));
        }

        /// <summary>
        /// Method Add Star
        /// </summary>
        /// <param name="n">qty of Stars</param>
        public static void AddStar(int n)
        {
            for (int i = 0; i < n; i++)
            {
                _objsBackgound.Add(new Star(new Point(StartX, StartY),
                    new Point(rnd.Next(Speed), 0),
                    new Size(3, 3)));
                _events += ObjectAdded;
            }
        }

        /// <summary>
        /// Method Add Circle
        /// </summary>
        /// <param name="n">qty of Circles</param>
        public static void AddCircle(int n)
        {
            for (int i = 0; i < n; i++)
            {
                _objsBackgound.Add(new Circle(new Point(StartX, StartY),
                    new Point(rnd.Next(Speed), 0),
                    new Size(5, 5)));
                _events += ObjectAdded;
            }
        }

        /// <summary>
        /// Method Add UFO
        /// </summary>
        /// <param name="n">qty of UFOs</param>
        public static void AddUFO(int n)
        {
            for (int i = 0; i < n; i++)
            {
                _objsInteraction.Add(new UFO(new Point(StartX, StartY),
                    new Point(rnd.Next(Speed), 0),
                    new Size(10, 10)));
                _events += ObjectAdded;
            }
        }

        /// <summary>
        /// Method Add Asteroid
        /// </summary>
        /// <param name="n">qty of Asteroids</param>
        public static void AddAsteroid(int n)
        {
            for (int i = 0; i < n; i++)
            {
                _objsInteraction.Add(new Asteroid(new Point(StartX, StartY),
                    new Point(rnd.Next(Speed), 0),
                    new Size(64, 64)));
                _events += ObjectAdded;
            }
        }

        /// <summary>
        /// Method Add Healthy objects
        /// </summary>
        /// <param name="n">qty of healthu objects</param>
        public static void AddHealthy(int n)
        {
            for (int i = 0; i < n; i++)
            {
                _objsInteraction.Add(new Healthy(new Point(StartX, StartY),
                    new Point(rnd.Next(Speed), 0),
                    new Size(43, 43)));
                _events += ObjectAdded;
            }
        }

        /// <summary>
        /// Method Add transport
        /// </summary>
        public static void AddTransport()
        {
            _objsTranspost.Add(new Transport(new Point(20, Height / 2), new Point(0, 0), new Size(64, 64)));
            _events += ObjectAdded;
        }

        /// <summary>
        /// Method current transport status to event
        /// </summary>
        /// <param name="message">text message to event</param>
        public static void Status(string message)
        {
            Console.WriteLine($"{DateTime.Now}: {message} current transport health: {health}");
        }

        /// <summary>
        /// Method sucessfull attack to event
        /// </summary>
        /// <param name="message">text message to event</param>
        public static void Attack(string message)
        {
            Console.WriteLine($"{DateTime.Now}: {message} attack on object, score: {score}");
        }

        /// <summary>
        /// Method show new bullet to event
        /// </summary>
        /// <param name="message">text message to event</param>
        public static void NewBullet(string message)
        {
            Console.WriteLine($"{DateTime.Now}: {message} new bullet");
        }

        /// <summary>
        /// Metohd getting damage to event
        /// </summary>
        /// <param name="message">text message to event</param>
        public static void Damage(string message)
        {
            Console.WriteLine($"{DateTime.Now}: {message} transport damaged, current health: {health}");
        }

        /// <summary>
        /// Method getting healthy to event
        /// </summary>
        /// <param name="message">text message to event</param>
        public static void HealyIncreased(string message)
        {
            Console.WriteLine($"{DateTime.Now}: {message} transport healthy increased, current health: {health}");
        }

        /// <summary>
        /// Method object added to event
        /// </summary>
        /// <param name="message">text message to event</param>
        public static void ObjectAdded(string message)
        {
            Console.WriteLine($"{DateTime.Now}: {message} added");
        }
        
        /// <summary>
        /// Method transport died added to event
        /// </summary>
        /// <param name="message">text message to event</param>
        public static void TransportDied(string message)
        {
            Console.WriteLine($"{DateTime.Now}: {message} transport died");
        }
    }
}
