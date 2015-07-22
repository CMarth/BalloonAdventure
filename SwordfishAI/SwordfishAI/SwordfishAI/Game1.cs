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
using Microsoft.Xna.Framework.Media;

namespace SwordfishAI
{
    public struct Collide
    {
        public int cantAreas;
        public int[,] arrCuadros;
    };

    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D balloon, swordfish, menuu, boss1, boss2, menu1, menu2, dragon, space, sp1, sp2, sp3, mgo1, mgo2, mgo3;
        GamePadState ant;
        KeyboardState ns;
        Balloony bloo;
        Menu mmenu;
        Lives vidas;
        int timer, spawn, lives=3, score, levu=3, go;
        Random rng;
        //note: when done testing the boss turn the menu to true and spwn to true
        public bool pause = false, menu = true, spwn = true, scrll = true, l1 = false, l2 = false, l3 = false, splash=false, gov = false, invi = false, play = false;
        SoundEffectInstance sfx;
        SoundEffect MainMenu;
        Splash spscreen;
        //nivel 1
        SoundEffect BGM1;
        Scrolling scrolling11;
        Scrolling scrolling12;
        Scrolling scrolling13;
        Scrolling scrolling14;
        List<Swordfish> swordies = new List<Swordfish>();
        List<Pufferfish> puffles = new List<Pufferfish>();
        List<Shark> sharkies = new List<Shark>();
        List<Jellyfish> jellies = new List<Jellyfish>();
        List<Octopus> octos = new List<Octopus>();
        List<Turtle> turtis = new List<Turtle>();
        Boss1 Crab;
        //nivel 2
        SoundEffect BGM2;
        Scrolling scrolling21;
        Scrolling scrolling22;
        Scrolling scrolling23;
        Scrolling scrolling24;
        List<Dragon> charizard = new List<Dragon>();
        List<Espinas> puerco = new List<Espinas>();
        List<Bird> birdy = new List<Bird>();
        List<plane> avion = new List<plane>();
        List<Robobalas> balas = new List<Robobalas>();
        Boss2 Robot;
        //nivel 3
        SoundEffect BGM3;
        Scrolling scrolling31;
        Scrolling scrolling32;
        Scrolling scrolling33;
        Scrolling scrolling34;
        List<Smallmeteor> meteor = new List<Smallmeteor>();
        List<Bigmeteor> bmeteor = new List<Bigmeteor>();
        List<Fire> fire = new List<Fire>();
        List<Satelite> satelite = new List<Satelite>();
        List<UFO> ovni = new List<UFO>();
        //end
        Video Ending;
        VideoPlayer videoPlayer = new VideoPlayer();

