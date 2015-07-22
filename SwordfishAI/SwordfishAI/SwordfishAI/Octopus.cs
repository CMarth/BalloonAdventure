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
    class Octopus
    {
        Texture2D Textura;
        public Vector2 Posicion;
        Rectangle[] cuadros = new Rectangle[5];
        Rectangle origen, destino;
        public int tiempo = 0, estado = 0;
        Vector2 centro = new Vector2(59, 42);
        public Collide Colisiones;

        public Octopus(Texture2D textura, Vector2 posicion)
        {
            Textura = textura;
            Posicion = posicion;
            Inicializa_Cuadros();
            iniAreas();
        }
        void Inicializa_Cuadros()
        {
            cuadros[0] = new Rectangle(39, 673, 239, 171); 
            cuadros[1] = new Rectangle(320, 673, 242, 161); 
            cuadros[2] = new Rectangle(581, 673, 243, 169);
            cuadros[3] = new Rectangle(320, 673, 242, 161); 
            cuadros[4] = new Rectangle(39, 673, 239, 171); 
        }
        void iniAreas()
        {
            Colisiones.cantAreas = 1;
            Colisiones.arrCuadros = new int[Colisiones.cantAreas, 3];
            Colisiones.arrCuadros[0, 0] = 62 - (int)centro.X; 
            Colisiones.arrCuadros[0, 1] = 24 - (int)centro.Y; 
            Colisiones.arrCuadros[0, 2] = 24; 
        }
        public void Update(GameTime gametime, Vector2 balloon)
        {
            tiempo += (int)gametime.ElapsedGameTime.TotalMilliseconds;
            if (estado == 0)
                origen = cuadros[0];
            if (estado == 1)
            {
                if (tiempo >= 1000)
                    tiempo = 0;
                origen = cuadros[tiempo / 200];
                if (origen == cuadros[4])
                {
                    estado = 0;
                }
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
            Posicion.X -= 1;
            //attack
            if (Posicion.Y <= (balloon.Y + 80) && (balloon.X - 100) <= Posicion.X && Posicion.X <= (balloon.X + 20))
            {
                estado = 1;
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
