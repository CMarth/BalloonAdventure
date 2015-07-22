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
    class Satelite
    {
        Texture2D Textura;
        public Vector2 Posicion;
        public float velocidad = 3;
        Rectangle[] cuadros = new Rectangle[2];
        Rectangle origen, destino;
        int tiempo = 0;
        public Collide Colisiones;
        public int estado = 0, i;
        Vector2 centro = new Vector2(58, 32);

        public Satelite(Texture2D textura, Vector2 posicion)
        {
            Textura = textura;
            Posicion = posicion;
            Inicializa_Cuadros();
            iniAreas();
        }
        void Inicializa_Cuadros()
        {
            cuadros[0] = new Rectangle(895, 190, 235, 130);
            cuadros[1] = new Rectangle(1135, 190, 235, 130);
        }
        public void Update(GameTime gametime)
        {
            tiempo += (int)gametime.ElapsedGameTime.TotalMilliseconds;
            
            if (tiempo >= 400)
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
            if (140 <= i  && i <= 152)
                estado = 1;
            if (0 <= i && i <= 5)
                estado = 1;

            i++;
            if (i > 300)
                i = 0;

        }
        private void iniAreas()
        {
            Colisiones.cantAreas = 3;
            Colisiones.arrCuadros = new int[Colisiones.cantAreas, 3];
            Colisiones.arrCuadros[0, 0] = 65 - (int)centro.X; //ajustamos las coordenadas de centros de circulos
            Colisiones.arrCuadros[0, 1] = 60 - (int)centro.Y; //segun la definicion de centro que hayan hecho
            Colisiones.arrCuadros[0, 2] = 29;

            Colisiones.arrCuadros[1, 0] = 105 - (int)centro.X; //ajustamos las coordenadas de centros de circulos
            Colisiones.arrCuadros[1, 1] = 40 - (int)centro.Y; //segun la definicion de centro que hayan hecho
            Colisiones.arrCuadros[1, 2] = 29;

            Colisiones.arrCuadros[2, 0] = 145 - (int)centro.X; //ajustamos las coordenadas de centros de circulos
            Colisiones.arrCuadros[2, 1] = 20 - (int)centro.Y; //segun la definicion de centro que hayan hecho
            Colisiones.arrCuadros[2, 2] = 29;
        }
        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Begin();
            spriteBatch.Draw(Textura, destino, origen, Color.White);
            spriteBatch.End();
        }
    }
}
