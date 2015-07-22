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
    class Boss2
    {
        Texture2D Textura;
        public Vector2 Posicion;
        Rectangle origen, destino;
        public Collide RoboL, RoboT, RoboR;
        //Vector2 centro = new Vector2(308, 399);
        Vector2 centro = new Vector2(11, 43);
        bool step = false, up = false, side;

        public Boss2(Texture2D textura, Vector2 posicion)
        {
            Textura = textura;
            Posicion = posicion;
            Inicializa_Cuadros();
            iniAreas();
        }

        void Inicializa_Cuadros()
        {
            origen = new Rectangle(171, 246, 617, 799);
        }

        void iniAreas()
        {
            //left
            RoboL.cantAreas = 7;
            RoboL.arrCuadros = new int[RoboL.cantAreas, 3];
            RoboL.arrCuadros[0, 0] = 71 - (int)centro.X;
            RoboL.arrCuadros[0, 1] = 481 - (int)centro.Y;
            RoboL.arrCuadros[0, 2] = 71;

            RoboL.arrCuadros[1, 0] = 90 - (int)centro.X;
            RoboL.arrCuadros[1, 1] = 378 - (int)centro.Y;
            RoboL.arrCuadros[1, 2] = 51;

            RoboL.arrCuadros[2, 0] = 89 - (int)centro.X;
            RoboL.arrCuadros[2, 1] = 287 - (int)centro.Y;
            RoboL.arrCuadros[2, 2] = 52;

            RoboL.arrCuadros[3, 0] = 74 - (int)centro.X;
            RoboL.arrCuadros[3, 1] = 243 - (int)centro.Y;
            RoboL.arrCuadros[3, 2] = 32;

            RoboL.arrCuadros[4, 0] = 71 - (int)centro.X;
            RoboL.arrCuadros[4, 1] = 189 - (int)centro.Y;
            RoboL.arrCuadros[4, 2] = 40;

            RoboL.arrCuadros[5, 0] = 47 - (int)centro.X;
            RoboL.arrCuadros[5, 1] = 139 - (int)centro.Y;
            RoboL.arrCuadros[5, 2] = 38;

            RoboL.arrCuadros[6, 0] = 48 - (int)centro.X;
            RoboL.arrCuadros[6, 1] = 102 - (int)centro.Y;
            RoboL.arrCuadros[6, 2] = 36;

            //top

            RoboT.cantAreas = 5;
            RoboT.arrCuadros = new int[RoboT.cantAreas, 3];
            RoboT.arrCuadros[0, 0] = 80 - (int)centro.X;
            RoboT.arrCuadros[0, 1] = 56 - (int)centro.Y;
            RoboT.arrCuadros[0, 2] = 20;

            RoboT.arrCuadros[1, 0] = 115 - (int)centro.X;
            RoboT.arrCuadros[1, 1] = 61 - (int)centro.Y;
            RoboT.arrCuadros[1, 2] = 43;

            RoboT.arrCuadros[2, 0] = 167 - (int)centro.X;
            RoboT.arrCuadros[2, 1] = 62 - (int)centro.Y;
            RoboT.arrCuadros[2, 2] = 61;

            RoboT.arrCuadros[3, 0] = 221 - (int)centro.X;
            RoboT.arrCuadros[3, 1] = 48 - (int)centro.Y;
            RoboT.arrCuadros[3, 2] = 37;

            RoboT.arrCuadros[4, 0] = 262 - (int)centro.X;
            RoboT.arrCuadros[4, 1] = 54 - (int)centro.Y;
            RoboT.arrCuadros[4, 2] = 20;

            //right

            RoboR.cantAreas = 10;
            RoboR.arrCuadros = new int[RoboR.cantAreas, 3];
            RoboR.arrCuadros[0, 0] = 288 - (int)centro.X;
            RoboR.arrCuadros[0, 1] = 103 - (int)centro.Y;
            RoboR.arrCuadros[0, 2] = 34;

            RoboR.arrCuadros[1, 0] = 294 - (int)centro.X;
            RoboR.arrCuadros[1, 1] = 155 - (int)centro.Y;
            RoboR.arrCuadros[1, 2] = 34;

            RoboR.arrCuadros[2, 0] = 285 - (int)centro.X;
            RoboR.arrCuadros[2, 1] = 205 - (int)centro.Y;
            RoboR.arrCuadros[2, 2] = 38;

            RoboR.arrCuadros[3, 0] = 269 - (int)centro.X;
            RoboR.arrCuadros[3, 1] = 260 - (int)centro.Y;
            RoboR.arrCuadros[3, 2] = 38;

            RoboR.arrCuadros[4, 0] = 278 - (int)centro.X;
            RoboR.arrCuadros[4, 1] = 298 - (int)centro.Y;
            RoboR.arrCuadros[4, 2] = 31;

            RoboR.arrCuadros[5, 0] = 292 - (int)centro.X;
            RoboR.arrCuadros[5, 1] = 364 - (int)centro.Y;
            RoboR.arrCuadros[5, 2] = 44;

            RoboR.arrCuadros[6, 0] = 346 - (int)centro.X;
            RoboR.arrCuadros[6, 1] = 432 - (int)centro.Y;
            RoboR.arrCuadros[6, 2] = 52;

            RoboR.arrCuadros[7, 0] = 427 - (int)centro.X;
            RoboR.arrCuadros[7, 1] = 385 - (int)centro.Y;
            RoboR.arrCuadros[7, 2] = 75;

            RoboR.arrCuadros[8, 0] = 521 - (int)centro.X;
            RoboR.arrCuadros[8, 1] = 463 - (int)centro.Y;
            RoboR.arrCuadros[8, 2] = 75;

            RoboR.arrCuadros[9, 0] = 580 - (int)centro.X;
            RoboR.arrCuadros[9, 1] = 422 - (int)centro.Y;
            RoboR.arrCuadros[9, 2] = 25;
        }

        public void Update(GameTime gametime)
        {
            if (up)
            {
                if (Posicion.Y >= 0)
                {
                    Posicion.Y-= 2;
                }
                if (Posicion.Y <= 0)
                {
                    up = false;
                }
            }
            if (!up)
            {
                if (Posicion.Y < 130)
                {
                    Posicion.Y+= 2;
                }
                if (Posicion.Y >= 130)
                {
                    Posicion.Y = 130;
                    up = true;
                    step = false;
                }
            }
            if (side)
            {
                Posicion.X -= 2;
            }
            if (!side)
            {
                Posicion.X += 2;
            }
            AI();
            destino = origen;
            destino.X = (int)Posicion.X;
            destino.Y = (int)Posicion.Y;
        }
        void AI()
        {
            if (!step)
            {
                if (Posicion.X > 300)
                {
                    step = true;
                    side = true;
                }
                else
                {
                    step = true;
                    side = false;
                }
            }
        }

        public Vector2 bulletPos1()
        {
            Vector2 posBullet = Vector2.Zero;
            posBullet = Posicion;

            posBullet.X -= 12;
            posBullet.Y += 88;

            return posBullet;
        }
        public Vector2 bulletPos2()
        {
            Vector2 posBullet = Vector2.Zero;
            posBullet = Posicion;

            posBullet.X += 384;
            posBullet.Y += 152;

            return posBullet;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(Textura, destino, origen, Color.White);
            spriteBatch.End();
        }
    }
}
