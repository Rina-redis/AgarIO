using System;
using System.Collections.Generic;
using AgarIO.Controllers;
using AgarIO.Units;
using AgarIO.Utilits;
using SFML.Graphics;
using SFML.Window;

namespace AgarIO.Core
{
    class Game
    {
        private Puppet hero = new Puppet();
        private HeroController heroController;       
        private UI gameUI = new UI();
        private ObjectsLibrary gameLibrary= new ObjectsLibrary();

        public void Start()
        {           
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
            CreateHero();
            CreateBots(3);
            gameUI.Init();
            ConnectEvents();
        }
   
        private void LogicPart()
        {
            SpawnFood(gameLibrary.food, 100);//          
            ActorsCycle();
        }
        private void UiPart()
        {
            gameUI.ClearWindow();
            DrawAllObjects();
            gameUI.Dispatch();
        }

        private void SpawnFood(List<Food> foofList, int numberOfFood)
        {
            for (int i = foofList.Count; i < numberOfFood; i++)
            {
                Food pieceOfFood = new Food();
                foofList.Add(pieceOfFood);               
            }
        }
        private void CreateHero()
        {
            heroController = new HeroController(hero);
            gameLibrary.AddController(heroController);
        }
        private void CreateBots(int numberOfBots)
        {
            for (int i = 1; i <= numberOfBots; i++)
            {
                Puppet bot = new Puppet();
                AIController botController = new AIController(bot);
                gameLibrary.AddController(botController);
            }
        }

        private void ActorsCycle()
        {
            foreach (IUpdatable actor in gameLibrary.updatables)
            {
                actor.Update(gameLibrary.food, gameLibrary.actors);                                         
            }
        }
        
        private void ConnectEvents()
        {
            gameUI.window.KeyPressed += OnKeyPressed; //kak to po ploho...
            gameUI.window.MouseMoved += heroController.MouseMoved;
            gameUI.window.Closed += WindowClosed;
        }
     
        private void OnKeyPressed(object sender, KeyEventArgs e)
        {
            if (e.Code == Keyboard.Key.F)
            {
                int botNumber = MathHelper.RandomNumber(gameLibrary.actors.Count);     //                 
                hero.ChangeBody(gameLibrary.actors[botNumber]);
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
            gameUI.DrawText(hero.GetRadius());
            foreach (Drawable drawableObject in gameLibrary.drawableObjects)
            {
                gameUI.DrawObject(drawableObject);
            }
            foreach (EatableObject objectToDraw in gameLibrary.food)
            {
                gameUI.DrawObject(objectToDraw.shape);
            }
        }
    }
}
