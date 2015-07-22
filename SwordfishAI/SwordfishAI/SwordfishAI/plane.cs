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
    class plane
    {
        Texture2D Textura;
        public Vector2 Posicion;
        Rectangle[] cuadros = new Rectangle[4];
        Rectangle origen, destino;
        public Collide Colisiones;
        int tiempo = 0, i;
        Vector2 centro = new Vector2(50, 8);

        public plane(Texture2D textura, Vector2 posicion)
        {
            Textura = textura;
            Posicion = posicion;
            Inicializa_Cuadros();
            iniAreas();
        }
        void Inicializa_Cuadros()
        {
            cuadros[0] = new Rectangle(1195, 130, 200, 35);
        }
        private void iniAreas()
        {
            Colisiones.cantAreas = 1;
            Colisiones.arrCuadros = new int[Colisiones.cantAreas, 3];
            Colisiones.arrCuadros[0, 0] = 100 - (int)centro.X;
            Colisiones.arrCuadros[0, 1] = -10 - (int)centro.Y;
            Colisiones.arrCuadros[0, 2] = 43;
        }
        public void Update(GameTime gametime)
        {
            tiempo += (int)gametime.ElapsedGameTime.TotalMilliseconds;

            if (tiempo >= 200)
                tiempo = 0;
            origen = cuadros[tiempo / 200];

            destino = origen;
            destino.X = (int)Posicion.X;
            destino.Y = (int)Posicion.Y;
            destino.Width = destino.Width / 2;
            destino.Height = destino.Height / 2;

            AI();
        }

        public void AI()
        {
            Posicion.X -= 3;
            if (i < 152)
            {
                Posicion.Y++;
            }
            if (i > 148)
            {
                Posicion.Y--;
            }
            i++;
            if (i > 300)
                i = 0;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(Textura, destino, origen, Color.White);
            spriteBatch.End();
        }
    }
}