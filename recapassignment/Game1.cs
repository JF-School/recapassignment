using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace recapassignment
{
    public class Game1 : Game
    {
        List<Texture2D> poutineTextures = new List<Texture2D>();
        Random generator = new Random();
        Texture2D backgroundTexture, poutineTexture1, poutineTexture2, poutineTexture3, poutineTexture4;
        Rectangle backgroundRect, poutineRect1, poutineRect2, poutineRect3, poutineRect4, window;
        SpriteFont drippyFont;

        MouseState mouseState, prevMouseState;

        int poutineIndex;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            window = new Rectangle(0, 0, 800, 500);

            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();

            backgroundRect = new Rectangle(0, 0, window.Width, window.Height);
            poutineRect1 = new Rectangle(200, 150, 125, 125);
            poutineRect2 = new Rectangle(60, 220, 200, 200);
            poutineRect3 = new Rectangle(440, 150, 125, 125);
            poutineRect4 = new Rectangle(500, 220, 200, 200);


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            backgroundTexture = Content.Load<Texture2D>("Images/battleground");
            drippyFont = Content.Load<SpriteFont>("Fonts/DrippyFont");
            for (int i = 1; i <= 5; i++)
                poutineTextures.Add(Content.Load<Texture2D>($"Images/poutine_{i}"));

            poutineIndex = generator.Next(poutineTextures.Count);
            poutineTexture1 = poutineTextures[poutineIndex];
            poutineTextures.RemoveAt(poutineIndex);

            poutineIndex = generator.Next(poutineTextures.Count);
            poutineTexture2 = poutineTextures[poutineIndex];
            poutineTextures.RemoveAt(poutineIndex);

            poutineIndex = generator.Next(poutineTextures.Count);
            poutineTexture3 = poutineTextures[poutineIndex];
            poutineTextures.RemoveAt(poutineIndex);

            poutineIndex = generator.Next(poutineTextures.Count);
            poutineTexture4 = poutineTextures[poutineIndex];
            poutineTextures.RemoveAt(poutineIndex);

        }

        protected override void Update(GameTime gameTime)
        {
            prevMouseState = mouseState;
            mouseState = Mouse.GetState();

            //this.Window.Title = $"x = {mouseState.X}, y = {mouseState.Y}";
            Window.Title = "What's happening here?";


            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();
            _spriteBatch.Draw(backgroundTexture, backgroundRect, Color.White);
            _spriteBatch.DrawString(drippyFont, "POUTINE BATTLE", new Vector2(50, 5), Color.Black);
            _spriteBatch.Draw(poutineTexture1, poutineRect1, Color.White);
            _spriteBatch.Draw(poutineTexture2, poutineRect2, Color.White);
            _spriteBatch.Draw(poutineTexture3, poutineRect3, Color.White);
            _spriteBatch.Draw(poutineTexture4, poutineRect4, Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
