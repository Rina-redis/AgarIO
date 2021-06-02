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
        Text textToDraw = new Text(); // должен быть как юай
        Player hero;
        Font font = new Font(@"H:\програмирование\AgarIO\bin\Debug\Data\milk.otf");
        public List<PlayableObject> allCircleToDraw = new List<PlayableObject>();     
        public List<Food> allFood = new List<Food>();
        public List<Bot> botList;
        public List <EatableObject> allThingsWhichAreEatble = new List<EatableObject>();

        public void Start()
        {
            hero = new Player();
            RenderWindow window = setupRenderWindow();
            allThingsWhichAreEatble.Add(hero);
         
            CreateBots(1);
                     
            while (window.IsOpen)
            {
                textToDraw = hero.ChangeText(font);
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
        public void OnKeyPressed(object sender, KeyEventArgs e)
        {
            if (e.Code == Keyboard.Key.F)
            {
                int botNumber = GetRandomBotNumber();
                hero.ChangeCurrentBodyToBot(botList, botNumber);
            }
        }

        public void Change(Player player, List<Bot> bots)
        {
            int botNumber = GetRandomBotNumber();          
          //  Player newPlayer = bots[botNumber];
        }
        static void WindowClosed(object sender, EventArgs e)
        {
            RenderWindow w = (RenderWindow)sender;
            w.Close();
        }

        public void DrawAllObjects(object sender)
        {
            RenderWindow w = (RenderWindow)sender;
            w.Draw(textToDraw);
            foreach (EatableObject objectToDraw in allThingsWhichAreEatble)
            {
                w.Draw(objectToDraw.shape);
            }
            w.Draw(hero.shape);
        }

        public int GetRandomBotNumber()
        {
            Random random = new Random();
            return random.Next(0, botList.Count);
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
            window.KeyPressed += OnKeyPressed;
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
            botList = new List<Bot>();
            for (int i = 0; i < allThingsWhichAreEatble.Count - 1; i++)
            {
                if (allThingsWhichAreEatble[i] is Bot)
                {                  
                    Bot newBot = (Bot)allThingsWhichAreEatble[i];
                    botList.Add(newBot);
                    newBot.Cycle(allThingsWhichAreEatble);
                }

            }
        }
    }
}
