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
    class Menu
    {
        Texture2D Textura, Tx1, Tx2, g1, g2, g3;
        Rectangle[] cuadros = new Rectangle[4];
        Rectangle[] maincuadros = new Rectangle[2];
        Rectangle[] govr = new Rectangle[2];
        Rectangle menu1, menu3, dest1, dest3;
        public int select = 1;
        public bool menutype = true, gameover = false;

        public Menu(Texture2D textura, Texture2D tx1, Texture2D tx2, Texture2D go1, Texture2D go2, Texture2D go3)
        {
            Textura = textura;
            Tx1 = tx1;
            Tx2 = tx2;
            g1 = go1;
            g2 = go2;
            g3 = go3;
            Inicializa_Cuadros();
        }
        void Inicializa_Cuadros()
        {
            //1
            cuadros[0] = new Rectangle(0, 0, 193, 46);
            cuadros[1] = new Rectangle(195, 0, 193, 46);
            //3
            cuadros[2] = new Rectangle(0, 98, 193, 46);
            cuadros[3] = new Rectangle(195, 98, 193, 46);
            //main menu
            maincuadros[0] = new Rectangle(0, 0, 854, 480);
            maincuadros[1] = new Rectangle(0, 0, 854, 480);
            //gameover
            govr[0] = new Rectangle(0, 0, 1024, 1100);
            govr[1] = new Rectangle(0, 0, 1024, 1100);

        }
        public void Update(GameTime gametime)
        {
            if (!gameover)
            {
                if (menutype)
                {
                    //main menu
                    if (select == 1)
                    {
                        menu1 = maincuadros[0];
                    }
                    if (select == 2)
                    {
                        menu1 = maincuadros[1];
                    }
                    dest1 = menu1;
                    dest1.Width = 800;
                    dest1.Height = 600;
                }
                if (!menutype)
                {
                    if (select == 1)
                    {
                        menu1 = cuadros[1];
                        menu3 = cuadros[2];
                    }
                    if (select == 2)
                    {
                        menu1 = cuadros[0];
                        menu3 = cuadros[3];
                    }
                    dest1 = menu1;
                    dest3 = menu3;

                    dest1.X = 250;
                    dest3.X = 250;
                    dest1.Y = 100;
                    dest3.Y = 200;
                }
            }
            if (gameover)
            {
                if (select == 1)
                {
                    menu1 = govr[0];
                }
                if (select == 2)
                {
                    menu1 = govr[1];
                }
                if (select == 3)
                {
                    menu1 = govr[1];
                }
                dest1 = menu1;
                dest1.Width = 800;
                dest1.Height = 600;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (menutype)
            {
                if (select == 1)
                {
                    spriteBatch.Begin();
                    spriteBatch.Draw(Tx1, dest1, menu1, Color.White);
                    spriteBatch.End();
                }
                if (select == 2)
                {
                    spriteBatch.Begin();
                    spriteBatch.Draw(Tx2, dest1, menu1, Color.White);
                    spriteBatch.End();
                }
            }
            if (gameover)
            {
                if (select == 1)
                {
                    spriteBatch.Begin();
                    spriteBatch.Draw(g1, dest1, menu1, Color.White);
                    spriteBatch.End();
                }
                if (select == 2)
                {
                    spriteBatch.Begin();
                    spriteBatch.Draw(g2, dest1, menu1, Color.White);
                    spriteBatch.End();
                }
                if (select == 3)
                {
                    spriteBatch.Begin();
                    spriteBatch.Draw(g3, dest1, menu1, Color.White);
                    spriteBatch.End();
                }
            }
            if (!menutype && !gameover)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(Textura, dest1, menu1, Color.White);
                spriteBatch.Draw(Textura, dest3, menu3, Color.White);
                spriteBatch.End();
            }
        }
    }
}
