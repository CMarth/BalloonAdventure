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
    class Jellyfish
    {
        Texture2D Textura;
        public Vector2 Posicion;
        Rectangle[] cuadros = new Rectangle[4];
        Rectangle origen, destino;
        public Collide Colisiones, Squishy;
        Vector2 centro = new Vector2(33, 39);
        int tiempo = 0;

        public Jellyfish(Texture2D textura, Vector2 posicion)
        {
            Textura = textura;
            Posicion = posicion;
            Inicializa_Cuadros();
            iniAreas();
        }
        void Inicializa_Cuadros()
        {
            //swim
            cuadros[0] = new Rectangle(1102, 220, 132, 156);
            cuadros[1] = new Rectangle(1102, 404, 133, 149);
            cuadros[2] = new Rectangle(1102, 586, 132, 158);
            cuadros[3] = new Rectangle(1102, 404, 133, 149);
        }
        void iniAreas()
        {
            //oh boooy
            Colisiones.cantAreas = 1;
            Colisiones.arrCuadros = new int[Colisiones.cantAreas, 3];
            Colisiones.arrCuadros[0, 0] = 33 - (int)centro.X;
            Colisiones.arrCuadros[0, 1] = 53 - (int)centro.Y;
            Colisiones.arrCuadros[0, 2] = 24;

            Squishy.cantAreas = 3;
            Squishy.arrCuadros = new int[Squishy.cantAreas, 3];
            Squishy.arrCuadros[0, 0] = 15 - (int)centro.X;
            Squishy.arrCuadros[0, 1] = 10 - (int)centro.Y;
            Squishy.arrCuadros[0, 2] = 2;

            Squishy.arrCuadros[1, 0] = 33 - (int)centro.X;
            Squishy.arrCuadros[1, 1] = 10 - (int)centro.Y;
            Squishy.arrCuadros[1, 2] = 2; 

            Squishy.arrCuadros[2, 0] = 52 - (int)centro.X;
            Squishy.arrCuadros[2, 1] = 9 - (int)centro.Y;
            Squishy.arrCuadros[2, 2] = 2; 
        }
        public void Update(GameTime gametime)
        {
            tiempo += (int)gametime.ElapsedGameTime.TotalMilliseconds;
            
            if (tiempo >= 800)
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
            Posicion.X -= 1;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(Textura, destino, origen, Color.White);
            spriteBatch.End();
        }
    }
}
