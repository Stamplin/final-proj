using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace final_proj
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //import background
        Texture2D backgroundTexture;

        //import charaters
        Texture2D keyboardTexture, guitarTexture, drumTexture, vocalTexture;
        Texture2D keyboardDanceTexture, guitarDanceTexture, drumDanceTexture, vocalDanceTexture;

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
        Rectangle keyboardRect = new Rectangle(100, 180, 220, 241);
        Rectangle guitarRect = new Rectangle(750, 180, 220, 241);
        Rectangle drumRect = new Rectangle(550, 180, 220, 241);
        Rectangle vocalRect = new Rectangle(320, 180, 220, 241);

        //rect for instruments
        Rectangle keyboardInRect = new Rectangle(100, 180, 60, 60);
        Rectangle guitarInRect = new Rectangle(750, 180, 60, 60);
        Rectangle drumInRect = new Rectangle(550, 180, 60, 60);
        Rectangle vocalInRect = new Rectangle(320, 180, 60, 60);
      


        //bool is dragging instruments
        bool isDraggingKeyboard, isDraggingGuitar, isDraggingDrum,isDraggingVocal;

        //mousestate
        MouseState currentMouseState, previousMouseState;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            _graphics.PreferredBackBufferHeight = 600;
            _graphics.PreferredBackBufferWidth = 1079;
            _graphics.ApplyChanges();

            //instruemnt dragging
            isDraggingKeyboard = false;
            isDraggingGuitar = false;
            isDraggingDrum = false;
            isDraggingVocal = false;

            base.Initialize();

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

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
           
            //load images
            backgroundTexture = Content.Load<Texture2D>("Background");
            
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

            //Load Charaters
            drumTexture = Content.Load<Texture2D>("Charater/drum/drumNormal");
            guitarTexture = Content.Load<Texture2D>("Charater/guitar/guitarNormal");
            keyboardTexture = Content.Load<Texture2D>("Charater/keyboard/keyNormal");
            vocalTexture = Content.Load<Texture2D>("Charater/vocal/vocalNormal");
            //Load Dance Charaters
            drumDanceTexture = Content.Load<Texture2D>("Charater/drum/drumDance");
            guitarDanceTexture = Content.Load<Texture2D>("Charater/guitar/guitarDance");
            keyboardDanceTexture = Content.Load<Texture2D>("Charater/keyboard/keyDance");
            vocalDanceTexture = Content.Load<Texture2D>("Charater/vocal/vocalDance");

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
            //exit when esc is pressed
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //Dragging the instruments anywhere
            if (NewClick() && guitarInRect.Contains(currentMouseState.Position))
            {
                isDraggingGuitar = true;
                this.Window.Title = "clicked";
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

            if (guitarInRect.Intersects(guitarRect)) 
                guitar1Instance.Volume = 1f;
            else if (guitarInRect.Intersects(keyboardRect))
                guitar2Instance.Volume = 1f;
            else if (guitarInRect.Intersects(vocalRect))
                guitar3Instance.Volume = 1f;
            else if (guitarInRect.Intersects(drumRect))
                guitar4Instance.Volume = 1f;

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
            if (vocalInRect.Intersects(guitarRect))
                vocal1Instance.Volume = 1f;
            else if (vocalInRect.Intersects(keyboardRect))
                vocal2Instance.Volume = 1f;
            else if (vocalInRect.Intersects(vocalRect))
                vocal3Instance.Volume = 1f;
            else if (vocalInRect.Intersects(drumRect))
                vocal4Instance.Volume = 1f;

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
            if (drumInRect.Intersects(guitarRect))
                drum1Instance.Volume = 1f;
            else if (drumInRect.Intersects(keyboardRect))
                drum2Instance.Volume = 1f;
            else if (drumInRect.Intersects(vocalRect))
                drum3Instance.Volume = 1f;
            else if (drumInRect.Intersects(drumRect))
                drum4Instance.Volume = 1f;

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
            if (keyboardInRect.Intersects(guitarRect))
                keyboard1Instance.Volume = 1f;
            else if (keyboardInRect.Intersects(keyboardRect))
                keyboard2Instance.Volume = 1f;
            else if (keyboardInRect.Intersects(vocalRect))
                keyboard3Instance.Volume = 1f;
            else if (keyboardInRect.Intersects(drumRect))
                keyboard4Instance.Volume = 1f;
          
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

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            SpriteBatch spriteBatch = new SpriteBatch(GraphicsDevice);

            _spriteBatch.Begin();
            _spriteBatch.Draw(backgroundTexture, new Rectangle(0, 0, 1079, 600), Color.White);

            //load random song to play and test

            //vocal4Instance.Play();
            //drum3Instance.Play();

            //load the band members
            _spriteBatch.Draw(vocalTexture, vocalRect, Color.White);
            _spriteBatch.Draw(guitarTexture, guitarRect, Color.White);
            _spriteBatch.Draw(drumTexture, drumRect, Color.White);
            _spriteBatch.Draw(keyboardTexture, keyboardRect, Color.White);

            //load insturments
            _spriteBatch.Draw(vocal, vocalInRect, Color.White);
            _spriteBatch.Draw(guitar, guitarInRect, Color.White);
            _spriteBatch.Draw(drum, drumInRect, Color.White);
            _spriteBatch.Draw(keyboard, keyboardInRect, Color.White);
            
            // TODO: Add your drawing code here

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
