using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameApp
{
    class Program
    {
        static RenderWindow win;

        public static RenderWindow Window { get { return win; } }
        public static Game Game { private set; get; }

        static void Main(string[] args)
        {
            win = new RenderWindow(new SFML.Window.VideoMode(800, 600), "Game");
            win.SetVerticalSyncEnabled(true);

            win.Closed += Win_Closed;
            win.Resized += Win_Resized;

            // Загрузка контента
            Content.Load();

            Game = new Game();

            while (win.IsOpen)
            {
                win.DispatchEvents();

                Game.Update();

                win.Clear(Color.Black);

                Game.Draw();

                // Рисуем здесь
                win.Display();
            }
        }

        private static void Win_Resized(object sender, SizeEventArgs e) {
            win.SetView(new View(new FloatRect(0,0,e.Width,e.Height)));
        }

        private static void Win_Closed(object sender, EventArgs e)
        {
            win.Close();
        }
    }
}
