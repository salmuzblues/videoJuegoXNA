using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace practica
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        EscenaCuervos escena;
        Cuervo cuervo;
        Aguila aguila;
        Controlador controlador;

        Texture2D t2dFondo;
        Rectangle rFondo1;
        Rectangle rFondo2;

        int vidasCuervo = 3;

        Song MusicaFondo;
        SoundEffect Sonido;
        SoundEffectInstance EfectoAguilas;

        SoundEffect SonidoGameOver;
        SoundEffectInstance GameOver;

        SoundEffect SonidoWin;
        SoundEffectInstance Youwin;


        SpriteFont font;
        float timer = 0;

        bool continua = false;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferHeight = 720;
            graphics.PreferredBackBufferWidth = 1150;
            graphics.ApplyChanges();


        }


        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }


        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Texture2D texturaCuervo = Content.Load<Texture2D>("textures/cuervo");
            escena = new EscenaCuervos(texturaCuervo);
            cuervo = new Cuervo(texturaCuervo, 120, 776);
            aguila = new Aguila(Content.Load<Texture2D>("textures/aguilarabiosa"), 300, 150);
            controlador = new Controlador();
            controlador.crearAguila(Content.Load<Texture2D>("textures/aguilarabiosa"));

            t2dFondo = Content.Load<Texture2D>("textures/fondo");
            rFondo1 = new Rectangle(0, 0, 1150, 720);
            rFondo2 = new Rectangle(1150, 0, 1150, 720);


            //SOUND

            MusicaFondo = Content.Load<Song>("Sonidos/Mar");
            MediaPlayer.Play(MusicaFondo);
            MediaPlayer.Volume = 10.0f;
            MediaPlayer.IsRepeating = true;

            Sonido = Content.Load<SoundEffect>("Sonidos/Aguilas_efecto");
            EfectoAguilas = Sonido.CreateInstance();

            SonidoGameOver = Content.Load<SoundEffect>("Sonidos/gameOver");
            GameOver = SonidoGameOver.CreateInstance();


            SonidoWin = Content.Load<SoundEffect>("Sonidos/YouWin");
            Youwin = SonidoWin.CreateInstance();

            

            // PUNTAJE

            font = Content.Load<SpriteFont>("Fuentes/font");


            // TODO: use this.Content to load your game content here
        }


        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }


        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            var teclado = Keyboard.GetState();
            int windowHeight = graphics.GraphicsDevice.Viewport.Height;
            int windowWidth = graphics.GraphicsDevice.Viewport.Width;


            if (teclado.IsKeyDown(Keys.Enter))
            {
                continua = true;
            }

            if (continua)
            {

                MediaPlayer.Resume();

                //--------FONDO------------------------------------START
                if (controlMovimiento == 1)
                {
                    controlMovimiento = 0;

                    if (rFondo1.X == -1140)
                    {
                        rFondo1.X = 1150;
                    }
                    else
                    {
                        rFondo1.X = rFondo1.X - fondoVelocidad;
                    }

                    if (rFondo2.X == -1140)
                    {
                        rFondo2.X = 1150;
                    }
                    else
                    {
                        rFondo2.X = rFondo2.X - fondoVelocidad;
                    }


                }
                else
                {
                    controlMovimiento++;
                }
                //--------FONDO------------------------------------END

                //START codigo de viento y gravedad
                if( timer <30)
                {
                    cuervo.updateX(-5);
                }
                
                
               
                if( timer <30)
                {
                    cuervo.updateY(2);
                }

                //END codigo de viento y gravedad

                {
                    controlador.actualizarPosicion();
                }

                //teclas no utiles
                /*
                if (teclado.IsKeyDown(Keys.Down))
                {
                    int newY = cuervo.getY() + 10;
                    if (newY < windowHeight)
                    {
                        cuervo.updateY(10);
                    }

                }
                else if (teclado.IsKeyDown(Keys.Left))
                {
                    int newX = cuervo.getX() - 10;
                    if (newX > 0)
                    {
                        cuervo.updateX(-10);
                    }
                }else*/

                if (teclado.IsKeyDown(Keys.Right))
                {
                    int newX = cuervo.getX() + 10;
                    if (newX < windowWidth)
                    {
                        cuervo.updateX(10);
                    }

                }
                else if (teclado.IsKeyDown(Keys.Up))
                {
                    if (vidasCuervo > 0)
                    {
                        int newY = cuervo.getY() - 10;
                        if (newY > 0)
                        {
                            cuervo.updateY(-10);
                        }
                    }


                }

                if (controlador.checkCollision(cuervo))
                {
                    EfectoAguilas.Play();

                    if (vidasCuervo == 0)
                    {

                        vidasCuervo = 0;
                        
                    }
                    else
                    {
                        vidasCuervo = vidasCuervo - 1;
                    }

                }


                if (cuervo.getX() <= 0)
                {
                    vidasCuervo = 0;
                }

                if (cuervo.getY() >=650)
                {
                    vidasCuervo = 0;
                }

                if (vidasCuervo > 0)
                {
                    timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                    if (timer > 30)
                    {
                        controlador.regresar = false;
                        playYouwin();

                        timer = 30;
                        //continua = false;
                    }


                }
                else {
                 //   continua = false;
                    playGameOver();



                   
                }

            }
            else
            {
                MediaPlayer.Pause();
                
                
            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        private bool play = true;
        private void playGameOver() {
            if (play) {
                play = false;
                GameOver.Play(); 
            }
            
        }
        private void playYouwin()
        {
            if (play)
            {
                play = false;
                Youwin.Play();
            }

        }

        int controlMovimiento = 0;
        int fondoVelocidad = 10;
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);


            
            spriteBatch.Begin();

            spriteBatch.Draw(t2dFondo, rFondo1, Color.White);
            spriteBatch.Draw(t2dFondo, rFondo2, Color.White);

            cuervo.nextFrame(spriteBatch);

            {
                controlador.drawAguilas(spriteBatch);
            }
           
           

            spriteBatch.DrawString(font, "Tiempo:  " + timer.ToString("0.00"), new Vector2(50, 10), Color.Black);
            spriteBatch.DrawString(font, "Vidas Cuervo :  " + vidasCuervo, new Vector2(50, 40), Color.Black);



            if (timer ==0 )
            {

                spriteBatch.DrawString(font, " PRESIONE <ENTER> PARA COMENZAR  ", new Vector2(300, 110), Color.White);
            }


            if (vidasCuervo <= 0 && timer <30)
            {

                spriteBatch.DrawString(font, " ........:::: GAME OVER ::::........ \n\n", new Vector2(400, 310), Color.Red);
                
            }
            else
            {
                if (timer >= 30)
                {
                    escena.nextFrame(spriteBatch);
                    spriteBatch.DrawString(font, "LO LOGRASTE !! \nHas alcanzado a la Bandada", new Vector2(400, 210), Color.White);

                   
                }
            }
            spriteBatch.End();
            


            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
