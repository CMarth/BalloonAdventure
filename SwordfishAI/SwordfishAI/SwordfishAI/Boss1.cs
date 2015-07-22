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
    class Boss1
    {
        Texture2D Textura;
        public Vector2 Posicion;
        Rectangle[] cuadros = new Rectangle[11];
        Rectangle origen, destino;
        public Collide Colisiones, Top, Bottom, SideL, SideR, Jump;
        Vector2 centro = new Vector2(77, 50), jumpc = new Vector2(40, 25); //177, 164 || 174, 124
        int tiempo = 0;
        public int estado = 1;
        bool backup = false, up = false, jumping = false;

        public Boss1(Texture2D textura, Vector2 posicion)
        {
            Textura = textura;
            Posicion = posicion;
            Inicializa_Cuadros();
            iniAreas();
        }

        void Inicializa_Cuadros()
        {
            //walk
            cuadros[0] = new Rectangle(571, 30, 367, 318);
            cuadros[1] = new Rectangle(92, 30, 346, 318);
            cuadros[2] = new Rectangle(571, 396, 367, 318);
            cuadros[3] = new Rectangle(92, 30, 346, 318);

            //snap
            cuadros[4] = new Rectangle(105, 398, 337, 276);
            cuadros[5] = new Rectangle(82, 771, 352, 286);
            cuadros[6] = new Rectangle(80, 1096, 354, 328);
            cuadros[7] = new Rectangle(79, 1432, 355, 292);
            cuadros[8] = new Rectangle(82, 771, 352, 286);
            cuadros[9] = new Rectangle(92, 30, 346, 318);

            //jump
            cuadros[10] = new Rectangle(588, 774, 348, 249);
        }

        void iniAreas()
        {
            //claw attack
            Colisiones.cantAreas = 3;
            Colisiones.arrCuadros = new int[Colisiones.cantAreas, 3];
            Colisiones.arrCuadros[0, 0] = 94 - (int)centro.X;
            Colisiones.arrCuadros[0, 1] = 114 - (int)centro.Y;
            Colisiones.arrCuadros[0, 2] = 59;

            Colisiones.arrCuadros[1, 0] = 150 - (int)centro.X;
            Colisiones.arrCuadros[1, 1] = 58 - (int)centro.Y;
            Colisiones.arrCuadros[1, 2] = 56;

            Colisiones.arrCuadros[2, 0] = 280 - (int)centro.X;
            Colisiones.arrCuadros[2, 1] = 86 - (int)centro.Y;
            Colisiones.arrCuadros[2, 2] = 67;
            
            //jump
            //top
            Top.cantAreas = 4;
            Top.arrCuadros = new int[Top.cantAreas, 3];
            Top.arrCuadros[0, 0] = 106 - (int)jumpc.X;
            Top.arrCuadros[0, 1] = 97 - (int)jumpc.Y;
            Top.arrCuadros[0, 2] = 28;

            Top.arrCuadros[1, 0] = 143 - (int)jumpc.X; 
            Top.arrCuadros[1, 1] = 93 - (int)jumpc.Y;
            Top.arrCuadros[1, 2] = 30;

            Top.arrCuadros[2, 0] = 185 - (int)jumpc.X;
            Top.arrCuadros[2, 1] = 90 - (int)jumpc.Y; 
            Top.arrCuadros[2, 2] = 29;

            Top.arrCuadros[3, 0] = 233 - (int)jumpc.X;
            Top.arrCuadros[3, 1] = 100 - (int)jumpc.Y;
            Top.arrCuadros[3, 2] = 31;

            //bottom
            Bottom.cantAreas = 5;
            Bottom.arrCuadros = new int[Bottom.cantAreas, 3];
            Bottom.arrCuadros[0, 0] = 127 - (int)jumpc.X;
            Bottom.arrCuadros[0, 1] = 218 - (int)jumpc.Y;
            Bottom.arrCuadros[0, 2] = 15;

            Bottom.arrCuadros[1, 0] = 155 - (int)jumpc.X; 
            Bottom.arrCuadros[1, 1] = 220 - (int)jumpc.Y; 
            Bottom.arrCuadros[1, 2] = 13;

            Bottom.arrCuadros[2, 0] = 174 - (int)jumpc.X; 
            Bottom.arrCuadros[2, 1] = 220 - (int)jumpc.Y;
            Bottom.arrCuadros[2, 2] = 12;

            Bottom.arrCuadros[3, 0] = 194 - (int)jumpc.X;
            Bottom.arrCuadros[3, 1] = 221 - (int)jumpc.Y;
            Bottom.arrCuadros[3, 2] = 12;

            Bottom.arrCuadros[4, 0] = 213 - (int)jumpc.X;
            Bottom.arrCuadros[4, 1] = 220 - (int)jumpc.Y;
            Bottom.arrCuadros[4, 2] = 11;

            //pincers
            Jump.cantAreas = 4;
            Jump.arrCuadros = new int[Jump.cantAreas, 3];
            Jump.arrCuadros[0, 0] = 34 - (int)jumpc.X;
            Jump.arrCuadros[0, 1] = 184 - (int)jumpc.Y;
            Jump.arrCuadros[0, 2] = 37;

            Jump.arrCuadros[1, 0] = 78 - (int)jumpc.X; 
            Jump.arrCuadros[1, 1] = 215 - (int)jumpc.Y;
            Jump.arrCuadros[1, 2] = 31;

            Jump.arrCuadros[2, 0] = 263 - (int)jumpc.X; 
            Jump.arrCuadros[2, 1] = 211 - (int)jumpc.Y;
            Jump.arrCuadros[2, 2] = 40;

            Jump.arrCuadros[3, 0] = 312 - (int)jumpc.X;
            Jump.arrCuadros[3, 1] = 177 - (int)jumpc.Y;
            Jump.arrCuadros[3, 2] = 33;

            //left
            SideL.cantAreas = 1;
            SideL.arrCuadros = new int[SideL.cantAreas, 3];
            SideL.arrCuadros[0, 0] = 52 - (int)jumpc.X;
            SideL.arrCuadros[0, 1] = 122 - (int)jumpc.Y;
            SideL.arrCuadros[0, 2] = 23;

            //right
            SideR.cantAreas = 1;
            SideR.arrCuadros = new int[SideR.cantAreas, 3];
            SideR.arrCuadros[0, 0] = 290 - (int)jumpc.X;
            SideR.arrCuadros[0, 1] = 124 - (int)jumpc.Y;
            SideR.arrCuadros[0, 2] = 21;

        }

        public void Update(GameTime gametime, int i, int f, Vector2 balloon)
        {
            tiempo += (int)gametime.ElapsedGameTime.TotalMilliseconds;
            if (estado == 0)
            {
                origen = cuadros[1];
            }
            if (estado == 1)
            {
                if (tiempo >= 400)
                    tiempo = 0;
                origen = cuadros[tiempo / 100];
            }
            if (estado == 2)
            {
                jumping = true;
                if (tiempo >= 1200)
                    tiempo = 0;
                origen = cuadros[4 + tiempo / 200];
                if (origen == cuadros[9])
                {
                    estado = 1;
                    jumping = false;
                }
            }
            if (estado == 3)
            {
                jumping = true;
                origen = cuadros[10];
                if (!backup)
                {
                    if (Posicion.X > 0)
                    {
                        Posicion.X -= 2;
                    }
                    if (Posicion.X <= 0)
                    {
                        backup = true;
                    }
                }
                if (backup)
                {
                    Posicion.X += 2;
                    if (Posicion.X >= 400)
                    {
                        backup = false;
                    }
                }
                //up and down
                if (up)
                {
                    if (Posicion.Y > -50)
                    {
                        Posicion.Y -= 3;
                    }
                    if (Posicion.Y < -50)
                    {
                        up = false;
                    }
                }
                if (!up)
                {
                    if (Posicion.Y < 300)
                    {
                        Posicion.Y += 3;
                    }
                    if (Posicion.Y >= 300)
                    {
                        Posicion.Y = 300;
                        up = true;
                        jumping = false;
                        estado = 1;
                    }
                }
            }

            destino = origen;
            destino.X = (int)Posicion.X;
            destino.Y = (int)Posicion.Y;

            AI(i, f,balloon);
        }

        public void AI(int rng, int i, Vector2 balloon)
        {
            if (!jumping)
            {
                if (Posicion.Y <= (balloon.Y + 20) && (balloon.Y - 50) <= Posicion.Y && (balloon.X - 250) <= Posicion.X &&
                    Posicion.X <= (balloon.X + 50))
                {
                    switch (rng)
                    {
                        case 1:
                        case 2:
                        case 3:
                            estado = 2;
                            break;
                        case 4:
                            estado = 3;
                            break;
                    }
                }
                switch (i)
                {
                    case 5:
                        estado = 3;
                        break;
                }
                if (estado == 1)
                {
                    if (!backup)
                    {
                        if (Posicion.X > 0)
                        {
                            Posicion.X -= 2;
                        }
                        if (Posicion.X <= 0)
                        {
                            backup = true;
                        }
                    }
                    if (backup)
                    {
                        Posicion.X += 2;
                        if (Posicion.X >= 400)
                        {
                            backup = false;
                        }
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
