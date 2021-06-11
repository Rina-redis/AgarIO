using System;
using System.Collections.Generic;
using AgarIO.Controllers;
using AgarIO.Units;
using AgarIO.Utilits;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace AgarIO.Core
{
    class Game
    {
        private Actor hero = new Actor();
        private HumanController heroController;       
        private UI gameUI = new UI();
        private List<Food> food = new List<Food>();
        private List<Actor> actors = new List<Actor>();
        private List<Controller> controllers = new List<Controller>();

        public void Start()
        {
            heroController = new HumanController(hero);
            actors.Add(hero);
            SetupGame();
            while (CanPlay())
            {
                GameCycle();
            }
        }
        private void GameCycle()
        {
            LogicPart();
            UiPart();
        }


        private void SetupGame()
        {
            CreateBots(1);
            gameUI.Init();
            ConnectEvents();
        }
   
        private void LogicPart()
        {
            SpawnFood(food, 100);//
            hero.TryEat(food);
            BotsCycle();
        }
        private void UiPart()
        {
            gameUI.window.Clear(Color.White);
            gameUI.DrawText(hero.GetRadius());
            DrawAllObjects();
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
                Actor newBot = new Actor();
                AIController botController = new AIController(newBot);
                controllers.Add(botController);
                actors.Add(newBot);
            }
        }

        private void BotsCycle()
        {
            foreach (AIController actor in controllers)
            {

                actor.Cycle(food, actors);
                //if (actor.powelController is AIController) 
                //{
                //    Vector2f directionToMove = actor.powelController.CalculateDirectionToMove(actor, food, actors);                    
                //    actor.Move(directionToMove);
                //    actor.TryEat(food);
                //}
            }
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
            heroController.Move(directionToMove);
        }
        private void OnKeyPressed(object sender, KeyEventArgs e)
        {
            if (e.Code == Keyboard.Key.F)
            {
                int botNumber = MathHelper.RandomNumber(actors.Count);                      
                hero.ChangeBody(actors[botNumber]);
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
        private void DrawAllObjects()
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
    }
}
