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
    class Balloony
    {
        Texture2D Textura;
        public Vector2 Posicion;
        Rectangle[] cuadros = new Rectangle[16];
        Rectangle origen, destino;
        public Collide Colisiones;
        public int estado = 0, tiempo=0;
        Vector2 centro = new Vector2(24, 24);
        public bool bloo = true;

        public Balloony(Texture2D textura, Vector2 posicion)
        {
            Textura = textura;
            Posicion = posicion;
            Inicializa_Cuadros();
            iniAreas();
        }
        void Inicializa_Cuadros()
        {
            //float
            cuadros[0] = new Rectangle(3, 2, 92, 203);
            cuadros[1] = new Rectangle(209, 0, 92, 207);
            cuadros[2] = new Rectangle(105, 2, 92, 206);
            cuadros[3] = new Rectangle(209, 0, 92, 207);
            //move
            cuadros[4] = new Rectangle(0, 249, 204, 132);
            cuadros[5] = new Rectangle(429, 261, 201, 98); 
            cuadros[6] = new Rectangle(210, 257, 203, 112); 
            cuadros[7] = new Rectangle(429, 261, 201, 98);
            //dead
            cuadros[8] = new Rectangle(37, 437, 97, 172);
            cuadros[9] = new Rectangle(171, 460, 93, 133);
            cuadros[10] = new Rectangle(327, 451, 91, 154);
            cuadros[11] = new Rectangle(488, 457, 70, 144);
            cuadros[12] = new Rectangle(0, 0, 0, 0);
            //crash side
            cuadros[13] = new Rectangle(305, 4, 90, 205);
            //crash top
            cuadros[14] = new Rectangle(404, 4, 88, 158);
            //crash bottom
            cuadros[15] = new Rectangle(521, 4, 115, 130);
        }
        private void iniAreas()
        {
            Colisiones.cantAreas = 1;
            Colisiones.arrCuadros = new int[Colisiones.cantAreas, 3];
            Colisiones.arrCuadros[0, 0] = 24 - (int)centro.X;
            Colisiones.arrCuadros[0, 1] = 24 - (int)centro.Y;
            Colisiones.arrCuadros[0, 2] = 24;
        }
        public void Update(GameTime gametime)
        {
            tiempo += (int)gametime.ElapsedGameTime.TotalMilliseconds;
            if (bloo)
            {
                if (estado == 0)
                {
                    if (tiempo >= 800)
                        tiempo = 0;
                    origen = cuadros[tiempo / 200];
                    Colisiones.arrCuadros[0, 0] = 24 - (int)centro.X;
                }
                if (estado == 1)
                {
                    if (tiempo >= 400)
                        tiempo = 0;
                    origen = cuadros[4 + tiempo / 100];
                    Colisiones.arrCuadros[0, 0] = 44 - (int)centro.X;
                }
                if (estado == 4)
                {
                    origen = cuadros[13];
                }
                if (estado == 5)
                {
                    origen = cuadros[14];
                }
                if (estado == 6)
                {
                    origen = cuadros[15];
                }
            }
            if (estado == 2)
            {
                bloo = false;
                if (tiempo >= 500)
                    tiempo = 0;
                origen = cuadros[8 + tiempo / 100];
                if (origen == cuadros[12])
                {
                    estado = 3;
                }
            }

            if (estado == 3)
            {
                origen = cuadros[12];
            }
            destino = origen;
            destino.X = (int)Posicion.X;
            destino.Y = (int)Posicion.Y;
            destino.Width = destino.Width / 2;
            destino.Height = destino.Height / 2;
        }
        public bool Colision(Collide datos, Vector2 posi)
        {
            bool valsal = false;

            for (int j = 0; j < Colisiones.cantAreas; j++)
            {
                for (int i = 0; i < datos.cantAreas; i++)
                {
                    Vector3 aux = new Vector3(Colisiones.arrCuadros[j, 0], Colisiones.arrCuadros[j, 1], 0);
                    float dist = (float)Math.Sqrt(Math.Pow(aux.X + Posicion.X - datos.arrCuadros[i, 0] - posi.X, 2.0) +
                        Math.Pow(aux.Y + Posicion.Y - datos.arrCuadros[i, 1] - posi.Y, 2.0));


                    if (dist >= (Colisiones.arrCuadros[j, 2] + datos.arrCuadros[i, 2]))
                    {
                        valsal = false;
                    }
                    else
                    {
                        valsal = true;
                    }

                    if (valsal)
                        break;
                }

                if (valsal)
                    break;
            }
            return valsal;
        }
        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Begin();
            spriteBatch.Draw(Textura, destino, origen, Color.White);
            spriteBatch.End();
        }

    }
}
