using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace Csharp2.Characters
{
    class Ryu : Character
    {
        public Ryu(GraphicsDeviceManager graphics)
        {
            addAnimations();

            this.graphics = graphics;

            this.health = 100;
            this.width = 43;
            this.height = 82;
            this.speed = 2;
        }

        protected override void addAnimations()
        {
            animations.Add("idle", new Animation("idle", 4, 43, 0.15f));
            animations.Add("walk", new Animation("walk", 5, 43, 0.15f));
            animations.Add("crouch", new Animation("crouch", 1, 43, 0.15f));
        }

        protected override void determineAnimation(List<CharAction> pressedActions)
        {
            Animation oldAnimation = currentAnimation;

            if(pressedActions.Contains(CharAction.Down))
            {
                currentAnimation = animations["crouch"];
            }
            else if(pressedActions.Contains(CharAction.Left) && !pressedActions.Contains(CharAction.Right))
            {
                //Current animation is walk left
                currentAnimation = animations["walk"];
                facingLeft = true;

            }
            else if(!pressedActions.Contains(CharAction.Left) && pressedActions.Contains(CharAction.Right))
            {
                currentAnimation = animations["walk"];
                facingLeft = false;
            }
            else
            {
                currentAnimation = animations["idle"];
            }

            if(oldAnimation != currentAnimation)
            {
                currentFrame = 0;
            }
        }
    }
}