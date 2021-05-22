using System;
using System.Collections.Generic;
using SFML.Graphics;
using SFML.Window;
using System.Text;

namespace AgarIO
{
    class Game
    {
        Player hero = new Player();
        Controller controller;
        public void Start()
        {
            RenderWindow window = new RenderWindow(new VideoMode(1600, 900), "Game window");
            window.Closed += WindowClosed;

            while (window.IsOpen)
            {
                window.DispatchEvents();

                window.Clear(Color.Green);

                window.Display();
            }
        }
        private void WindowKeyPresser(object sender, KeyEventArgs e)
        {
            controller.Controll(e.Code);
        }
        static void WindowClosed(object sender, EventArgs e)
        {
            RenderWindow w = (RenderWindow)sender;
            w.Close();
        }
    }
}
