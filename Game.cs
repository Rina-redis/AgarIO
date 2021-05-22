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
        public List<Circle> allCircleToDraw = new List<Circle>();
        public List<Food> foodForSpawn = new List<Food>();
        public void Start()
        {
            controller = new Controller(hero);
            RenderWindow window = new RenderWindow(new VideoMode(1600, 900), "Game window");
            controller.SpavnFood(allCircleToDraw, foodForSpawn, 200);
            allCircleToDraw.Add(hero);
           
            #region setupWindow
            window.MouseMoved += OnMouseMoved;
            window.Closed += WindowClosed;
            window.SetMouseCursorVisible(false);
            #endregion 

            //Player hero = new Player();
            while (window.IsOpen)
            {
                window.Clear();
                
                hero.Move();
                DrawAllObjects(window);   
                
                window.DispatchEvents();
                window.Display();
            }
        }

        public void OnMouseMoved(object sender, MouseMoveEventArgs e)
        {           
            controller.SetCoordinateForMovement(e);
        }
        static void WindowClosed(object sender, EventArgs e)
        {
            RenderWindow w = (RenderWindow)sender;
            w.Close();
        }

        public void DrawAllObjects(object sender)
        {
            RenderWindow w = (RenderWindow)sender;
            foreach (Circle circle in allCircleToDraw)
            {
                w.Draw(circle.shape);
            }
        }
    }
}
