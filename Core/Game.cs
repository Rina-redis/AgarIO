using System;
using System.Collections.Generic;
using SFML.Graphics;
using SFML.Window;
using System.Linq;

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
            players.Add(hero);       
            CreateBots(3);

            gameUI.Init();
            gameUI.window.KeyPressed += OnKeyPressed; //kak to po uyebanski...
            gameUI.window.MouseMoved += OnMouseMoved;
            gameUI.window.Closed += WindowClosed;

            while (true)
            {
                GameCycle();
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
                int botNumber = MathHelper.RandomNumber(bots.Count);
                hero.ChangeCurrentBodyToBot(bots, botNumber);
            }
        }
        private static void WindowClosed(object sender, EventArgs e)
        {
            RenderWindow w = (RenderWindow)sender;
            w.Close();
        }

        private void GameCycle()
        {                       
            SpawnFood(food, 100);          
            gameUI.window.Clear(Color.White);

            hero.TryEat(food, bots);
            gameUI.DrawText(hero.GetRadius());
            BotsCycle();

            DrawAllObjects();
            gameUI.EndUi();
        }
        private void DrawAllObjects()
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
        private void SpawnFood(List<Food> foodPieces, int numberOfFood)
        {
            for (int i = foodPieces.Count; i < numberOfFood; i++)
            {
                Random rand = new Random();             
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
    }
}
