using System;
using System.Collections.Generic;
using System.Linq;

using Csharp2.Characters;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Csharp2
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D backgroundTexture;

        Character player; 

        public Game()
        {
            player = new Ryu(new Vector2(30,138));

            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            //Set the window height
            graphics.PreferredBackBufferHeight = 240;
            graphics.PreferredBackBufferWidth = 621;

            //Set the window title
            Window.Title = "Fighter 2";
            
            //this.graphics.IsFullScreen = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            backgroundTexture = Content.Load<Texture2D>("stages//fraserbalacastle");

            player.load(Content);
        }

        protected override void UnloadContent()
        {
            
        }

        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                //this.Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);

            player.update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();


            Rectangle screenRectangle = new Rectangle(0, 0, 621, 240);
            spriteBatch.Draw(backgroundTexture, screenRectangle, Color.White);

            player.draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}