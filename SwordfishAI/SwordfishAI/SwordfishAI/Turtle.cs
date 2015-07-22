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
    class Turtle
    {
        Texture2D Textura;
        public Vector2 Posicion;
        Rectangle[] cuadros = new Rectangle[4];
        Rectangle origen, destino;
        public Collide Colisiones, Colisiones2, Top, Bottom;
        int tiempo = 0, i;
        public int a;
        Vector2 centro = new Vector2(67, 35);

        public Turtle(Texture2D textura, Vector2 posicion)
        {
            Textura = textura;
            Posicion = posicion;
            Inicializa_Cuadros();
            iniAreas();
        }
        void Inicializa_Cuadros()
        {
            //swim
            cuadros[0] = new Rectangle(9, 956, 264, 91); 
            cuadros[1] = new Rectangle(285, 965, 260, 127);
            cuadros[2] = new Rectangle(579, 972, 266, 125);
            cuadros[3] = new Rectangle(866, 975, 271, 87);
        }
        private void iniAreas()
        {
            Colisiones.cantAreas = 1;
            Colisiones.arrCuadros = new int[Colisiones.cantAreas, 3];
            Colisiones.arrCuadros[0, 0] = 18 - (int)centro.X;
            Colisiones.arrCuadros[0, 1] = 14 - (int)centro.Y;
            Colisiones.arrCuadros[0, 2] = 15;

            Colisiones2.cantAreas = 1;
            Colisiones2.arrCuadros = new int[Colisiones2.cantAreas, 3];
            Colisiones2.arrCuadros[0, 0] = 16 - (int)centro.X; 
            Colisiones2.arrCuadros[0, 1] = 20 - (int)centro.Y; 
            Colisiones2.arrCuadros[0, 2] = 15; 

            Top.cantAreas = 5;
            Top.arrCuadros = new int[Top.cantAreas, 3];
            Top.arrCuadros[0, 0] = 55 - (int)centro.X;
            Top.arrCuadros[0, 1] = 19 - (int)centro.Y;
            Top.arrCuadros[0, 2] = 8;

            Top.arrCuadros[1, 0] = 52 - (int)centro.X; 
            Top.arrCuadros[1, 1] = 16 - (int)centro.Y;
            Top.arrCuadros[1, 2] = 8;

            Top.arrCuadros[2, 0] = 80 - (int)centro.X;
            Top.arrCuadros[2, 1] = 14 - (int)centro.Y;
            Top.arrCuadros[2, 2] = 9;

            Top.arrCuadros[3, 0] = 95 - (int)centro.X;
            Top.arrCuadros[3, 1] = 17 - (int)centro.Y;
            Top.arrCuadros[3, 2] = 9;

            Top.arrCuadros[4, 0] = 107 - (int)centro.X;
            Top.arrCuadros[4, 1] = 21 - (int)centro.Y;
            Top.arrCuadros[4, 2] = 4;

            //help me imma die
            Bottom.cantAreas = 9;
            Bottom.arrCuadros = new int[Bottom.cantAreas, 3];
            Bottom.arrCuadros[0, 0] = 52 - (int)centro.X;
            Bottom.arrCuadros[0, 1] = 40 - (int)centro.Y;
            Bottom.arrCuadros[0, 2] = 4;

            Bottom.arrCuadros[1, 0] = 58 - (int)centro.X;
            Bottom.arrCuadros[1, 1] = 41 - (int)centro.Y;
            Bottom.arrCuadros[1, 2] = 4;

            Bottom.arrCuadros[2, 0] = 66 - (int)centro.X;
            Bottom.arrCuadros[2, 1] = 41 - (int)centro.Y;
            Bottom.arrCuadros[2, 2] = 5;

            Bottom.arrCuadros[3, 0] = 74 - (int)centro.X;
            Bottom.arrCuadros[3, 1] = 41 - (int)centro.Y;
            Bottom.arrCuadros[3, 2] = 4;

            Bottom.arrCuadros[4, 0] = 81 - (int)centro.X;
            Bottom.arrCuadros[4, 1] = 40 - (int)centro.Y;
            Bottom.arrCuadros[4, 2] = 4;

            Bottom.arrCuadros[5, 0] = 89 - (int)centro.X;
            Bottom.arrCuadros[5, 1] = 39 - (int)centro.Y;
            Bottom.arrCuadros[5, 2] = 5;

            Bottom.arrCuadros[6, 0] = 96 - (int)centro.X;
            Bottom.arrCuadros[6, 1] = 37 - (int)centro.Y;
            Bottom.arrCuadros[6, 2] = 5;

            Bottom.arrCuadros[7, 0] = 102 - (int)centro.X;
            Bottom.arrCuadros[7, 1] = 35 - (int)centro.Y;
            Bottom.arrCuadros[7, 2] = 3;

            Bottom.arrCuadros[8, 0] = 109 - (int)centro.X;
            Bottom.arrCuadros[8, 1] = 32 - (int)centro.Y;
            Bottom.arrCuadros[8, 2] = 4;
        }
        public void Update(GameTime gametime)
        {
            tiempo += (int)gametime.ElapsedGameTime.TotalMilliseconds;
            
            if (tiempo >= 800)
                tiempo = 0;
            origen = cuadros[tiempo / 200];
            a = (tiempo / 200);
            
            destino = origen;
            destino.X = (int)Posicion.X;
            destino.Y = (int)Posicion.Y;
            destino.Width = destino.Width / 2;
            destino.Height = destino.Height / 2;

            AI();
        }

        public void AI()
        {
            Posicion.X -= 1;
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
