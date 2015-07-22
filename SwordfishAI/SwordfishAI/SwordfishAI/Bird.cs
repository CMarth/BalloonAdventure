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
    class Bird
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

        public Bird(Texture2D textura, Vector2 posicion)
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
            Colisiones.arrCuadros[0, 1] = 107 - (int)centro.Y;
            Colisiones.arrCuadros[0, 2] = 20;
        }
        void Inicializa_Cuadros()
        {
            cuadros[0] = new Rectangle(0, 0, 364, 300);
            cuadros[1] = new Rectangle(400, 0, 364, 300);
            cuadros[2] = new Rectangle(797, 0, 364, 300);
            cuadros[3] = new Rectangle(400, 0, 364, 300);
            //aqua jet
            cuadros[4] = new Rectangle(797, 0, 364, 300);
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
                if (tiempo >= 800)
                    tiempo = 0;
                origen = cuadros[tiempo / 200];
                velocidad = 0;
                if (origen == cuadros[4])
                {
                    estado = 2;
                }
            }
            //go
            if (estado == 2)
            {
                origen = cuadros[4];
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
                    Posicion.Y += 3;
                    // run check for the balloon
                    if ((balloon.Y - 50) <= Posicion.Y && Posicion.Y <= (balloon.Y + 5) || Posicion.Y >= 480)
                    {
                        compare = false;
                        velocidad = 6;
                        estado = 2;
                    }

                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(Textura, destino, origen, Color.White);
            spriteBatch.End();
        }
    }
}