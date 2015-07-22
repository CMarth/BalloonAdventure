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
    class Dragon
    {
        //ok we need colisions on its tail, mouth and top fin thank
        Texture2D Textura;
        public Vector2 Posicion;
        Rectangle[] cuadros = new Rectangle[4];
        Rectangle origen, destino;
        public Collide Colisiones, Colisiones2, Colisiones3;
        int tiempo = 0;
        Vector2 centro = new Vector2(112, 61);

        public Dragon(Texture2D textura, Vector2 posicion)
        {
            Textura = textura;
            Posicion = posicion;
            Inicializa_Cuadros();
            iniAreas();
        }
        void Inicializa_Cuadros()
        {
            cuadros[0] = new Rectangle(24, 330, 450, 245);
            cuadros[1] = new Rectangle(474, 330, 450, 245);
            cuadros[2] = new Rectangle(924, 330, 450, 245);
            cuadros[3] = new Rectangle(474, 330, 450, 245);
        }
        void iniAreas()
        {
            Colisiones.cantAreas = 5;
            Colisiones.arrCuadros = new int[Colisiones.cantAreas, 3];
            Colisiones.arrCuadros[0, 0] = 99 - (int)centro.X;  //19
            Colisiones.arrCuadros[0, 1] = 63 - (int)centro.Y;
            Colisiones.arrCuadros[0, 2] = 18;

            Colisiones.arrCuadros[1, 0] = 154 - (int)centro.X;
            Colisiones.arrCuadros[1, 1] = 85 - (int)centro.Y;
            Colisiones.arrCuadros[1, 2] = 50;

            Colisiones.arrCuadros[2, 0] = 241 - (int)centro.X; // - 15
            Colisiones.arrCuadros[2, 1] = 100 - (int)centro.Y; // - 424
            Colisiones.arrCuadros[2, 2] = 45;

            Colisiones.arrCuadros[3, 0] = 250 - (int)centro.X;
            Colisiones.arrCuadros[3, 1] = 100 - (int)centro.Y;
            Colisiones.arrCuadros[3, 2] = 30;

            Colisiones.arrCuadros[4, 0] = 311 - (int)centro.X;
            Colisiones.arrCuadros[4, 1] = 80 - (int)centro.Y;
            Colisiones.arrCuadros[4, 2] = 24;

            Colisiones2.cantAreas = 6;
            Colisiones2.arrCuadros = new int[Colisiones2.cantAreas, 3];
            Colisiones2.arrCuadros[0, 0] = 100 - (int)centro.X;
            Colisiones2.arrCuadros[0, 1] = 111 - (int)centro.Y;
            Colisiones2.arrCuadros[0, 2] = 18;

            Colisiones2.arrCuadros[1, 0] = 147 - (int)centro.X;
            Colisiones2.arrCuadros[1, 1] = 93 - (int)centro.Y;
            Colisiones2.arrCuadros[1, 2] = 30;

            Colisiones2.arrCuadros[2, 0] = 197 - (int)centro.X; // - 15
            Colisiones2.arrCuadros[2, 1] = 80 - (int)centro.Y; // - 424
            Colisiones2.arrCuadros[2, 2] = 35;

            Colisiones2.arrCuadros[3, 0] = 210 - (int)centro.X;
            Colisiones2.arrCuadros[3, 1] = 100 - (int)centro.Y;
            Colisiones2.arrCuadros[3, 2] = 38;

            Colisiones2.arrCuadros[4, 0] = 255 - (int)centro.X; //289
            Colisiones2.arrCuadros[4, 1] = 86 - (int)centro.Y;
            Colisiones2.arrCuadros[4, 2] = 37;

            Colisiones2.arrCuadros[5, 0] = 290 - (int)centro.X; // - 15
            Colisiones2.arrCuadros[5, 1] = 120 - (int)centro.Y; // - 424
            Colisiones2.arrCuadros[5, 2] = 28;

            Colisiones3.cantAreas = 6;
            Colisiones3.arrCuadros = new int[Colisiones3.cantAreas, 3];
            Colisiones3.arrCuadros[0, 0] = 125 - (int)centro.X;
            Colisiones3.arrCuadros[0, 1] = 105 - (int)centro.Y;
            Colisiones3.arrCuadros[0, 2] = 20;

            Colisiones3.arrCuadros[1, 0] = 145 - (int)centro.X;
            Colisiones3.arrCuadros[1, 1] = 110 - (int)centro.Y;
            Colisiones3.arrCuadros[1, 2] = 20;

            Colisiones3.arrCuadros[2, 0] = 175 - (int)centro.X; // - 15
            Colisiones3.arrCuadros[2, 1] = 100 - (int)centro.Y; // - 424
            Colisiones3.arrCuadros[2, 2] = 35;

            Colisiones3.arrCuadros[3, 0] = 200 - (int)centro.X;
            Colisiones3.arrCuadros[3, 1] = 90 - (int)centro.Y;
            Colisiones3.arrCuadros[3, 2] = 35;

            Colisiones3.arrCuadros[4, 0] = 225 - (int)centro.X; //289
            Colisiones3.arrCuadros[4, 1] = 100 - (int)centro.Y;
            Colisiones3.arrCuadros[4, 2] = 30;

            Colisiones3.arrCuadros[5, 0] = 290 - (int)centro.X;
            Colisiones3.arrCuadros[5, 1] = 130 - (int)centro.Y;
            Colisiones3.arrCuadros[5, 2] = 20;

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
            Posicion.X -= 9;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(Textura, destino, origen, Color.White);
            spriteBatch.End();
        }
    }
}
