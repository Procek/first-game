using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace GraProckowa
{
    class Game
    {
        class Canvas : Form
        {
            public Canvas()
            {
                this.DoubleBuffered = true;
            }
        }

        Vector screenSize = new Vector(512, 512);
        string title = "New Game";
        Canvas window = null;
        Thread gameLoopThread = null;

        Hero procek = new Hero();
        Location dungeon = new Location(70, 28, 5);
        List<Mob> mobList = new List<Mob>();
        List<Projectile> projectileList = new List<Projectile>();
        Dictionary<int, Sprite> spriteList = new Dictionary<int, Sprite>();        

        Color backgroundColour = Color.Black;
        public Vector cameraPosition = Vector.Zero(); //cccccccccccccc
        public Game(Vector screenSize, string title)
        {
            this.screenSize = screenSize;
            this.title = title;

            LoadSprites.Load(spriteList);
            dungeon.CreateArea();
            dungeon.LoadCreatures(mobList, procek);

            window = new Canvas();
            window.Size = new Size((int)this.screenSize.x, (int)this.screenSize.y);
            window.Text = this.title;
            window.Paint += Renderer;
            window.KeyDown += Window_KeyDown;
            window.KeyUp += Window_KeyUp;

            gameLoopThread = new Thread(GameLoop);
            gameLoopThread.Start();
            
            Application.Run(window);
        }

        bool left;
        bool right;
        bool up;
        bool down;

        public void GetKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W) { up = true; }
            if (e.KeyCode == Keys.S) { down = true; }
            if (e.KeyCode == Keys.A) { left = true; }
            if (e.KeyCode == Keys.D) { right = true; }
        }

        public void GetKeyUp(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W) { up = false; }
            if (e.KeyCode == Keys.S) { down = false; }
            if (e.KeyCode == Keys.A) { left = false; }
            if (e.KeyCode == Keys.D) { right = false; }
        }
        
        void GameLoop()
        {
            backgroundColour = Color.Black;
            while (gameLoopThread.IsAlive)
            {
                try
                {
                    window.BeginInvoke((MethodInvoker)delegate { window.Refresh(); });                    

                    if (up)
                    {
                        procek.Action(dungeon, mobList, 'w');
                    }
                    else if (down)
                    {
                        procek.Action(dungeon, mobList, 's');
                    }
                    else if (left)
                    {
                        procek.Action(dungeon, mobList, 'a');
                    }
                    else if (right)
                    {
                        procek.Action(dungeon, mobList, 'd');
                    }
                    else
                    {
                        procek.Action(dungeon, mobList, 'i'); //????????
                    }
                    
                    for (int i = 0; i < mobList.Count; i++)
                    {
                        mobList[i].Action(dungeon, procek, projectileList);
                    }

                    for (int i = 0; i < projectileList.Count; i++)
                    {
                        if (projectileList[i].Fly(dungeon, procek) == false)
                        {
                            projectileList.RemoveAt(i);
                            i--;
                        }
                    }
                    cameraPosition.x = procek.screenPosition.x; cameraPosition.y = procek.screenPosition.y; //ccccccccccccccc
                    Thread.Sleep(1);
                }
                catch
                {
                    Console.WriteLine("Window has not been found");
                }
            }
        }

        private void Renderer(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;            
            
            g.Clear(backgroundColour);
            g.TranslateTransform(cameraPosition.x, cameraPosition.y); //cccccccccccccccccccc
            for (int i = 0; i < dungeon.area.GetLength(1); i++)
            {
                for (int j = 0; j < dungeon.area.GetLength(0); j++)
                {
                    if (dungeon.area[j, i, 2] != 0)
                    {
                        g.DrawImage(spriteList[dungeon.area[j, i, 2]].spriteFinish, //var dejva
                                    j * 45 + spriteList[dungeon.area[j, i, 2]].shift.x,
                                    i * 45 + spriteList[dungeon.area[j, i, 2]].shift.y,
                                    spriteList[dungeon.area[j, i, 2]].scale.x,
                                    spriteList[dungeon.area[j, i, 2]].scale.y);
                    }
                }
            }

            for (int i = 0; i < dungeon.area.GetLength(1); i++)
            {
                for (int j = 0; j < dungeon.area.GetLength(0); j++)
                {
                    if (dungeon.area[j, i, 3] != 0)
                    {
                        g.DrawImage(spriteList[dungeon.area[j, i, 3]].spriteFinish,
                                    j * 45 + spriteList[dungeon.area[j, i, 3]].shift.x, 
                                    i * 45 + spriteList[dungeon.area[j, i, 3]].shift.y, 
                                    spriteList[dungeon.area[j, i, 3]].scale.x, 
                                    spriteList[dungeon.area[j, i, 3]].scale.y);
                    }
                }
            }            
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            GetKeyUp(e);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            GetKeyDown(e);
        }
    }
}
