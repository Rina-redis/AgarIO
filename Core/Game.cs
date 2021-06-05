using System;
using System.Collections.Generic;
using SFML.Graphics;
using SFML.Window;

namespace AgarIO
{
    class Game
    {
        private Player hero = new Player();
        private UI gameUI = new UI();
        private List<Food> food = new List<Food>();
        private List<Bot> bots = new List<Bot>();
        private List<Player> players= new List<Player>(); 
      
        public void Start()
        {
            SetupGame();                   
            while (CanPlay())
            {
                GameCycle();
            }         
        }
        private void SetupGame()
        {
            CreateBots(2);
            gameUI.Init();
            ConnectEvents();
        }
        private void GameCycle()
        {                       
            SpawnFood(food, 100);          
            gameUI.window.Clear(Color.White);

            hero.TryEat(food, bots);
            gameUI.DrawText(hero.GetRadius());
            BotsCycle();

            DrawAllObjectsWithUi();
            gameUI.EndUi();
        }
       
        private void SpawnFood(List<Food> foodPieces, int numberOfFood)
        {
            for (int i = foodPieces.Count; i < numberOfFood; i++)
            {                 
                Food pieceOfFood = new Food();
                foodPieces.Add(pieceOfFood);
            }
        }
      
        private void CreateBots(int numberOfBots)
        {
            for(int i=1; i<=numberOfBots; i++)
            {
                Bot newBot = new Bot();
                bots.Add(newBot);             
            }
        }

        private void BotsCycle()
        {          
            foreach(Bot bot in bots)
            {
               bot.Cycle(food, players);
            }
        }
        private void DrawAllObjectsWithUi()
        {
            foreach (EatableObject objectToDraw in bots)
            {
                gameUI.DrawObject(objectToDraw.shape);
            }
            foreach (EatableObject objectToDraw in food)
            {
                gameUI.DrawObject(objectToDraw.shape);
            }
            gameUI.DrawObject(hero.shape);
        }
        private void ConnectEvents()
        {
            gameUI.window.KeyPressed += OnKeyPressed; //kak to po ploho...
            gameUI.window.MouseMoved += OnMouseMoved;
            gameUI.window.Closed += WindowClosed;
        }
        private void OnMouseMoved(object sender, MouseMoveEventArgs e)
        {
            hero.SetCoordinateForMovement(e);
        }
        private void OnKeyPressed(object sender, KeyEventArgs e)
        {
            if (e.Code == Keyboard.Key.F)
            {
                int botNumber = MathHelper.RandomNumber(bots.Count);
                hero.ChangeCurrentBodyToBot(bots, botNumber);
            }
        }
        private static void WindowClosed(object sender, EventArgs e)
        {
            RenderWindow w = (RenderWindow)sender;
            w.Close();
        }
        private bool CanPlay()
        {
            if (hero.GetRadius() < 300)
            {
                return true;
            }
            else
            {
                return false;
            }           
        }
    }
}
