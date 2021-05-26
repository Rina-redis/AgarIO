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
 
        public List<PlayableObject> allCircleToDraw = new List<PlayableObject>();
        public List<Bot> aliveBots = new List<Bot>();
        public List<Food> allFood = new List<Food>();
        public List <EatableObject> allThingsWhichAreEatble = new List<EatableObject>();
        public void Start()
        {
            RenderWindow window = setupRenderWindow();
            allThingsWhichAreEatble.Add(hero);
            allCircleToDraw.Add(hero);
            CreateBots(7);
           // controller = new Controller(hero);
            
            while (window.IsOpen)
            {
                tickRate = timer.Restart();
                window.Clear(Color.White);

                hero.TryEat(allThingsWhichAreEatble);
                SpawnFood(all, 100);

                
                DrawAllObjects(window);
                BotsCycle();
                
                window.DispatchEvents();
                window.Display();
            }
        }

        public void OnMouseMoved(object sender, MouseMoveEventArgs e)
        {
            hero.SetCoordinateForMovement(e);
        }
        static void WindowClosed(object sender, EventArgs e)
        {
            RenderWindow w = (RenderWindow)sender;
            w.Close();
        }

        public void DrawAllObjects(object sender)
        {
            RenderWindow w = (RenderWindow)sender;
            
            foreach(EatableObject objectToDraw in allThingsWhichAreEatble)
            {
                w.Draw(objectToDraw.shape);
            }
            //foreach (Food food in allFood)
            //{
            //    w.Draw(food.shape);
            //}
            foreach (PlayableObject circle in allCircleToDraw)
            {
                w.Draw(circle.shape);
            }
            foreach (PlayableObject circle in aliveBots)
            {
                w.Draw(circle.shape);
            }
        }

        public void SpawnFood(List<Food> foodPieces, int numberOfFood)
        {
            for (int i = foodPieces.Count; i < numberOfFood; i++)
            {
                Random rand = new Random();             
                Food pieceOfFood = new Food();
                allThingsWhichAreEatble.Add(pieceOfFood);
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
         public void CreateBots(int numberOfBots)
        {
            for(int i=1; i<=numberOfBots; i++)
            {
                Bot newBot = new Bot();
                allThingsWhichAreEatble.Add(newBot);
                aliveBots.Add(newBot);
            }
        }

        public void BotsCycle()
        {
            foreach(Bot bot in aliveBots)
            {
                bot.Cycle(allThingsWhichAreEatble);
            }
        }
    }
}
