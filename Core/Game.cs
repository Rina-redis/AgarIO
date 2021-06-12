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
        private HeroController heroController;       
        private UI gameUI = new UI();
        private ListLibrary listLibrary= new ListLibrary();
      //  private List<Food> food = new List<Food>();
      //  private List<Actor> actors = new List<Actor>();
     //   private List<Controller> controllers = new List<Controller>();

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
            heroController = new HeroController(hero);
            listLibrary.controllers.Add(heroController);
            listLibrary.actors.Add(hero);
            CreateBots(1);
            gameUI.Init();
            ConnectEvents();
        }
   
        private void LogicPart()
        {
            SpawnFood(listLibrary.food, 100);//
            hero.TryEat(listLibrary.food);
            ActorsCycle();
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
                listLibrary.controllers.Add(botController);
                listLibrary.actors.Add(newBot);
            }
        }

        private void ActorsCycle()
        {
            foreach (AIController actor in listLibrary.GetAIcontrollers())
            {
                actor.Cycle(listLibrary.food, listLibrary.actors);                                         
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
            heroController.MouseMoved(e);
            heroController.Cycle(listLibrary.food, listLibrary.actors);
        }
        private void OnKeyPressed(object sender, KeyEventArgs e)
        {
            if (e.Code == Keyboard.Key.F)
            {
                int botNumber = MathHelper.RandomNumber(listLibrary.actors.Count);                      
                hero.ChangeBody(listLibrary.actors[botNumber]);
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
            //foreach(Drawable drawableObject in listLibrary.GetDrawebleObjects())
            //{
            //    gameUI.DrawObject(drawableObject);
            //}
            foreach (EatableObject objectToDraw in listLibrary.actors)
            {
                gameUI.DrawObject(objectToDraw.shape);
            }
            foreach (EatableObject objectToDraw in listLibrary.food)
            {
                gameUI.DrawObject(objectToDraw.shape);
            }
            gameUI.DrawObject(hero.shape);
        }
    }
}
