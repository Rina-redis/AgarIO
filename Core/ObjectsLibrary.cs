using AgarIO.Controllers;
using AgarIO.Units;
using SFML.Graphics;
using System.Collections.Generic;
using System.Text;

namespace AgarIO.Core
{
    class ObjectsLibrary
    {
        public List<Puppet> actors;
        public List<Controller> controllers;
        public List<AIController> aIControllers;
        public List<IUpdatable> updatables;
        public List<Drawable> drawableObjects;      
        public List<Food> food;

        private static ObjectsLibrary instance;
        public static ObjectsLibrary getInstance()
        {
            if (instance == null)
                instance = new ObjectsLibrary();
            return instance;
        }
        public ObjectsLibrary()
        {
            drawableObjects = new List<Drawable>();
            updatables = new List<IUpdatable>();
            aIControllers = new List<AIController>();
            actors = new List<Puppet>();
            controllers = new List<Controller>();          
            food = new List<Food>();
        }
        public void AddController(Controller controller)
        {
            updatables.Add(controller);
            drawableObjects.Add(controller.GetShape());
        }
        //public void Add<T>(T item)
        //{
        //    switch (typeof(T).Name)
        //    {
        //        case "Food":
        //            food.Add(item as Food);
        //            break;
        //        case "Puppet":
        //            actors.Add(item as Puppet);
        //            break;
        //        case "HeroController":
        //            controllers.Add(item as Controller);
        //            break;
        //        case "AIController":
        //            controllers.Add(item as Controller);
        //            break;
        //        case "IUpdatable":
        //            updatables.Add(item as IUpdatable);
        //            break;
        //        case "Drawable":
        //            drawableObjects.Add(item as Drawable);
        //            break;
        //    }
        //}
        public List<AIController> GetAIcontrollers()
        {
            if(aIControllers.Count == 0)
            {
                foreach (Controller controller in controllers)
                {
                    if (controller is AIController)
                    {
                        aIControllers.Add(controller as AIController);
                    }
                }
                return aIControllers;
            }
            else
            {
                return aIControllers;
            }
        }
    }
}
