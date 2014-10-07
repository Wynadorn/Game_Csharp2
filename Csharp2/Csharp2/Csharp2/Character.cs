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
        protected Dictionary<string, Animation> animations = new Dictionary<string, Animation>();
        protected Vector2 location;
        
        int frameCounter;
        int switchFrame = 100;
        int currentFrame = 0;

        bool performingAnimation = false;

        public void load(ContentManager content)
        {
            foreach(Animation animation in animations.Values)
            {
                animation.Texture = content.Load<Texture2D>("Characters//"+ this.GetType().Name +"//" + animation.SpriteSheet);
            }
        }

        public void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(animations["idle"].Texture, location, Color.White);
        }


        public void update(GameTime gameTime)
        {
            frameCounter += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            if(frameCounter >= switchFrame)
            {
                frameCounter = 0;

                if(performingAnimation)
                {

                }
                //Perform idle animation
                else
                {
                    //determine which animation should be preformed
                }

                currentFrame++;
                if (currentFrame >= 4)
                {
                    currentFrame = 0;
                }
            }
        }

        protected abstract void addAnimations();

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