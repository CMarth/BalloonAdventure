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
    class Robobalas
    {
        Texture2D Textura;
        public Vector2 Posicion;
        Rectangle[] balilla = new Rectangle[4];
        Rectangle destino, origen;
        public Collide ColisionesS, ColisionesM, Rub1, Rub2;
        Vector2 centro;
        public int bsize = 0;

        public Robobalas(Texture2D textura, Vector2 posicion, int biggy)
        {
            Textura = textura;
            Posicion = posicion;
            bsize = biggy;
            //0 small, 1 big
            if (bsize == 0)
                centro = new Vector2(41, 49);
            if (bsize == 1)
                centro = new Vector2(61, 51);
            if (bsize == 2)
                centro = new Vector2(0, 0);
            if (bsize == 3)
                centro = new Vector2(0, 0);
            iniAreas();
            Inicializa_Cuadros();
        }

        private void iniAreas()
        {
            //small bitches
            ColisionesS.cantAreas = 3;
            ColisionesS.arrCuadros = new int[ColisionesS.cantAreas, 3];
            ColisionesS.arrCuadros[0, 0] = 18 - (int)centro.X; 
            ColisionesS.arrCuadros[0, 1] = 22 - (int)centro.Y; 
            ColisionesS.arrCuadros[0, 2] = 15;

            ColisionesS.arrCuadros[1, 0] = 44 - (int)centro.X;
            ColisionesS.arrCuadros[1, 1] = 22 - (int)centro.Y;
            ColisionesS.arrCuadros[1, 2] = 15;

            ColisionesS.arrCuadros[2, 0] = 66 - (int)centro.X;
            ColisionesS.arrCuadros[2, 1] = 22 - (int)centro.Y;
            ColisionesS.arrCuadros[2, 2] = 15;

            //fat missle
            ColisionesM.cantAreas = 5;
            ColisionesM.arrCuadros = new int[ColisionesM.cantAreas, 3];
            ColisionesM.arrCuadros[0, 0] = 62 - (int)centro.X;
            ColisionesM.arrCuadros[0, 1] = 23 - (int)centro.Y;
            ColisionesM.arrCuadros[0, 2] = 23;

            ColisionesM.arrCuadros[1, 0] = 60 - (int)centro.X;
            ColisionesM.arrCuadros[1, 1] = 59 - (int)centro.Y;
            ColisionesM.arrCuadros[1, 2] = 31;

            ColisionesM.arrCuadros[2, 0] = 58 - (int)centro.X;
            ColisionesM.arrCuadros[2, 1] = 108 - (int)centro.Y;
            ColisionesM.arrCuadros[2, 2] = 39;

            ColisionesM.arrCuadros[3, 0] = 56 - (int)centro.X;
            ColisionesM.arrCuadros[3, 1] = 179 - (int)centro.Y;
            ColisionesM.arrCuadros[3, 2] = 42;

            ColisionesM.arrCuadros[4, 0] = 61 - (int)centro.X;
            ColisionesM.arrCuadros[4, 1] = 245 - (int)centro.Y;
            ColisionesM.arrCuadros[4, 2] = 55;

            //rubble1
            Rub1.cantAreas = 2;
            Rub1.arrCuadros = new int[Rub1.cantAreas, 3];
            Rub1.arrCuadros[0, 0] = 61 - (int)centro.X;
            Rub1.arrCuadros[0, 1] = 36 - (int)centro.Y;
            Rub1.arrCuadros[0, 2] = 36;

            Rub1.arrCuadros[1, 0] = 41 - (int)centro.X;
            Rub1.arrCuadros[1, 1] = 96 - (int)centro.Y;
            Rub1.arrCuadros[1, 2] = 34;

            Rub2.cantAreas = 1;
            Rub2.arrCuadros = new int[Rub2.cantAreas, 3];
            Rub2.arrCuadros[0, 0] = 55 - (int)centro.X;
            Rub2.arrCuadros[0, 1] = 60 - (int)centro.Y;
            Rub2.arrCuadros[0, 2] = 54;

        }

        void Inicializa_Cuadros()
        {
            //0 small, 1 big
            balilla[0] = new Rectangle(49, 399, 83, 38); 
            balilla[1] = new Rectangle(18, 53, 122, 303);
            //2 is rubble1, 3 is rubble2
            balilla[2] = new Rectangle(287, 29, 103, 128);
            balilla[3] = new Rectangle(494, 20, 119, 114);
        }
        public void Update(GameTime gametime)
        {
            if (bsize == 0)
            {
                Posicion.X -= 4;
                origen = balilla[0];
            }
            if (bsize == 1)
            {
                Posicion.Y -= 4;
                origen = balilla[1];
            }
            if (bsize == 2)
            {
                Posicion.Y += 6;
                origen = balilla[2];
            }
            if (bsize == 3)
            {
                Posicion.Y += 6;
                origen = balilla[3];
            }
            destino = origen;
            destino.X = (int)Posicion.X;
            destino.Y = (int)Posicion.Y;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(Textura, destino, origen, Color.White);
            spriteBatch.End();
        }
    }
}
