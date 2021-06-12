using AgarIO.Controllers;
using AgarIO.Units;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgarIO.Core
{
    class ListLibrary
    {
        public List<Actor> actors;
        public List<Controller> controllers;
        public List<AIController> aIControllers;
        public List<Drawable> drawableObjects;
        public List<HeroController> heroControllers;
        public List<Food> food;

        public ListLibrary()
        {
            drawableObjects = new List<Drawable>();
            aIControllers = new List<AIController>();
            actors = new List<Actor>();
            controllers = new List<Controller>();
            heroControllers = new List<HeroController>();
            food = new List<Food>();
        }
        public List<Drawable> GetDrawebleObjects()
        {
            foreach (Drawable shape in food)
            {
                drawableObjects.Add(shape);
            }
            foreach (Drawable shape in actors)
            {
                drawableObjects.Add(shape);
            }
            return drawableObjects;
        }
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
