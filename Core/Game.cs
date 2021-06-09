using System;
using System.Collections.Generic;
using AgarIO.Units;
using AgarIO.Utilits;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace AgarIO.Core
{
    class Game
    {
        private HumanController heroController= new HumanController();
        private Powel hero;
        private UI gameUI = new UI();
        private List<Food> food = new List<Food>();
        private List<Powel> actors = new List<Powel>();
       // private List<Powel> players = new List<Powel>();

        public void Start()
        {
            hero = new Powel(heroController);
            actors.Add(hero);
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
            SpawnFood(food, 100);//
            hero.TryEat(food);
            BotsCycle();

            gameUI.window.Clear(Color.White);
            gameUI.DrawText(hero.GetRadius());          
            DrawAllObjectsWithUi();
            gameUI.EndUi();
        }

        private void SpawnFood(List<Food> foofList, int numberOfFood)
        {
            for (int i = foofList.Count; i < numberOfFood; i++)
            {
                Food pieceOfFood = new Food();
                foofList.Add(pieceOfFood);
            }
        }

        private void CreateBots(int numberOfBots)
        {
            for (int i = 1; i <= numberOfBots; i++)
            {
                AIController botController = new AIController();
                Powel newBot = new Powel(botController);
                actors.Add(newBot);
            }
        }

        private void BotsCycle()
        {
            foreach (Powel actor in actors)
            {
                if (actor.powelController is AIController) 
                {
                    Vector2f directionToMove = actor.powelController.DirectionToMove(actor, food, actors);                    
                    actor.Move(directionToMove);
                    actor.TryEat(food);
                }
            }
        }
        private void DrawAllObjectsWithUi()
        {
            foreach (EatableObject objectToDraw in actors)
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
            Vector2f directionToMove = heroController.MouseMoved(e);
            hero.Move(directionToMove);
        }
        private void OnKeyPressed(object sender, KeyEventArgs e)
        {
            if (e.Code == Keyboard.Key.F)
            {
                int botNumber = MathHelper.RandomNumber(actors.Count);
              //  hero.ChangeCurrentBodyToBot(bots, botNumber);
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
