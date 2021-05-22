using System;
using System.Collections.Generic;
using SFML.Graphics;
using SFML.Window;
using System.Text;
using SFML.System;

namespace AgarIO
{
    class Game
    {
        private Clock clock = new Clock();
        Player hero = new Player();
        Controller controller;
        public List<Circle> allCircleToDraw = new List<Circle>();
        public List<Food> allFood = new List<Food>();
        public void Start()
        {
            controller = new Controller(hero);
            RenderWindow window = new RenderWindow(new VideoMode(1600, 900), "Game window");

            double time = clock.ElapsedTime.AsMicroseconds();
            clock.Restart();
            time /= 800;

            controller.SpavnFood(allFood, 200);
            allCircleToDraw.Add(hero);         
            #region setupWindow
            window.MouseMoved += OnMouseMoved;
            window.Closed += WindowClosed;
            window.SetMouseCursorVisible(false);
            #endregion 
            while (window.IsOpen)
            {
                window.Clear(Color.White);
                controller.CheckIntersectionWithFood(allFood);
                hero.Move(time);
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
            
            foreach (Circle circle in allFood)
            {
                w.Draw(circle.shape);
            }
            foreach (Circle circle in allCircleToDraw)
            {
                w.Draw(circle.shape);
            }
        }
    }
}
