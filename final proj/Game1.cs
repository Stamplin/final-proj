using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace final_proj
{
    public class Game1 : Game 
        //TODO:
        //Redo the art and design
        //Redo the characters hitbox
        //Make screens
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        KeyboardState keyboardState, prevKeyboardState;

        //import background
        Texture2D backgroundTexture, introTexture, helpTexture, crowdTexture;

        //import charaters
        Texture2D keyboardTexture, guitarTexture, drumTexture, vocalTexture;

        //drum sound effects imports
        SoundEffect drum1, drum2, drum3, drum4;
        SoundEffectInstance drum1Instance, drum2Instance, drum3Instance, drum4Instance;

        //guitars sound effects imports
        SoundEffect guitar1, guitar2, guitar3, guitar4;
        SoundEffectInstance guitar1Instance, guitar2Instance, guitar3Instance, guitar4Instance;

        //keyboard sound effects imports
        SoundEffect keyboard1, keyboard2, keyboard3, keyboard4;
        SoundEffectInstance keyboard1Instance, keyboard2Instance, keyboard3Instance, keyboard4Instance;

        //vocal sound effects imports
        SoundEffect vocal1, vocal2, vocal3, vocal4;
        SoundEffectInstance vocal1Instance, vocal2Instance, vocal3Instance, vocal4Instance;

        //import the instuments 
        Texture2D drum, guitar, keyboard, vocal;

        //rect for charaters
        Rectangle keyboardRect = new Rectangle(900, 430, 130, 130);//purple
        Rectangle guitarRect = new Rectangle(290, 430, 130, 130);//cheeky
        Rectangle drumRect = new Rectangle(690, 370, 130, 130); //sunglasses
        Rectangle vocalRect = new Rectangle(480, 370, 130, 130); //red

        //rect for instruments
        Rectangle keyboardInRect = new Rectangle(900, 180, 120, 120);
        Rectangle guitarInRect = new Rectangle(290, 180, 120, 120);
        Rectangle drumInRect = new Rectangle(480, 180, 120, 120);
        Rectangle vocalInRect = new Rectangle(690, 180, 100, 100);

        //bool is dragging instruments
        bool isDraggingKeyboard, isDraggingGuitar, isDraggingDrum, isDraggingVocal, isPaused;

        bool guitarOn, drumOn, keyboardOn, vocalOn;


        //mousestate
        MouseState currentMouseState, previousMouseState;

        //import menu music
        SoundEffect menuMusic;
        SoundEffectInstance menuMusicInstance;
        
        float x, y, seconds;


        //screens intro and game
        enum Screen
        {
            Intro,
            Help,
            Game
        }
        Screen screen;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            _graphics.PreferredBackBufferHeight = 720;
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.ApplyChanges();

            //instruemnt dragging
            isDraggingKeyboard = false;
            isDraggingGuitar = false;
            isDraggingDrum = false;
            isDraggingVocal = false;

            base.Initialize();

            seconds = 0f;
            

            //play all sound
            guitar1Instance.Play();
            guitar2Instance.Play();
            guitar3Instance.Play();
            guitar4Instance.Play();
            vocal1Instance.Play();
            vocal2Instance.Play();
            vocal3Instance.Play();
            vocal4Instance.Play();
            drum1Instance.Play();
            drum2Instance.Play();
            drum3Instance.Play();
            drum4Instance.Play();
            keyboard1Instance.Play();
            keyboard2Instance.Play();
            keyboard3Instance.Play();
            keyboard4Instance.Play();
            menuMusicInstance.Play();
           

            //set volume to 0
            guitar1Instance.Volume = 0;
            guitar2Instance.Volume = 0;
            guitar3Instance.Volume = 0;
            guitar4Instance.Volume = 0;
            vocal1Instance.Volume = 0;
            vocal2Instance.Volume = 0;
            vocal3Instance.Volume = 0;
            vocal4Instance.Volume = 0;
            drum1Instance.Volume = 0;
            drum2Instance.Volume = 0;
            drum3Instance.Volume = 0;
            drum4Instance.Volume = 0;
            keyboard1Instance.Volume = 0;
            keyboard2Instance.Volume = 0;
            keyboard3Instance.Volume = 0;
            keyboard4Instance.Volume = 0;
            menuMusicInstance.Volume = 0;

            //Starter screen
            screen = Screen.Intro;

        }

        protected override void LoadContent()
        {

            _spriteBatch = new SpriteBatch(GraphicsDevice);
           
            //load images
            backgroundTexture = Content.Load<Texture2D>("Background");
            introTexture = Content.Load<Texture2D>("Intro");
            helpTexture = Content.Load<Texture2D>("Help");
            crowdTexture = Content.Load<Texture2D>("Crowd");
            
            //load sound
            guitar1 = Content.Load<SoundEffect>("guitar/guitar(1)");
            guitar2 = Content.Load<SoundEffect>("guitar/guitar(2)");
            guitar3 = Content.Load<SoundEffect>("guitar/guitar(3)");
            guitar4 = Content.Load<SoundEffect>("guitar/guitar(4)");
            guitar1Instance = guitar1.CreateInstance();
            guitar2Instance = guitar2.CreateInstance();
            guitar3Instance = guitar3.CreateInstance();
            guitar4Instance = guitar4.CreateInstance();
            
            //load drums    
            drum1 = Content.Load<SoundEffect>("drums/drum(1)");
            drum2 = Content.Load<SoundEffect>("drums/drum(2)");
            drum3 = Content.Load<SoundEffect>("drums/drum(3)");
            drum4 = Content.Load<SoundEffect>("drums/drum(4)");
            drum1Instance = drum1.CreateInstance();
            drum2Instance = drum2.CreateInstance();
            drum3Instance = drum3.CreateInstance();
            drum4Instance = drum4.CreateInstance();
            
            //load keyboard
            keyboard1 = Content.Load<SoundEffect>("keyboard/keyboard(1)");
            keyboard2 = Content.Load<SoundEffect>("keyboard/keyboard(2)");
            keyboard3 = Content.Load<SoundEffect>("keyboard/keyboard(3)");
            keyboard4 = Content.Load<SoundEffect>("keyboard/keyboard(4)");
            keyboard1Instance = keyboard1.CreateInstance();
            keyboard2Instance = keyboard2.CreateInstance();
            keyboard3Instance = keyboard3.CreateInstance();
            keyboard4Instance = keyboard4.CreateInstance();
            
            //load vocals
            vocal1 = Content.Load<SoundEffect>("vocal/vocal(1)");
            vocal2 = Content.Load<SoundEffect>("vocal/vocal(2)");
            vocal3 = Content.Load<SoundEffect>("vocal/vocal(3)");
            vocal4 = Content.Load<SoundEffect>("vocal/vocal(4)");
            vocal1Instance = vocal1.CreateInstance();
            vocal2Instance = vocal2.CreateInstance();
            vocal3Instance = vocal3.CreateInstance();
            vocal4Instance = vocal4.CreateInstance();

            //load menu 
            menuMusic = Content.Load<SoundEffect>("menu");
            menuMusicInstance = menuMusic.CreateInstance();

            //Load Charaters
            drumTexture = Content.Load<Texture2D>("Charater/drum/drumNormal");
            guitarTexture = Content.Load<Texture2D>("Charater/guitar/guitarNormal");
            keyboardTexture = Content.Load<Texture2D>("Charater/keyboard/keyNormal");
            vocalTexture = Content.Load<Texture2D>("Charater/vocal/vocalNormal");

            //load instuments
            keyboard = Content.Load<Texture2D>("keyboard");
            guitar = Content.Load<Texture2D>("guitar");
            drum = Content.Load<Texture2D>("drum");
            vocal = Content.Load<Texture2D>("mic");

            // TODO: use this.Content to load your game content here
        }

        // Returns true when a left click occurs -Mouse state
        protected bool NewClick()
        {
            return currentMouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released;
        }

        protected override void Update(GameTime gameTime)
        {
            //add mouse state update
            previousMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();

            prevKeyboardState = keyboardState;
            keyboardState = Keyboard.GetState();


            //screen from intro to help or game screen
            if (screen == Screen.Intro)
            {
                menuMusicInstance.IsLooped = true;
                menuMusicInstance.Volume = 1f;
                //exit when esc is pressed
                if (keyboardState.IsKeyDown(Keys.Escape) && prevKeyboardState.IsKeyUp(Keys.Escape))
                    Exit();

                //go to help screen when h is pressed
                if (keyboardState.IsKeyDown(Keys.H) && prevKeyboardState.IsKeyUp(Keys.H))
                {
                    screen = Screen.Help;
                }

                //when enter is pressed go to game screen
                if (keyboardState.IsKeyDown(Keys.Enter) && prevKeyboardState.IsKeyUp(Keys.Enter))
                {
                    screen = Screen.Game;
                }

            }
            else if (screen == Screen.Help)
            {
                menuMusicInstance.IsLooped = true;
                menuMusicInstance.Volume = 1f;
                //go back to home when esc is pressed
                if (keyboardState.IsKeyDown(Keys.Escape) && prevKeyboardState.IsKeyUp(Keys.Escape))
                {
                    screen = Screen.Intro;
                }
                //when enter is pressed go to game screen
                if (keyboardState.IsKeyDown(Keys.Enter) && prevKeyboardState.IsKeyUp(Keys.Enter))
                {
                    screen = Screen.Game;
                }
            }
            else if (screen == Screen.Game)
            {
                if((guitarOn || drumOn || keyboardOn || vocalOn) && !isPaused)
                {
                    seconds += (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
                y = (float)Math.Sin(seconds) * 10;
                x = (float)Math.Cos(seconds) * 5;

                menuMusicInstance.Volume = 0f;
                //go back to intro screen when esc is pressed
                if (keyboardState.IsKeyDown(Keys.Escape) && prevKeyboardState.IsKeyUp(Keys.Escape))
                {
                    screen = Screen.Intro;
                }
                //make if "r" is pressed then reset the position of the instruments
                if (keyboardState.IsKeyDown(Keys.R) && prevKeyboardState.IsKeyUp(Keys.R))
                {

                    keyboardInRect.Location = new Point(900, 180);
                    guitarInRect = new Rectangle(290, 180, 120, 120);
                    drumInRect = new Rectangle(480, 180, 120, 120);
                    vocalInRect = new Rectangle(690, 180, 100, 100);
                }   
                //toggle pause when space is pressed set all volume to zero
                if (keyboardState.IsKeyDown(Keys.Space) && prevKeyboardState.IsKeyUp(Keys.Space))
                {
                    //toggle on off with space bar
                    isPaused = !isPaused;

                    if (isPaused)
                    {
                        guitar1Instance.Volume = 0f;
                        guitar2Instance.Volume = 0f;
                        guitar3Instance.Volume = 0f;
                        guitar4Instance.Volume = 0f;
                        vocal1Instance.Volume = 0f;
                        vocal2Instance.Volume = 0f;
                        vocal3Instance.Volume = 0f;
                        vocal4Instance.Volume = 0f;
                        drum1Instance.Volume = 0f;
                        drum2Instance.Volume = 0f;
                        drum3Instance.Volume = 0f;
                        drum4Instance.Volume = 0f;
                        keyboard1Instance.Volume = 0f;
                        keyboard2Instance.Volume = 0f;
                        keyboard3Instance.Volume = 0f;
                        keyboard4Instance.Volume = 0f;

                        //and make the drag able instrument un-dragable
                        isDraggingGuitar = false;
                        isDraggingKeyboard = false;
                        isDraggingDrum = false;
                        isDraggingVocal = false;
                    }
                    //reset volume back and set the drag able instrument dragable
                    else
                    {
                        guitar1Instance.Volume = 1f;
                        guitar2Instance.Volume = 1f;
                        guitar3Instance.Volume = 1f;
                        guitar4Instance.Volume = 1f;
                        vocal1Instance.Volume = 1f;
                        vocal2Instance.Volume = 1f;
                        vocal3Instance.Volume = 1f;
                        vocal4Instance.Volume = 1f;
                        drum1Instance.Volume = 1f;
                        drum2Instance.Volume = 1f;
                        drum3Instance.Volume = 1f;
                        drum4Instance.Volume = 1f;
                        keyboard1Instance.Volume = 1f;
                        keyboard2Instance.Volume = 1f;
                        keyboard3Instance.Volume = 1f;
                        keyboard4Instance.Volume = 1f;

                        isDraggingGuitar = true;
                        isDraggingKeyboard = true;
                        isDraggingDrum = true;
                        isDraggingVocal = true;
                    }

                }

                if (!isPaused)
                {
                    //Dragging the instruments anywhere
                    if (NewClick() && guitarInRect.Contains(currentMouseState.Position))
                    {
                        isDraggingGuitar = true;
                    }
                    else if (isDraggingGuitar && currentMouseState.LeftButton == ButtonState.Released)
                        isDraggingGuitar = false;
                    else if (isDraggingGuitar)
                        guitarInRect.Offset(currentMouseState.X - previousMouseState.X, currentMouseState.Y - previousMouseState.Y);

                    if (NewClick() && keyboardInRect.Contains(currentMouseState.Position))
                        isDraggingKeyboard = true;
                    else if (isDraggingKeyboard && currentMouseState.LeftButton == ButtonState.Released)
                        isDraggingKeyboard = false;
                    else if (isDraggingKeyboard)
                        keyboardInRect.Offset(currentMouseState.X - previousMouseState.X, currentMouseState.Y - previousMouseState.Y);

                    if (NewClick() && drumInRect.Contains(currentMouseState.Position))
                        isDraggingDrum = true;
                    else if (isDraggingDrum && currentMouseState.LeftButton == ButtonState.Released)
                        isDraggingDrum = false;
                    else if (isDraggingDrum)
                        drumInRect.Offset(currentMouseState.X - previousMouseState.X, currentMouseState.Y - previousMouseState.Y);

                    if (NewClick() && vocalInRect.Contains(currentMouseState.Position))
                        isDraggingVocal = true;
                    else if (isDraggingVocal && currentMouseState.LeftButton == ButtonState.Released)
                        isDraggingVocal = false;
                    else if (isDraggingVocal)
                        vocalInRect.Offset(currentMouseState.X - previousMouseState.X, currentMouseState.Y - previousMouseState.Y);

                    //================================================================

                    //if the instrument touches or over a character it pays a sound based on the instrument and the charater AND MAKE IT STOP PLAYING WHEN IT STOP TOUCHING

                    //GUITAR - ON
                    guitarOn = false;
                    if (guitarInRect.Intersects(guitarRect))
                    {
                        guitar1Instance.Volume = 1f;
                        guitarOn = true;
                    }
                    else if (guitarInRect.Intersects(keyboardRect))
                    {
                        guitar2Instance.Volume = 1f;
                        guitarOn = true;
                    }
                    else if (guitarInRect.Intersects(vocalRect))
                    {
                        guitar3Instance.Volume = 1f;
                        guitarOn = true;
                    }
                    else if (guitarInRect.Intersects(drumRect))
                    {
                        guitar4Instance.Volume = 1f;
                        guitarOn = true;
                    }
                    else 
                        guitarOn = false;

                    //GUITAR - OFF
                    if (!guitarInRect.Intersects(guitarRect))
                        guitar1Instance.Volume = 0f;
                    if (!guitarInRect.Intersects(keyboardRect))
                        guitar2Instance.Volume = 0f;
                    if (!guitarInRect.Intersects(vocalRect))
                        guitar3Instance.Volume = 0f;
                    if (!guitarInRect.Intersects(drumRect))
                        guitar4Instance.Volume = 0f;

                    //MIC - ON
                    vocalOn = false;
                    if (vocalInRect.Intersects(guitarRect))
                    {
                        vocal1Instance.Volume = 1f;
                        vocalOn = true;
                    }
                    else if (vocalInRect.Intersects(keyboardRect))
                    {
                        vocal2Instance.Volume = 1f;
                        vocalOn = true;
                    }
                    else if (vocalInRect.Intersects(vocalRect))
                    {
                        vocal3Instance.Volume = 1f;
                        vocalOn = true;
                    }
                    else if (vocalInRect.Intersects(drumRect))
                    {
                        vocal4Instance.Volume = 1f;
                        vocalOn = true;
                    }
                    else vocalOn = false;

                    //MIC - OFF
                    if (!vocalInRect.Intersects(guitarRect))
                        vocal1Instance.Volume = 0f;
                    if (!vocalInRect.Intersects(keyboardRect))
                        vocal2Instance.Volume = 0f;
                    if (!vocalInRect.Intersects(vocalRect))
                        vocal3Instance.Volume = 0f;
                    if (!vocalInRect.Intersects(drumRect))
                        vocal4Instance.Volume = 0f;

                    //DRUM - ON
                    drumOn = false;
                    if (drumInRect.Intersects(guitarRect))
                    {
                        drum1Instance.Volume = 1f;
                        vocalOn = true;
                    }
                    else if (drumInRect.Intersects(keyboardRect))
                    {
                        drum2Instance.Volume = 1f;
                        vocalOn = true;
                    }
                    else if (drumInRect.Intersects(vocalRect))
                    {
                        drum3Instance.Volume = 1f;
                        vocalOn = true;
                    }
                    else if (drumInRect.Intersects(drumRect))
                    {
                        drum4Instance.Volume = 1f;
                        vocalOn = true;
                    }
                    else drumOn = false;

                    //DRUM - OFF
                    if (!drumInRect.Intersects(guitarRect))
                        drum1Instance.Volume = 0f;
                    if (!drumInRect.Intersects(keyboardRect))
                        drum2Instance.Volume = 0f;
                    if (!drumInRect.Intersects(vocalRect))
                        drum3Instance.Volume = 0f;
                    if (!drumInRect.Intersects(drumRect))
                        drum4Instance.Volume = 0f;

                    //KEYBOARD - ON
                    keyboardOn = false;
                    if (keyboardInRect.Intersects(guitarRect))
                    {
                        keyboard1Instance.Volume = 1f;
                        vocalOn = true;
                    }
                    else if (keyboardInRect.Intersects(keyboardRect))
                    {
                        keyboard1Instance.Volume = 1f;
                        vocalOn = true;
                    }
                    else if (keyboardInRect.Intersects(vocalRect))
                    {
                        keyboard1Instance.Volume = 1f;
                        vocalOn = true;
                    }
                    else if (keyboardInRect.Intersects(drumRect))
                    {
                        keyboard1Instance.Volume = 1f;
                        vocalOn = true;
                    }
                    else keyboardOn = false;

                    //KEYBOARD - OFF
                    if (!keyboardInRect.Intersects(guitarRect))
                        keyboard1Instance.Volume = 0f;
                    if (!keyboardInRect.Intersects(keyboardRect))
                        keyboard2Instance.Volume = 0f;
                    if (!keyboardInRect.Intersects(vocalRect))
                        keyboard3Instance.Volume = 0f;
                    if (!keyboardInRect.Intersects(drumRect))
                        keyboard4Instance.Volume = 0f;

                    //================================================================

                    //load all the sound effects and loop them
                    guitar1Instance.IsLooped = true;
                    guitar2Instance.IsLooped = true;
                    guitar3Instance.IsLooped = true;
                    guitar4Instance.IsLooped = true;

                    drum1Instance.IsLooped = true;
                    drum2Instance.IsLooped = true;
                    drum3Instance.IsLooped = true;
                    drum4Instance.IsLooped = true;

                    keyboard1Instance.IsLooped = true;
                    keyboard2Instance.IsLooped = true;
                    keyboard3Instance.IsLooped = true;
                    keyboard4Instance.IsLooped = true;

                    vocal1Instance.IsLooped = true;
                    vocal2Instance.IsLooped = true;
                    vocal3Instance.IsLooped = true;
                    vocal4Instance.IsLooped = true;

                    
                }
            }
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            SpriteBatch spriteBatch = new SpriteBatch(GraphicsDevice);

            _spriteBatch.Begin();

            if (screen == Screen.Intro)
            {
                _spriteBatch.Draw(introTexture, new Rectangle(0, 0, 1280, 720), Color.White);
            }
            if (screen == Screen.Game)
            {
                _spriteBatch.Draw(backgroundTexture, new Rectangle(0, 0, 1280, 720), Color.LightGray);

                //draw the band members
                _spriteBatch.Draw(vocalTexture, vocalRect, Color.White);
                _spriteBatch.Draw(guitarTexture, guitarRect, Color.White);
                _spriteBatch.Draw(drumTexture, drumRect, Color.White);
                _spriteBatch.Draw(keyboardTexture, keyboardRect, Color.White);

                //load insturments
                _spriteBatch.Draw(vocal, vocalInRect, Color.White);
                _spriteBatch.Draw(guitar, guitarInRect, Color.White);
                _spriteBatch.Draw(drum, drumInRect, Color.White);
                _spriteBatch.Draw(keyboard, keyboardInRect, Color.White);

                //load crowd
                _spriteBatch.Draw(crowdTexture, new Rectangle(new Vector2(x, y).ToPoint(), new Point(1280, 750)), Color.White);
            }
            if (screen == Screen.Help)
            {
                _spriteBatch.Draw(helpTexture, new Rectangle(0, 0, 1280, 720), Color.White);
            }
           
            
            // TODO: Add your drawing code here

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
