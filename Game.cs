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
        //public Time tickRate;
        // private Clock timer = new Clock();
        Text text;
        Player hero = new Player();
 
        public List<PlayableObject> allCircleToDraw = new List<PlayableObject>();
        // public List<Bot> aliveBots = new List<Bot>();
        public List<Food> allFood = new List<Food>();
        public List <EatableObject> allThingsWhichAreEatble = new List<EatableObject>();
        public void Start()
        {
            text = SetupText();
            RenderWindow window = setupRenderWindow();
            allThingsWhichAreEatble.Add(hero);
         
            CreateBots(5);
                     
            while (window.IsOpen)
            {
                SpawnFood(allThingsWhichAreEatble, 100);
              
                window.Clear(Color.White);
                hero.TryEat(allThingsWhichAreEatble);
                BotsCycle();

                DrawAllObjects(window);                             
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
        public Text SetupText()
        {
            Font font = new Font(@"H:\програмирование\AgarIO\bin\Debug\Data\font.ttf");
            Text text = new Text("jkvjdskcvj",font);
            text.CharacterSize = 24;
            text.FillColor = Color.Red;
            text.Position = new Vector2f(100, 100);            
            return text;

        }
        public void DrawAllObjects(object sender)
        {
            RenderWindow w = (RenderWindow)sender;
            w.Draw(text);
            foreach (EatableObject objectToDraw in allThingsWhichAreEatble)
            {
                w.Draw(objectToDraw.shape);
            }
            w.Draw(hero.shape);
        }

        public void SpawnFood(List<EatableObject> foodPieces, int numberOfFood)
        {
            for (int i = foodPieces.Count; i < numberOfFood; i++)
            {
                Random rand = new Random();             
                Food pieceOfFood = new Food();
                foodPieces.Add(pieceOfFood);
            }
        }
        public RenderWindow setupRenderWindow()
        {
            RenderWindow window = new RenderWindow(new VideoMode(Constants.windowWidth, Constants.windowHeight), "Game window");
            window.SetFramerateLimit(1000);
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
            }
        }

        public void BotsCycle()
        {
  
            for (int i = 0; i < allThingsWhichAreEatble.Count - 1; i++)
            {
                if (allThingsWhichAreEatble[i] is Bot)
                {
                    Bot newBot = (Bot)allThingsWhichAreEatble[i];
                    newBot.Cycle(allThingsWhichAreEatble);
                }

            }
        }
    }
}