        SpriteFont texto;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
            //graphics.IsFullScreen = true;
        }

        
        protected override void Initialize()
        {
            ant = GamePad.GetState(PlayerIndex.One);
            base.Initialize();
        }

        
        protected override void LoadContent()
        {
            go = 0;
            spriteBatch = new SpriteBatch(GraphicsDevice);
            texto = Content.Load<SpriteFont>("fuente");
            //menu
            menuu = Content.Load<Texture2D>("img/wip menu");
            menu1 = Content.Load<Texture2D>("img/menu1");
            menu2 = Content.Load<Texture2D>("img/menu2");
            mgo1 = Content.Load<Texture2D>("img/Continue");
            mgo2 = Content.Load<Texture2D>("img/Exit");
            mgo3 = Content.Load<Texture2D>("img/GO");
            mmenu = new Menu(menuu, menu1, menu2, mgo1, mgo2, mgo3);
            MainMenu = Content.Load<SoundEffect>("BGM/NativeSon");
            //balloon
            balloon = Content.Load<Texture2D>("img/balloon");
            bloo = new Balloony(balloon, new Vector2(100, 100));
            vidas = new Lives(balloon);
            //nivel 1
            BGM1 = Content.Load<SoundEffect>("BGM/jo1");
            swordfish = Content.Load<Texture2D>("img/level1");
            boss1 = Content.Load<Texture2D>("img/boss1");
            Crab = new Boss1(boss1, new Vector2(800, 300));
            scrolling11 = new Scrolling(Content.Load<Texture2D>("Background/fondo_1"), new Rectangle(0, 0, 1500, 600));
            scrolling12 = new Scrolling(Content.Load<Texture2D>("Background/fondo_2"), new Rectangle(1500, 0, 1500, 600));
            scrolling13 = new Scrolling(Content.Load<Texture2D>("Background/fondo_3"), new Rectangle(3000, 0, 1500, 600));
            scrolling14 = new Scrolling(Content.Load<Texture2D>("Background/fondo_4"), new Rectangle(4500, 0, 1500, 600));
            //nivel 2
            BGM2 = Content.Load<SoundEffect>("BGM/jo2");
            dragon = Content.Load<Texture2D>("img/level2");
            boss2 = Content.Load<Texture2D>("img/boss2");
            Robot = new Boss2(boss2, new Vector2(800,130));
            scrolling21 = new Scrolling(Content.Load<Texture2D>("Background/bg2_1"), new Rectangle(0, 0, 1500, 600));
            scrolling22 = new Scrolling(Content.Load<Texture2D>("Background/bg2_2"), new Rectangle(1500, 0, 1500, 600));
            scrolling23 = new Scrolling(Content.Load<Texture2D>("Background/bg2_3"), new Rectangle(3000, 0, 1500, 600));
            scrolling24 = new Scrolling(Content.Load<Texture2D>("Background/bg2_4"), new Rectangle(4500, 0, 1500, 600));
            //nivel 3
            BGM3 = Content.Load<SoundEffect>("BGM/jo3");
            space = Content.Load<Texture2D>("img/level3");
            scrolling31 = new Scrolling(Content.Load<Texture2D>("Background/bg3_1"), new Rectangle(0, 0, 1300, 600));
            scrolling32 = new Scrolling(Content.Load<Texture2D>("Background/bg3_2"), new Rectangle(1300, 0, 1300, 600));
            scrolling33 = new Scrolling(Content.Load<Texture2D>("Background/bg3_3"), new Rectangle(2600, 0, 1300, 600));
            scrolling34 = new Scrolling(Content.Load<Texture2D>("Background/bg3_4"), new Rectangle(3900, 0, 1300, 600));
            //splash screens
            sp1 = Content.Load<Texture2D>("img/Splash1");
            sp2 = Content.Load<Texture2D>("img/Splash2");
            sp3 = Content.Load<Texture2D>("img/Splash3");
            //video
            Ending = Content.Load<Video>("video/balloonadventure");
            //main menu music
            sfx = MainMenu.CreateInstance();
            sfx.Play();
        }

        
        protected override void UnloadContent()
        {
            
        }

        
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || ns.IsKeyDown(Keys.Escape))
                this.Exit();
            //keyboard shit, delete later
            ns = Keyboard.GetState();
            //menu
            if (menu)
            {
                lives = 3;
                mmenu.menutype = true;
                mmenu.gameover = false;
                mmenu.Update(gameTime);
                if (((GamePad.GetState(PlayerIndex.One).DPad.Down == ButtonState.Pressed) && (ant.DPad.Down == ButtonState.Released)) || ns.IsKeyDown(Keys.S))
                {
                    mmenu.select--;
                    if (mmenu.select < 1)
                    {
                        mmenu.select++;
                    }
                }
                if (((GamePad.GetState(PlayerIndex.One).DPad.Up == ButtonState.Pressed) && (ant.DPad.Up == ButtonState.Released)) || ns.IsKeyDown(Keys.W))
                {
                    mmenu.select++;
                    if (mmenu.select > 2)
                    {
                        mmenu.select--;
                    }
                }
                if (((GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed) && (ant.Buttons.A == ButtonState.Released)) || ns.IsKeyDown(Keys.Q))
                {
                    if (mmenu.select == 1)
                    {
                        sfx.Stop();
                        levu = 1;
                        menu = false;
                        spscreen = new Splash(sp1);
                        splash = true;
                    }
                    if (mmenu.select == 2)
                    {
                        this.Exit();
                    }
                }
            }
            if (gov && !menu)
            {
                sfx.Stop();
                if (go > 3)
                {
                    mmenu.select = 3;
                }
                mmenu.menutype = false;
                mmenu.gameover = true;
                mmenu.Update(gameTime);
                if (go < 3)
                {
                    if (((GamePad.GetState(PlayerIndex.One).DPad.Left == ButtonState.Pressed) && (ant.DPad.Left == ButtonState.Released)) || ns.IsKeyDown(Keys.A))
                    {
                        mmenu.select--;
                        if (mmenu.select < 1)
                        {
                            mmenu.select++;
                        }
                    }
                    if (((GamePad.GetState(PlayerIndex.One).DPad.Right == ButtonState.Pressed) && (ant.DPad.Right == ButtonState.Released)) || ns.IsKeyDown(Keys.D))
                    {
                        mmenu.select++;
                        if (mmenu.select > 2)
                        {
                            mmenu.select--;
                        }
                    }
                }
                if (((GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed) && (ant.Buttons.A == ButtonState.Released)) || 
                    ns.IsKeyDown(Keys.E))
                {
                    if (mmenu.select == 1)
                    {
                        gameover();
                    }
                    if (mmenu.select == 2)
                    {
                        this.Exit();
                    }
                    if (mmenu.select == 3)
                    {
                        go = 0;
                        menu = true;
                        gov = false;
                        endgame();
                    }
                }
            }
            //game
            if (!menu && !gov)
            {
                //pause check
                if (((GamePad.GetState(PlayerIndex.One).Buttons.Start == ButtonState.Pressed) && (ant.Buttons.Start == ButtonState.Released)) || ns.IsKeyDown(Keys.Enter))
                {
                    if (pause == true)
                    {
                        pause = false;
                    }
                    else
                    {
                        pause = true;
                    }
                }
                //splash screens, can't pause
                if (splash)
                {
                    spscreen.Update(gameTime);
                    if (!spscreen.splash)
                    {
                        if (levu == 1)
                        {
                            l1 = true;
                            sfx = BGM1.CreateInstance();
                            sfx.Play();
                        }
                        if (levu == 2)
                        {
                            l2 = true;
                            bloo.Posicion.X = 20;
                            scrll = true;
                            spwn = true;
                            sfx = BGM2.CreateInstance();
                            sfx.Play();
                        }
                        if (levu == 3)
                        {
                            l3 = true;
                            bloo.Posicion.X = 20;
                            spwn = true;
                            scrll = true;
                            sfx = BGM3.CreateInstance();
                            sfx.Play();
                        }
                        splash = false;
                    }
                }
                //no pause
                if (!pause)
                {
                    if (!splash)
                    {
                        timer += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
                        if (timer % 100 == 0)
                        {
                            score++;
                        }
                        rng = new Random((int)gameTime.TotalGameTime.TotalMilliseconds);

                        //move the balloon
                        if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y >= 0.05f || ns.IsKeyDown(Keys.W))
                        {
                            bloo.Posicion.Y -= 2;
                            if (bloo.Posicion.Y <= -20)
                            {
                                bloo.Posicion.Y += 2;
                            }
                        }

                        if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y <= -0.05f || ns.IsKeyDown(Keys.S))
                        {
                            bloo.Posicion.Y += 2;
                            if (bloo.Posicion.Y >= 530)
                            {
                                bloo.Posicion.Y -= 2;
                            }
                        }

                        if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X > 0.05f || ns.IsKeyDown(Keys.D))
                        {
                            bloo.Posicion.X += 3;
                            if (bloo.bloo)
                            {
                                bloo.estado = 1;
                            }
                            if (bloo.Posicion.X >= 700 && scrll == true)
                                bloo.Posicion.X -= 3;
                        }

                        if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X <= -0.05f || ns.IsKeyDown(Keys.A))
                        {
                            bloo.Posicion.X--;
                            if (bloo.bloo)
                            {
                                bloo.estado = 0;
                            }
                        }
                        if (ns.IsKeyUp(Keys.D) && ns.IsKeyUp(Keys.W) && ns.IsKeyUp(Keys.S))
                        {
                            if (bloo.bloo)
                            {
                                bloo.estado = 0;
                            }

                        }
                        //if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X < 0.05f)
                        //{
                        //    bloo.estado = 0;
                        //}
                        
                        if (scrll == true)
                            bloo.Posicion.X--;
                        if (scrll == false)
                            bloo.Posicion.X = bloo.Posicion.X;

                        if (bloo.Posicion.X <= -30 || bloo.Posicion.Y <= -30)
                            bloo.estado = 2;

                        //level 1
                        if (l1)
                        {
                            vidas.Update(gameTime, lives);
                            if (scrolling11.rectangle.X + scrolling11.texture.Width <= 0)
                                scrolling11.rectangle.X = scrolling12.rectangle.X + scrolling12.texture.Width;

                            if (scrolling12.rectangle.X + scrolling12.texture.Width <= 0)
                            {
                                scrolling12.rectangle.X = scrolling13.rectangle.X + scrolling13.texture.Width;
                                spwn = false;
                            }

                            if (scrolling13.rectangle.X + scrolling13.texture.Width <= 0)
                                scrolling13.rectangle.X = scrolling14.rectangle.X + scrolling14.texture.Width;

                            if (scrolling14.rectangle.X + scrolling14.texture.Width <= 800)
                            {
                                scrolling14.scroll = false;
                                scrll = false;
                            }
                            //summon fish
                            if (spwn)
                            {
                                if (timer > (rng.Next(1000, 1500)))
                                {
                                    spawn = (rng.Next(1, 9));
                                    switch (spawn)
                                    {
                                        case (1):
                                            swordies.Add(new Swordfish(swordfish, new Vector2(800, -30)));
                                            break;
                                        case (2):
                                        case (3):
                                            puffles.Add(new Pufferfish(swordfish, new Vector2(800, (rng.Next(100, 400)))));
                                            break;
                                        case (4):
                                            sharkies.Add(new Shark(swordfish, new Vector2(800, (rng.Next(0, 500)))));
                                            break;
                                        case (5):
                                        case (6):
                                            jellies.Add(new Jellyfish(swordfish, new Vector2(800, (rng.Next(0, 200)))));
                                            break;
                                        case (7):
                                            octos.Add(new Octopus(swordfish, new Vector2(800, 500)));
                                            break;
                                        case (8):
                                            turtis.Add(new Turtle(swordfish, new Vector2(800, (rng.Next(100, 300)))));
                                            break;
                                    }
                                    timer = 0;
                                }
                            }
                            if (!spwn)
                            {
                                Crab.Update(gameTime, rng.Next(1, 5), rng.Next(1, 100), bloo.Posicion);
                                if (Crab.estado == 2)
                                {
                                    if (bloo.bloo)
                                    {
                                        if (bloo.Colision(Crab.Colisiones, Crab.Posicion))
                                        {
                                            bloo.estado = 2;
                                        }
                                    }
                                }
                                if (Crab.estado == 3)
                                {
                                    if (bloo.bloo)
                                    {
                                        if (bloo.Colision(Crab.Top, Crab.Posicion))
                                        {
                                            bloo.estado = 6;
                                            bloo.Posicion.Y -= 6;
                                        }
                                        if (bloo.Colision(Crab.Bottom, Crab.Posicion))
                                        {
                                            bloo.estado = 5;
                                            bloo.Posicion.Y += 6;
                                        }

                                        if (bloo.Colision(Crab.Jump, Crab.Posicion))
                                        {
                                            bloo.estado = 2;
                                        }

                                        if (bloo.Colision(Crab.SideL, Crab.Posicion))
                                        {
                                            bloo.estado = 4;
                                            bloo.Posicion.X -= 2;
                                        }
                                        if (bloo.Colision(Crab.SideR, Crab.Posicion))
                                        {
                                            bloo.estado = 4;
                                            bloo.Posicion.X += 2;
                                        }
                                    }
                                }
                            }
                            //load level 1
                            swordies.ForEach(delegate(Swordfish fsh)
                            {
                                fsh.Update(gameTime, bloo.Posicion);
                                if (bloo.bloo)
                                {
                                    if (bloo.Colision(fsh.Colisiones, fsh.Posicion))
                                    {
                                        bloo.estado = 2;
                                    }
                                }
                                if (fsh.Posicion.X <= -128)
                                    swordies.Remove(fsh);
                            });
                            puffles.ForEach(delegate(Pufferfish fsh)
                            {
                                fsh.Update(gameTime);
                                if (bloo.bloo)
                                {
                                    if (fsh.estado == 0)
                                    {
                                        if (bloo.Colision(fsh.Deflated, fsh.Posicion))
                                        {
                                            bloo.estado = 2;
                                        }
                                    }
                                    else
                                    {
                                        if (bloo.Colision(fsh.Colisiones, fsh.Posicion))
                                        {
                                            bloo.estado = 2;
                                        }
                                    }
                                }
                                if (fsh.Posicion.X <= -53)
                                    puffles.Remove(fsh);
                            });
                            sharkies.ForEach(delegate(Shark fsh)
                            {
                                fsh.Update(gameTime);
                                if (bloo.bloo)
                                {
                                    if (bloo.Colision(fsh.Colisiones, fsh.Posicion))
                                    {
                                        bloo.estado = 2;
                                    }
                                }
                                if (fsh.Posicion.X <= -128)
                                    sharkies.Remove(fsh);
                            });
                            jellies.ForEach(delegate(Jellyfish fsh)
                            {
                                if (bloo.bloo)
                                {
                                    if (bloo.Colision(fsh.Colisiones, fsh.Posicion))
                                    {
                                        bloo.estado = 2;
                                    }

                                    if (bloo.Colision(fsh.Squishy, fsh.Posicion))
                                    {
                                        bloo.estado = 6;
                                        bloo.Posicion.Y -= 2;
                                    }
                                }
                                fsh.Update(gameTime);
                                if (fsh.Posicion.X <= -66)
                                    jellies.Remove(fsh);
                            });
                            octos.ForEach(delegate(Octopus fsh)
                            {
                                fsh.Update(gameTime, bloo.Posicion);
                                if (bloo.bloo)
                                {
                                    if ((bloo.Colision(fsh.Colisiones, fsh.Posicion)) && fsh.estado == 1)
                                    {
                                        bloo.estado = 2;
                                    }
                                }
                                if (fsh.Posicion.X <= -121)
                                    octos.Remove(fsh);
                            });
                            turtis.ForEach(delegate(Turtle fsh)
                            {
                                fsh.Update(gameTime);
                                if (bloo.bloo)
                                {
                                    if (bloo.Colision(fsh.Top, fsh.Posicion))
                                    {
                                        bloo.estado = 6;
                                        bloo.Posicion.Y -= 2;
                                    }
                                    if (bloo.Colision(fsh.Bottom, fsh.Posicion))
                                    {
                                        bloo.estado = 5;
                                        bloo.Posicion.Y += 2;
                                    }
                                    if (fsh.a == 1 || fsh.a == 2)
                                    {
                                        if (bloo.Colision(fsh.Colisiones, fsh.Posicion))
                                        {
                                            bloo.estado = 2;
                                        }
                                    }
                                    if (fsh.a == 3 || fsh.a == 4)
                                    {
                                        if (bloo.Colision(fsh.Colisiones2, fsh.Posicion))
                                        {
                                            bloo.estado = 2;
                                        }
                                    }
                                }
                                if (fsh.Posicion.X <= -132)
                                    turtis.Remove(fsh);
                            });

                            scrolling11.Update();
                            scrolling12.Update();
                            scrolling13.Update();
                            scrolling14.Update();
                            //level end
                            if (scrll == false && bloo.Posicion.X >= 750)
                            {
                                sfx.Stop();
                                l1 = false;
                                levu = 2;
                                spscreen = new Splash(sp2);
                                splash = true;
                            }
                        }
                        if (l2)
                        {
                            vidas.Update(gameTime, lives);
                            //level 2
                            if (scrolling21.rectangle.X + scrolling21.texture.Width <= 0)
                                scrolling21.rectangle.X = scrolling22.rectangle.X + scrolling22.texture.Width;

                            if (scrolling22.rectangle.X + scrolling22.texture.Width <= 0)
                            {
                                scrolling22.rectangle.X = scrolling23.rectangle.X + scrolling23.texture.Width;
                                spwn = false;
                            }

                            if (scrolling23.rectangle.X + scrolling23.texture.Width <= 0)
                                scrolling23.rectangle.X = scrolling24.rectangle.X + scrolling24.texture.Width;

                            if (scrolling24.rectangle.X + scrolling24.texture.Width <= 800)
                            {
                                scrolling24.scroll = false;
                                scrll = false;
                            }
                            //spawn birds
                            if (spwn)
                            {
                                if (timer > (rng.Next(600, 1000)))
                                {
                                    spawn = (rng.Next(1, 7));
                                    switch (spawn)
                                    {
                                        case (1):
                                            birdy.Add(new Bird(dragon, new Vector2(800, -30)));
                                            break;
                                        case (2):
                                        case (3):
                                            charizard.Add(new Dragon(dragon, new Vector2(800, (rng.Next(0, 400)))));
                                            break;
                                        case (4):
                                        case (5):
                                            puerco.Add(new Espinas(dragon, new Vector2(800, 525)));
                                            break;
                                        case (6):
                                            avion.Add(new plane(dragon, new Vector2(800, (rng.Next(0, 100)))));
                                            break;
                                    }
                                    timer = 0;
                                }
                            }
                            if (!spwn)
                            {
                                Robot.Update(gameTime);
                                spawn = rng.Next(1, 900);
                                switch (spawn)
                                {
                                    case (30):
                                    case (50):
                                    case (10):
                                    case (40):
                                    case (80):
                                    case (130):
                                    case (150):
                                    case (110):
                                    case (140):
                                    case (180):
                                        balas.Add(new Robobalas(boss2, Robot.bulletPos1(), 0));
                                        break;
                                    case (20):
                                        balas.Add(new Robobalas(boss2, Robot.bulletPos2(), 1));
                                        break;
                                }
                                if (bloo.bloo)
                                {
                                    if (bloo.Colision(Robot.RoboL, Robot.Posicion))
                                    {
                                        bloo.estado = 4;
                                        bloo.Posicion.X -= 3;
                                    }
                                    if (bloo.Colision(Robot.RoboT, Robot.Posicion))
                                    {
                                        bloo.estado = 6;
                                        bloo.Posicion.Y -= 3;
                                    }
                                    if (bloo.Colision(Robot.RoboR, Robot.Posicion))
                                    {
                                        bloo.Posicion.X += 3;
                                    }
                                }
                            }


                            balas.ForEach(delegate(Robobalas bala)
                            {
                                bala.Update(gameTime);
                                if (bala.bsize == 0)
                                {
                                    if (bloo.bloo)
                                    {
                                        if (bloo.Colision(bala.ColisionesS, bala.Posicion))
                                        {
                                            bloo.estado = 2;
                                        }
                                    }
                                    if (bala.Posicion.X <= -128)
                                        balas.Remove(bala);
                                }
                                if (bala.bsize == 1)
                                {
                                    if (bloo.bloo)
                                    {
                                        if (bloo.Colision(bala.ColisionesM, bala.Posicion))
                                        {
                                            bloo.estado = 2;
                                        }
                                    }
                                    if (bala.Posicion.Y <= -328)
                                    {
                                        balas.Remove(bala);
                                        balas.Add(new Robobalas(boss2, new Vector2(rng.Next(0, 300), 0), rng.Next(2, 4)));
                                    }
                                }
                                if (bala.bsize == 2)
                                {
                                    if (bloo.bloo)
                                    {
                                        if (bloo.Colision(bala.Rub1, bala.Posicion))
                                        {
                                            bloo.estado = 2;
                                        }
                                    }
                                    if (bala.Posicion.Y >= 500)
                                    {
                                        balas.Remove(bala);
                                    }
                                }
                                if (bala.bsize == 3)
                                {
                                    if (bloo.bloo)
                                    {
                                        if (bloo.Colision(bala.Rub2, bala.Posicion))
                                        {
                                            bloo.estado = 2;
                                        }
                                    }
                                    if (bala.Posicion.Y >= 600)
                                    {
                                        balas.Remove(bala);
                                    }
                                }

                            });

                            birdy.ForEach(delegate(Bird brd)
                            {
                                brd.Update(gameTime, bloo.Posicion);
                                if (bloo.bloo)
                                {
                                    if (bloo.Colision(brd.Colisiones, brd.Posicion))
                                    {
                                        bloo.estado = 2;
                                    }
                                }
                                if (brd.Posicion.X <= -128)
                                    birdy.Remove(brd);
                            });
                            charizard.ForEach(delegate(Dragon drag)
                            {
                                drag.Update(gameTime);
                                if (bloo.bloo)
                                {
                                    if (bloo.Colision(drag.Colisiones, drag.Posicion))
                                    {
                                        bloo.estado = 2;
                                    }
                                    if (bloo.Colision(drag.Colisiones2, drag.Posicion))
                                    {
                                        bloo.estado = 2;
                                    }
                                    if (bloo.Colision(drag.Colisiones3, drag.Posicion))
                                    {
                                        bloo.estado = 2;
                                    }
                                }
                                if (drag.Posicion.X <= -128)
                                    charizard.Remove(drag);
                            });
                            puerco.ForEach(delegate(Espinas prc)
                            {
                                prc.Update(gameTime, bloo.Posicion);
                                if (bloo.bloo)
                                {
                                    if ((bloo.Colision(prc.Colisiones, prc.Posicion)) && prc.estado == 1)
                                    {
                                        bloo.estado = 2;
                                    }
                                }
                                if (prc.Posicion.X <= -121)
                                    puerco.Remove(prc);
                            });
                            avion.ForEach(delegate(plane pln)
                            {
                                pln.Update(gameTime);
                                if (bloo.bloo)
                                {
                                    if (bloo.Colision(pln.Colisiones, pln.Posicion))
                                    {
                                        bloo.estado = 2;
                                    }
                                }
                                if (pln.Posicion.X <= -132)
                                    avion.Remove(pln);
                            });

                            scrolling21.Update();
                            scrolling22.Update();
                            scrolling23.Update();
                            scrolling24.Update();
                            //level end
                            if (scrll == false && bloo.Posicion.X >= 750)
                            {
                                sfx.Stop();
                                levu = 3;
                                spscreen = new Splash(sp3);
                                l2 = false;
                                splash = true;
                            }
                        }
                        if (l3)
                        {
                            vidas.Update(gameTime, lives);
                            //level 3
                            if (scrolling31.rectangle.X + scrolling31.texture.Width <= 0)
                                scrolling31.rectangle.X = scrolling32.rectangle.X + scrolling32.texture.Width;

                            if (scrolling32.rectangle.X + scrolling32.texture.Width <= 0)
                            {
                                scrolling32.rectangle.X = scrolling33.rectangle.X + scrolling33.texture.Width;
                                spwn = false;
                            }

                            if (scrolling33.rectangle.X + scrolling33.texture.Width <= 0)
                                scrolling33.rectangle.X = scrolling34.rectangle.X + scrolling34.texture.Width;

                            if (scrolling34.rectangle.X + scrolling34.texture.Width <= 800)
                            {
                                scrolling34.scroll = false;
                                scrll = false;
                            }
                            //spaaace
                            if (spwn)
                            {
                                if (timer > (rng.Next(500, 800)))
                                {
                                    spawn = (rng.Next(1, 11));
                                    switch (spawn)
                                    {
                                        case (1):
                                            ovni.Add(new UFO(space, new Vector2(800, -30)));
                                            break;
                                        case (2):
                                        case (3):
                                            satelite.Add(new Satelite(space, new Vector2(800, (rng.Next(0, 400)))));
                                            break;
                                        case (4):
                                        case (5):
                                            meteor.Add(new Smallmeteor(space, new Vector2(800, (rng.Next(0, 400)))));
                                            break;
                                        case (6):
                                        case (7):
                                        case (8):
                                        case (9):
                                            bmeteor.Add(new Bigmeteor(space, new Vector2(800, (rng.Next(0, 400)))));
                                            break;
                                        case (10):
                                            fire.Add(new Fire(space, new Vector2(800, (rng.Next(0, 400)))));
                                            break;

                                    }
                                    timer = 0;
                                }
                            }
                            if (!spwn)
                            {
                                if (timer > (rng.Next(400, 700)))
                                {
                                    spawn = (rng.Next(1, 7));
                                    switch (spawn)
                                    {
                                        case (1):
                                        case (2):
                                            ovni.Add(new UFO(space, new Vector2(800, -30)));
                                            break;
                                        case (3):
                                        case (4):
                                            satelite.Add(new Satelite(space, new Vector2(800, (rng.Next(0, 400)))));
                                            break;
                                        case (5):
                                        case (6):
                                            meteor.Add(new Smallmeteor(space, new Vector2(800, (rng.Next(0, 400)))));
                                            break;
                                        case (7):
                                        case (8):
                                            bmeteor.Add(new Bigmeteor(space, new Vector2(800, (rng.Next(0, 400)))));
                                            break;
                                        case (9):
                                        case (10):
                                            fire.Add(new Fire(space, new Vector2(800, (rng.Next(0, 400)))));
                                            break;
                                    }
                                    timer = 0;
                                }
                            }
                            ovni.ForEach(delegate(UFO ufo)
                            {
                                ufo.Update(gameTime, bloo.Posicion);
                                if (bloo.bloo)
                                {
                                    if (bloo.Colision(ufo.Colisiones, ufo.Posicion))
                                    {
                                        bloo.estado = 2;
                                    }
                                }
                                if (ufo.Posicion.X <= -128)
                                    ovni.Remove(ufo);
                            });
                            satelite.ForEach(delegate(Satelite stl)
                            {
                                stl.Update(gameTime);
                                if (bloo.bloo)
                                {
                                    if (bloo.Colision(stl.Colisiones, stl.Posicion))
                                    {
                                        bloo.estado = 2;
                                    }
                                }
                                if (stl.Posicion.X <= -53)
                                    satelite.Remove(stl);
                            });

                            fire.ForEach(delegate(Fire fir)
                            {
                                fir.Update(gameTime);
                                if (bloo.bloo)
                                {
                                    if (bloo.Colision(fir.Colisiones, fir.Posicion))
                                    {
                                        bloo.estado = 2;
                                    }
                                }
                                if (fir.Posicion.X <= -128)
                                    fire.Remove(fir);
                            });

                            bmeteor.ForEach(delegate(Bigmeteor bmtr)
                            {
                                bmtr.Update(gameTime);
                                if (bloo.bloo)
                                {
                                    if (bloo.Colision(bmtr.Colisiones, bmtr.Posicion))
                                    {
                                        bloo.estado = 2;
                                    }
                                }
                                if (bmtr.Posicion.X <= -128)
                                    bmeteor.Remove(bmtr);
                            });

                            meteor.ForEach(delegate(Smallmeteor smtr)
                            {
                                smtr.Update(gameTime);
                                if (bloo.bloo)
                                {
                                    if (bloo.Colision(smtr.Colisiones, smtr.Posicion))
                                    {
                                        bloo.estado = 2;
                                    }
                                }
                                if (smtr.Posicion.X <= -128)
                                    meteor.Remove(smtr);
                            });

                            scrolling31.Update();
                            scrolling32.Update();
                            scrolling33.Update();
                            scrolling34.Update();
                            //end level
                            if (scrll == false && bloo.Posicion.X >= 750)
                            {
                                timer = 0;
                                theend(gameTime);
                                //end game
                            }
                        }

                        //balloon update
                        bloo.Update(gameTime);
                        base.Update(gameTime);
                        //die
                        if (bloo.estado == 3 && !invi)
                        {
                            lives--;
                            if (bloo.Posicion.X <= -30)
                                bloo.Posicion.X = 10;
                            if (bloo.Posicion.Y <= -30)
                                bloo.Posicion.Y = 10;
                            if (lives <= 0)
                            {
                                go++;
                                gov = true;
                            }
                            invi = true;
                            timer = 0;
                            
                        }
                        if (invi)
                        {
                            timer += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
                            if (timer >= 800)
                            {
                                bloo.bloo = true;
                                invi = false;
                                timer = 0;
                            }
                        }
                    }
                }
                //pause
                else
                {
                    mmenu.menutype = false;
                    mmenu.gameover = false;
                    mmenu.Update(gameTime);
                    if ((GamePad.GetState(PlayerIndex.One).DPad.Down == ButtonState.Pressed) && (ant.DPad.Down == ButtonState.Released) || ns.IsKeyDown(Keys.S))
                    {
                        mmenu.select++;
                        if (mmenu.select > 2)
                        {
                            mmenu.select--;
                        }
                    }
                    if ((GamePad.GetState(PlayerIndex.One).DPad.Up == ButtonState.Pressed) && (ant.DPad.Up == ButtonState.Released) || ns.IsKeyDown(Keys.W))
                    {
                        mmenu.select--;
                        if (mmenu.select < 1)
                        {
                            mmenu.select++;
                        }
                    }
                    if (((GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed) && (ant.Buttons.A == ButtonState.Released)) || ns.IsKeyDown(Keys.Q))
                    {
                        if (mmenu.select == 1)
                        {
                            pause = false;
                        }
                        if (mmenu.select == 2)
                        {
                            this.Exit();
                        }
                    }
                    //pause end below
                }
            }
            ant = GamePad.GetState(PlayerIndex.One);
        }
        void gameover()
        {
            sfx.Stop();
            swordies.ForEach(delegate(Swordfish fsh)
            {
                swordies.Remove(fsh);
            });
            puffles.ForEach(delegate(Pufferfish fsh)
            {
                puffles.Remove(fsh);
            });
            sharkies.ForEach(delegate(Shark fsh)
            {
                sharkies.Remove(fsh);
            });
            jellies.ForEach(delegate(Jellyfish fsh)
            {
                jellies.Remove(fsh);
            });
            octos.ForEach(delegate(Octopus fsh)
            {
                octos.Remove(fsh);
            });
            turtis.ForEach(delegate(Turtle fsh)
            {
                turtis.Remove(fsh);
            });
            birdy.ForEach(delegate(Bird brd)
            {
                birdy.Remove(brd);
            });
            charizard.ForEach(delegate(Dragon drag)
            {
                charizard.Remove(drag);
            });
            puerco.ForEach(delegate(Espinas prc)
            {
                puerco.Remove(prc);
            });
            avion.ForEach(delegate(plane pln)
            {
                avion.Remove(pln);
            });
            balas.ForEach(delegate(Robobalas bala)
            {
                balas.Remove(bala);
            });
            ovni.ForEach(delegate(UFO ufo)
            {
                ovni.Remove(ufo);
            });
            satelite.ForEach(delegate(Satelite stl)
            {
                satelite.Remove(stl);
            });

            fire.ForEach(delegate(Fire fir)
            {
                fire.Remove(fir);
            });

            bmeteor.ForEach(delegate(Bigmeteor bmtr)
            {
                bmeteor.Remove(bmtr);
            });

            meteor.ForEach(delegate(Smallmeteor smtr)
            {
                meteor.Remove(smtr);
            });
            if (l1)
            {
                spscreen = new Splash(sp1);
            }
            if (l2)
            {
                spscreen = new Splash(sp2);
            }
            if (l3)
            {
                spscreen = new Splash(sp3);
            }
            l1 = false;
            l2 = false;
            l3 = false;
            scrll = true;
            spwn = true;
            bloo.Posicion = new Vector2(100, 100);
            Robot.Posicion = new Vector2(800, 130);
            Crab.Posicion = new Vector2(800, 300);
            scrolling11.rectangle.X = 0;
            scrolling12.rectangle.X = 1500;
            scrolling13.rectangle.X = 3000;
            scrolling14.rectangle.X = 4500;
            scrolling21.rectangle.X = 0;
            scrolling22.rectangle.X = 1500;
            scrolling23.rectangle.X = 3000;
            scrolling24.rectangle.X = 4500;
            scrolling31.rectangle.X = 0;
            scrolling32.rectangle.X = 1300;
            scrolling33.rectangle.X = 2600;
            scrolling34.rectangle.X = 3900;
            score -= 100;
            if (score < 0)
            {
                score = 0;
            }
            splash = true;
            lives = 3;
            gov = false;
            scrolling14.scroll = true;
            scrolling24.scroll = true;
            scrolling34.scroll = true;
        }

        void endgame()
        {
            levu = 1;
            gameover();
            menu = true;
            score = 0;
            mmenu.select = 1;
            sfx = MainMenu.CreateInstance();
            sfx.Play();
        }
        void theend(GameTime gameTime)
        {
            sfx.Stop();
            play = true;
            videoPlayer.Play(Ending);
            if (videoPlayer.PlayPosition > new TimeSpan(0, 0, 28))
            {
                play = false;
                videoPlayer.Stop();
                endgame();
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            Vector2 posicionTexto = new Vector2(700, 0);
            GraphicsDevice.Clear(Color.CornflowerBlue);
            if (!menu && !gov)
            {
                //bg 1
                if (l1)
                {
                    scrolling11.Draw(spriteBatch);
                    scrolling12.Draw(spriteBatch);
                    scrolling13.Draw(spriteBatch);
                    scrolling14.Draw(spriteBatch);
                }
                //bg 2
                if (l2)
                {
                    scrolling21.Draw(spriteBatch);
                    scrolling22.Draw(spriteBatch);
                    scrolling23.Draw(spriteBatch);
                    scrolling24.Draw(spriteBatch);
                }
                //bg 3
                if (l3)
                {
                    scrolling31.Draw(spriteBatch);
                    scrolling32.Draw(spriteBatch);
                    scrolling33.Draw(spriteBatch);
                    scrolling34.Draw(spriteBatch);
                }
                
                bloo.Draw(spriteBatch);
                

                //draw fish, level 1
                    if (l1)
                    {
                        swordies.ForEach(delegate(Swordfish fsh)
                        {
                            fsh.Draw(spriteBatch);
                        });
                        puffles.ForEach(delegate(Pufferfish fsh)
                        {
                            fsh.Draw(spriteBatch);
                        });
                        sharkies.ForEach(delegate(Shark fsh)
                        {
                            fsh.Draw(spriteBatch);
                        });
                        turtis.ForEach(delegate(Turtle fsh)
                        {
                            fsh.Draw(spriteBatch);
                        });
                        jellies.ForEach(delegate(Jellyfish fsh)
                        {
                            fsh.Draw(spriteBatch);
                        });
                        octos.ForEach(delegate(Octopus fsh)
                        {
                            fsh.Draw(spriteBatch);
                        });
                        
                        if (!spwn)
                        {
                            Crab.Draw(spriteBatch);
                        }
                    }
                //draw birds, level 2
                if (l2)
                {
                    if (spwn)
                    {
                        birdy.ForEach(delegate(Bird brd)
                        {
                            brd.Draw(spriteBatch);
                        });
                        charizard.ForEach(delegate(Dragon drag)
                        {
                            drag.Draw(spriteBatch);
                        });
                        avion.ForEach(delegate(plane pln)
                        {
                            pln.Draw(spriteBatch);
                        });
                        puerco.ForEach(delegate(Espinas prc)
                        {
                            prc.Draw(spriteBatch);
                        });
                    }
                    if (!spwn)
                    {
                        Robot.Draw(spriteBatch);
                        balas.ForEach(delegate(Robobalas bala)
                        {
                            bala.Draw(spriteBatch);
                        });
                    }
                }
                //draw space, space core would be proud
                if (l3)
                    {
                        /*if (spwn)
                        {*/
                            ovni.ForEach(delegate(UFO ufo)
                            {
                                ufo.Draw(spriteBatch);
                            });

                            satelite.ForEach(delegate(Satelite stl)
                            {
                                stl.Draw(spriteBatch);
                            });

                            meteor.ForEach(delegate(Smallmeteor smtr)
                            {
                                smtr.Draw(spriteBatch);
                            });

                            bmeteor.ForEach(delegate(Bigmeteor bmtr)
                            {
                                bmtr.Draw(spriteBatch);
                            });

                            fire.ForEach(delegate(Fire fir)
                            {
                                fir.Draw(spriteBatch);
                            });                            
                        //}
                        /*if (!spwn)
                        {
                           //boss here
                        }*/
                    }
                if (splash)
                {
                    spscreen.Draw(spriteBatch);
                }
                if (!splash)
                {
                    spriteBatch.Begin();
                    spriteBatch.DrawString(texto, score.ToString(), posicionTexto, Color.White);
                    spriteBatch.End();
                    vidas.Draw(spriteBatch);
                }
                //if the game is paused, draw over the game
                if (pause)
                {
                    mmenu.Draw(spriteBatch);
                }
                if (play)
                {
                    spriteBatch.Begin();
                    spriteBatch.Draw(videoPlayer.GetTexture(), new Rectangle(0, 0, 800, 600), Color.CornflowerBlue);
                    spriteBatch.End();
                }
                base.Draw(gameTime);
                
            }
            if (menu)
            {
                mmenu.Draw(spriteBatch);
                base.Draw(gameTime);
            }
            if (gov)
            {
                mmenu.Draw(spriteBatch);
                base.Draw(gameTime);
            }
        }
    }
}
