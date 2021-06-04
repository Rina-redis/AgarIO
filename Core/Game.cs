using System;
using System.Collections.Generic;
using SFML.Graphics;
using SFML.Window;
using Game.Interfaces;
using System.Text;
using SFML.System;

namespace AgarIO
{
    class Game
    {
        private Text textToDraw = new Text(); // должен быть как юай
        private Player hero;
        private Font font = new Font(@"H:\програмирование\AgarIO\bin\Debug\Data\milk.otf");

        private List<Food> food = new List<Food>();
        private List<Bot> bots = new List<Bot>();
        private List<Player> players= new List<Player>();
      
   //     public List<IEatable> eatables = new List<IEatable>();

        public void Start()
        {
            hero = new Player();
            RenderWindow window = setupRenderWindow();
            players.Add(hero);
         
            CreateBots(1);
                     
            while (window.IsOpen)
            {
                textToDraw = hero.ChangeText(font);
                SpawnFood(food, 100);
              
                window.Clear(Color.White);
                hero.TryEat(food,bots);
                BotsCycle();

                
                DrawAllObjects(window);                             
                window.DispatchEvents();
                window.Display();
            }
        }

        private void OnMouseMoved(object sender, MouseMoveEventArgs e)
        {
            hero.SetCoordinateForMovement(e);
        }
        private void OnKeyPressed(object sender, KeyEventArgs e)
        {
            if (e.Code == Keyboard.Key.F)
            {
                int botNumber = GetRandomBotNumber();
                hero.ChangeCurrentBodyToBot(bots, botNumber);
            }
        }

        public void Change(Player player, List<Bot> bots)
        {
            int botNumber = GetRandomBotNumber();          
          //  Player newPlayer = bots[botNumber];
        }
        private static void WindowClosed(object sender, EventArgs e)
        {
            RenderWindow w = (RenderWindow)sender;
            w.Close();
        }

        private void DrawAllObjects(object sender)
        {
            RenderWindow w = (RenderWindow)sender;      
            foreach (EatableObject objectToDraw in bots)
            {
                w.Draw(objectToDraw.shape);
            }
            foreach (EatableObject objectToDraw in food)
            {
                w.Draw(objectToDraw.shape);
            }
            w.Draw(hero.shape);
            w.Draw(textToDraw);
        }

        private int GetRandomBotNumber()
        {
            Random random = new Random();
            return random.Next(0, bots.Count);
        }
        private void SpawnFood(List<Food> foodPieces, int numberOfFood)
        {
            for (int i = foodPieces.Count; i < numberOfFood; i++)
            {
                Random rand = new Random();             
                Food pieceOfFood = new Food();
                foodPieces.Add(pieceOfFood);
            }
        }
        private RenderWindow setupRenderWindow()
        {
            RenderWindow window = new RenderWindow(new VideoMode(Constants.windowWidth, Constants.windowHeight), "Game window");
            window.SetFramerateLimit(1000);
            window.KeyPressed += OnKeyPressed;
            window.MouseMoved += OnMouseMoved;
            window.Closed += WindowClosed;
            return window;
        }
        private void CreateBots(int numberOfBots)
        {
            for(int i=1; i<=numberOfBots; i++)
            {
                Bot newBot = new Bot();
                bots.Add(newBot);
               // allThingsWhichAreEdible.Add(newBot);
            }
        }

        private void BotsCycle()
        {          
            foreach(Bot bot in bots)
            {
               bot.Cycle(food, players);
            }
        }
    }
}
