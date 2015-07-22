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
    class Shark
    {
        //ok we need colisions on its tail, mouth and top fin thank
        Texture2D Textura;
        public Vector2 Posicion;
        Rectangle[] cuadros = new Rectangle[4];
        Rectangle origen, destino;
        public Collide Colisiones;
        int tiempo = 0;
        Vector2 centro = new Vector2(75, 46);

        public Shark(Texture2D textura, Vector2 posicion)
        {
            Textura = textura;
            Posicion = posicion;
            Inicializa_Cuadros();
            iniAreas();
        }
        void Inicializa_Cuadros()
        {
            //swim
            cuadros[0] = new Rectangle(15, 424, 301, 184);
            cuadros[1] = new Rectangle(336, 435, 327, 174);
            cuadros[2] = new Rectangle(695, 446, 357, 159);
            cuadros[3] = new Rectangle(336, 435, 327, 174);
        }
        void iniAreas()
        {
            Colisiones.cantAreas = 3;
            Colisiones.arrCuadros = new int[Colisiones.cantAreas, 3];
            Colisiones.arrCuadros[0, 0] = 70 - (int)centro.X; 
            Colisiones.arrCuadros[0, 1] = 66 - (int)centro.Y; 
            Colisiones.arrCuadros[0, 2] = 28;

            Colisiones.arrCuadros[1, 0] = 80 - (int)centro.X;
            Colisiones.arrCuadros[1, 1] = 12 - (int)centro.Y;
            Colisiones.arrCuadros[1, 2] = 23;

            Colisiones.arrCuadros[2, 0] = 159 - (int)centro.X; // - 15
            Colisiones.arrCuadros[2, 1] = 56 - (int)centro.Y; // - 424
            Colisiones.arrCuadros[2, 2] = 25;
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
            Posicion.X -= 7;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(Textura, destino, origen, Color.White);
            spriteBatch.End();
        }
    }
}
