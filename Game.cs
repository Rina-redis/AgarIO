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
        
        public Time tickRate;
        private Clock timer = new Clock();
        
        Player hero = new Player();
        Controller controller;

        public List<Circle> allCircleToDraw = new List<Circle>();
        public List<Bot> aliveBots = new List<Bot>();
        public List<Food> allFood = new List<Food>();
        public void Start()
        {
            RenderWindow window = setupRenderWindow();
            allCircleToDraw.Add(hero);
            CreateBots(7);
            controller = new Controller(hero);
            
            while (window.IsOpen)
            {
                tickRate = timer.Restart();
                window.Clear(Color.White);

                controller.TryEatFood(allFood);
                SpawnFood(allFood, 100);

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
            
            foreach (Circle circle in allFood)
            {
                w.Draw(circle.shape);
            }
            foreach (Circle circle in allCircleToDraw)
            {
                w.Draw(circle.shape);
            }
            foreach (Circle circle in aliveBots)
            {
                w.Draw(circle.shape);
            }
        }

        public void SpawnFood(List<Food> foodPieces, int numberOfFood)
        {
            for (int i = foodPieces.Count; i < numberOfFood; i++)
            {
                Random rand = new Random();
                int PosX = rand.Next(1, 1600);
                int PosY = rand.Next(1, 900);

                Food pieceOfFood = new Food(PosX, PosY);
                foodPieces.Add(pieceOfFood);
            }
        }
        public RenderWindow setupRenderWindow()
        {
            RenderWindow window = new RenderWindow(new VideoMode(1600, 900), "Game window");
            window.MouseMoved += OnMouseMoved;
            window.Closed += WindowClosed;
            return window;
        }
         public void  CreateBots(int numberOfBots)
        {
            for(int i=1; i<=numberOfBots; i++)
            {
                Bot newBot = new Bot();              
                aliveBots.Add(newBot);
            }
        }
    }
}
