using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Csharp2
{
    abstract class Character
    {
        protected int health;
        protected Vector2 location;
        protected Model model;
        protected Texture2D x;

        public void load(ContentManager content)
        {
            x = content.Load<Texture2D>("Characters//Ryu//Idle");
        }

        public void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(x, location, Color.White);
        }

        public void update(GameTime gameTime)
        {

        }

        #region Movement
        protected void walkLeft()
        { }

        protected void walkRight()
        { }

        protected void jump()
        { }
        #endregion

        #region Attacks
        protected void lowPunch()
        { }

        protected void highPunch()
        { }

        protected void lowKick()
        { }

        protected void highKick()
        { }
        #endregion
    }
}
