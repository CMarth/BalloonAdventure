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
    class Pufferfish
    {
        Texture2D Textura;
        public Vector2 Posicion;
        public float velocidad = 3;
        Rectangle[] cuadros = new Rectangle[9];
        Rectangle origen, destino;
        int tiempo = 0;
        public Collide Colisiones, Deflated;
        public int estado = 0, i;
        Vector2 centro = new Vector2(40, 40);

        public Pufferfish(Texture2D textura, Vector2 posicion)
        {
            Textura = textura;
            Posicion = posicion;
            Inicializa_Cuadros();
            iniAreas();
        }
        void Inicializa_Cuadros()
        {
            //normal
            cuadros[0] = new Rectangle(48, 280, 107, 46);
            cuadros[1] = new Rectangle(195, 280, 106, 46);
            cuadros[2] = new Rectangle(338, 280, 101, 46);
            cuadros[3] = new Rectangle(195, 280, 106, 46);
            //prepare
            cuadros[4] = new Rectangle(472, 280, 98, 67);
            //puff
            cuadros[5] = new Rectangle(591, 264, 119, 96);
            cuadros[6] = new Rectangle(733, 264, 119, 96);
            cuadros[7] = new Rectangle(900, 264, 119, 96);
            cuadros[8] = new Rectangle(733, 264, 119, 96);
        }
        public void Update(GameTime gametime)
        {
            tiempo += (int)gametime.ElapsedGameTime.TotalMilliseconds;
            //normal swim
            if (estado == 0)
            {
                if (tiempo >= 800)
                    tiempo = 0;
                origen = cuadros[tiempo / 200];
            }
            //puff
            if (estado == 1)
            {
                origen = cuadros[4];
            }
            //puff swim
            if (estado == 2)
            {
                if (tiempo >= 800)
                    tiempo = 0;
                origen = cuadros[5 + tiempo / 200];
            }
            destino = origen;
            destino.X = (int)Posicion.X;
            destino.Y = (int)Posicion.Y;
            destino.Width = destino.Width / 2;
            destino.Height = destino.Height / 2;

            AI();
        }
        public void AI()
        {
            //AI here
            Posicion.X--;
            estado = 0;

            if (i < 152)
            {
                Posicion.Y++;
                estado = 0;
            }
            if (i > 148)
            {
                Posicion.Y--;
                estado = 2;
            }
            if (140 <= i && i <= 152)
                estado = 1;
            if (0 <= i && i <= 5)
                estado = 1;

            i++;
            if (i > 300)
                i = 0;

        }
        private void iniAreas()
        {
            Colisiones.cantAreas = 1;
            Colisiones.arrCuadros = new int[Colisiones.cantAreas, 3];
            Colisiones.arrCuadros[0, 0] = 40 - (int)centro.X; 
            Colisiones.arrCuadros[0, 1] = 40 - (int)centro.Y;
            Colisiones.arrCuadros[0, 2] = 40;

            //deflated 48, 280
            Deflated.cantAreas = 2;
            Deflated.arrCuadros = new int[Deflated.cantAreas, 3];
            Deflated.arrCuadros[0, 0] = 18 - 40;
            Deflated.arrCuadros[0, 1] = 11 - 13;
            Deflated.arrCuadros[0, 2] = 12;

            Deflated.arrCuadros[1, 0] = 33 - 40;
            Deflated.arrCuadros[1, 1] = 13 - 13;
            Deflated.arrCuadros[1, 2] = 10; 
        }
        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Begin();
            spriteBatch.Draw(Textura, destino, origen, Color.White);
            spriteBatch.End();
        }
    }
}
