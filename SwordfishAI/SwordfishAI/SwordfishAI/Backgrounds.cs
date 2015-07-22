using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SwordfishAI
{
    class Backgrounds
    {
        public Texture2D texture;
        public Rectangle rectangle;
        public bool scroll = true;

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(texture, rectangle, Color.White);
            spriteBatch.End();
        }

    }

    class Scrolling : Backgrounds
    {
        public Scrolling(Texture2D newTexture, Rectangle newRectangle)
        {
            texture = newTexture;
            rectangle = newRectangle;

        }

        public void Update()
        {
            if (scroll == true)
                rectangle.X -= 1;
            if (scroll == false)
                rectangle.X = rectangle.X;
        }
    }
}
