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

            base.Initialize();
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
            
            drumDanceTexture = Content.Load<Texture2D>("Charater/drum/drumDance");
            guitarDanceTexture = Content.Load<Texture2D>("Charater/guitar/guitarDance");
            keyboardDanceTexture = Content.Load<Texture2D>("Charater/keyboard/keyDance");
            vocalDanceTexture = Content.Load<Texture2D>("Charater/vocal/vocalDance");
            

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

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
            vocal1Instance.Play();
            guitar2Instance.Play();
            drum3Instance.Play();
            keyboard4Instance.Play();

            //load the band members

            _spriteBatch.Draw(drumTexture, new Vector2(100, 0), Color.White);
            _spriteBatch.Draw(guitarTexture, new Vector2(200, 0), Color.White);
            _spriteBatch.Draw(keyboardTexture, new Vector2(300, 0), Color.White);
            _spriteBatch.Draw(vocalTexture, new Vector2(400, 0), Color.White);

            _spriteBatch.End();


            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
