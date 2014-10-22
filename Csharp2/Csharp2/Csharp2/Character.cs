using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Csharp2
{
    abstract class Character : CollisionObject
    {
        private int frameCounter;
        private int switchFrame = 100;
        protected int currentFrame = 0;
        private Rectangle sourceRect;

        protected GraphicsDeviceManager graphics;

        protected int health;
        protected int velocity;
        protected int initialVelocity;

        protected bool facingLeft = false;
        protected Animation currentAnimation = null;
        protected Dictionary<string, Animation> animations = new Dictionary<string, Animation>();

        protected Character(GraphicsDeviceManager graphics)
        {
            addAnimations();

            this.graphics = graphics;
            this.velocity = initialVelocity;
        }

        public void load(ContentManager content)
        {
            foreach(Animation animation in animations.Values)
            {
                animation.Texture = content.Load<Texture2D>("Characters//"+ this.GetType().Name +"//" + animation.SpriteSheet);
            }
        }

        public void draw(SpriteBatch spriteBatch)
        {
            if(facingLeft)
            {
                spriteBatch.Draw(currentAnimation.Texture, location, sourceRect, Color.White, 0f, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0f);
            }
            else
            {
                spriteBatch.Draw(currentAnimation.Texture, location, sourceRect, Color.White, 0f, new Vector2(0, 0), SpriteEffects.None, 0f);
            }
        }


        public void update(GameTime gameTime, List<CharAction> pressedActions)
        {
            frameCounter += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            
            determineAnimation(pressedActions);

            if(frameCounter >= switchFrame)
            {
                frameCounter = 0;

                currentFrame++;
                if (currentFrame >= currentAnimation.NumberOfFrames)
                {
                    currentFrame = 0;
                }
            }

            if (currentAnimation == animations["walk"])
            {
                location.X += velocity;
                
                if(!walkCollision())
                {
                    if(location.X < 0)
                    {
                        location.X = 0;
                    }
                    else if(location.X+currentAnimation.SpriteWidth > graphics.PreferredBackBufferWidth)
                    {
                        location.X = graphics.PreferredBackBufferWidth - currentAnimation.SpriteWidth;
                    }
                }
            }

            sourceRect = new Rectangle(currentFrame*currentAnimation.SpriteWidth, 0, currentAnimation.SpriteWidth, 82);
        }

        private bool walkCollision()
        {
            List<CollisionObject> collisionList = CollisionObjects.getList();
            bool collision = false;

            foreach(CollisionObject collisionObject in collisionList)
            {
                if(collisionObject != this)
                {
                    if(location.Intersects(collisionObject.Location))
                    {
                        collision = true;
                        if(velocity > 0)
                        {
                            location.X = collisionObject.Location.X - currentAnimation.SpriteWidth;
                        }
                        else
                        {
                            location.X = collisionObject.Location.X + currentAnimation.SpriteWidth;
                        }
                    }
                }
            }

            return collision;
        }

        public void setLocation(Point location)
        {
            this.location = new Rectangle(location.X, location.Y, width, height);
        }

        public void setFacingDirection(bool facingLeft)
        {
            this.facingLeft = facingLeft;
        }

        protected abstract void addAnimations();
        protected abstract void determineAnimation(List<CharAction> pressedActions);

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