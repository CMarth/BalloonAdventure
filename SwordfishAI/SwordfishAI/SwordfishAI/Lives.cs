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
    class Lives
    {
        Texture2D Textura;
        Vector2 Posicion;
        Rectangle origen, destino1, destino2, destino3;
        public int liv;

        public Lives(Texture2D textura)
        {
            Textura = textura;
            Posicion = new Vector2(720, 550);
            Inicializa_Cuadros();
        }
        void Inicializa_Cuadros()
        {
            origen = new Rectangle(209, 0, 92, 207);
        }
        public void Update(GameTime gametime, int l)
        {
            liv = l;
            destino1 = origen;
            destino1.X = (int)Posicion.X;
            destino1.Y = (int)Posicion.Y;
            destino1.Width = destino1.Width / 6;
            destino1.Height = destino1.Height / 6;
            destino2 = origen;
            destino2.X = (int)Posicion.X + 20;
            destino2.Y = (int)Posicion.Y;
            destino2.Width = destino1.Width;
            destino2.Height = destino1.Height;
            destino3 = origen;
            destino3.X = (int)Posicion.X + 40;
            destino3.Y = (int)Posicion.Y;
            destino3.Width = destino1.Width;
            destino3.Height = destino1.Height;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            if (liv == 3)
            {
                spriteBatch.Draw(Textura, destino1, origen, Color.White);
                spriteBatch.Draw(Textura, destino2, origen, Color.White);
                spriteBatch.Draw(Textura, destino3, origen, Color.White);
            }
            if (liv == 2)
            {
                spriteBatch.Draw(Textura, destino2, origen, Color.White);
                spriteBatch.Draw(Textura, destino3, origen, Color.White);
            }
            if (liv == 1)
            {
                spriteBatch.Draw(Textura, destino3, origen, Color.White);
            }
            spriteBatch.End();
        }
    }
}
