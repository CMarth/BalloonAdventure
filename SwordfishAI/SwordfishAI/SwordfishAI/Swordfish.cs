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
    class Swordfish
    {
        Texture2D Textura;
        public Vector2 Posicion;
        public float velocidad = 2;
        Rectangle[] cuadros = new Rectangle[10];
        Rectangle origen, destino;
        int tiempo = 0;
        public Collide Colisiones;
        Vector2 centro = new Vector2(110, 67);
        bool compare;
        public int estado = 0;

        public Swordfish(Texture2D textura, Vector2 posicion)
        {
            Textura = textura;
            Posicion = posicion;
            Inicializa_Cuadros();
            compare = true;
            iniAreas();
        }
        private void iniAreas()
        {
            Colisiones.cantAreas = 1;
            Colisiones.arrCuadros = new int[Colisiones.cantAreas, 3];
            Colisiones.arrCuadros[0, 0] = 90 - (int)centro.X;
            Colisiones.arrCuadros[0, 1] = 90 - (int)centro.Y;
            Colisiones.arrCuadros[0, 2] = 30;
        }
        void Inicializa_Cuadros()
        {
            //swim
            cuadros[0] = new Rectangle(1218, 39, 222, 148);
            cuadros[1] = new Rectangle(0, 38, 213, 149);
            cuadros[2] = new Rectangle(1450, 24, 175, 163);
            cuadros[3] = new Rectangle(0, 38, 213, 149);
            //prepare
            cuadros[4] = new Rectangle(0, 38, 213, 149);
            cuadros[5] = new Rectangle(263, 29, 189, 163);
            cuadros[6] = new Rectangle(510, 4, 166, 175);
            cuadros[7] = new Rectangle(263, 29, 189, 163);
            //aqua jet
            cuadros[8] = new Rectangle(699, 25, 221, 135);
            cuadros[9] = new Rectangle(941, 35, 257, 119);
        }
        public void Update(GameTime gametime, Vector2 balloon)
        {
            tiempo += (int)gametime.ElapsedGameTime.TotalMilliseconds;
            //moving

            if (estado == 0)
            {
                if (tiempo >= 800)
                    tiempo = 0;
                origen = cuadros[tiempo / 200];
                velocidad = 2;
            }
            //ready
            if (estado == 1)
            {
                if (tiempo >= 500)
                    tiempo = 0;
                origen = cuadros[4 + tiempo / 100];
                velocidad = 0;
                if (origen == cuadros[8])
                {
                    estado = 2;
                }
            }
            //go
            if (estado == 2)
            {
                if (tiempo >= 400)
                    tiempo = 0;
                origen = cuadros[8 + tiempo / 200];
                velocidad = 6;
            }
            destino = origen;
            destino.X = (int)Posicion.X;
            destino.Y = (int)Posicion.Y;
            destino.Width = destino.Width / 2;
            destino.Height = destino.Height / 2;

            AI(balloon);
        }
        public void AI(Vector2 balloon)
        {
            if (estado == 0 && Posicion.X >= 600)
            {
                Posicion.X -= velocidad;
            }
            if (estado == 2)
            {
                Posicion.X -= velocidad;
            }
            if (Posicion.X < 600)
            {
                //when the fish reaches this point, here is all its AI
                if (compare == true)
                {
                    Posicion.Y+=3;
                    // run check for the balloon
                    if ((balloon.Y-5) <= Posicion.Y && Posicion.Y <= (balloon.Y+5) || Posicion.Y>=480)
                    {
                        compare = false;
                        
                        estado = 1;
                    }
                    
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            //transparent, multiply color white with 0.5f or whatever you want your transparency to be
            //or: Color colorT = Color.White; || colorT.A=0~255;
            spriteBatch.Begin();
            spriteBatch.Draw(Textura, destino, origen, Color.White);
            spriteBatch.End();
        }
    }
}
