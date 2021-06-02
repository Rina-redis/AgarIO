 using System;
using System.Collections.Generic;
using System.Text;
using SFML.System;
using SFML.Window;
using SFML.Graphics;


namespace AgarIO
{
    class Player: PlayableObject
    {
        Text textWithRadius;
        public Player()
        {
            shape = new CircleShape();
            shape.FillColor = Color.Red;
            shape.Radius = 30;
            shape.Position = new Vector2f(200, 200);
           // textWithRadius = text;
        }
        public void SetCoordinateForMovement(MouseMoveEventArgs e)
        {
            Move(new Vector2f(e.X, e.Y));
        }
        public Text ChangeText(Font font)
        {         
            textWithRadius = new Text("Current radius:  "+((int)shape.Radius).ToString(), font);
            textWithRadius.CharacterSize = 24;
            textWithRadius.FillColor = Color.Red;
            textWithRadius.Position = new Vector2f(100, 100);
            return textWithRadius;
        }

        public void ChangeCurrentBodyToBot(List<Bot> bots, int randomBotNumber)
        {
            CircleShape tempShape = shape;

            PlayableObject newPlayer = bots[randomBotNumber];
            shape = newPlayer.shape;

            bots[randomBotNumber].shape = tempShape;
        }
    }
}
