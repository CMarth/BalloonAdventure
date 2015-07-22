using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SwordfishAI
{
    class Splash
    {
        Texture2D Tx;
        Rectangle origen, destino;
        public int tiempo;
        public bool splash;
        Color colorT = Color.White;
        public Splash(Texture2D tx)
        {
            Tx = tx;
            splash = true;
            Inicializa_Cuadros();
        }
        void Inicializa_Cuadros()
        {
            origen = new Rectangle(0, 0, 1024, 1100);
            destino = origen;
            destino.Width = 800;
            destino.Height = 600;
        }
        public void Update(GameTime gameTime)
        {
            tiempo += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (tiempo >= 2000)
            {
                splash = false;
                tiempo = 0;
            }
            if (tiempo >= 1745)
            {
                colorT.A--;
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(Tx, destino, origen, colorT);
            spriteBatch.End();
        }
    }
    
}