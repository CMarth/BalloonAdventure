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
    class Bigmeteor
    {
        Texture2D Textura;
        public Vector2 Posicion;
        Rectangle[] cuadros = new Rectangle[4];
        Rectangle origen, destino;
        public Collide Colisiones;
        int tiempo = 0;
        Vector2 centro = new Vector2(35, 36);

        public Bigmeteor(Texture2D textura, Vector2 posicion)
        {
            Textura = textura;
            Posicion = posicion;
            Inicializa_Cuadros();
            iniAreas();
        }
        void Inicializa_Cuadros()
        {
            cuadros[0] = new Rectangle(20, 195, 140, 145);
            cuadros[1] = new Rectangle(170, 195, 140, 145);
            cuadros[2] = new Rectangle(320, 195, 140, 145);
            cuadros[3] = new Rectangle(470, 195, 140, 145);
        }
        void iniAreas()
        {
            Colisiones.cantAreas = 1;
            Colisiones.arrCuadros = new int[Colisiones.cantAreas, 3];
            Colisiones.arrCuadros[0, 0] = 55 - (int)centro.X; 
            Colisiones.arrCuadros[0, 1] = 45 - (int)centro.Y; 
            Colisiones.arrCuadros[0, 2] = 45;
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
            Posicion.X -= 4;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(Textura, destino, origen, Color.White);
            spriteBatch.End();
        }
    }
}

