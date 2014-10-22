using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace Csharp2.Characters
{
    class Ken : Character
    {
        public Ken(GraphicsDeviceManager graphics) : base(graphics)
        {
            this.health = 100;
            this.width = 43;
            this.height = 82;
            this.initialVelocity = 2;
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

            if (pressedActions.Contains(CharAction.Down))
            {
                currentAnimation = animations["crouch"];
            }
            else if (pressedActions.Contains(CharAction.Left) && !pressedActions.Contains(CharAction.Right))
            {
                //Current animation is walk left
                currentAnimation = animations["walk"];
                facingLeft = true;
                this.velocity = initialVelocity * -1;

            }
            else if (!pressedActions.Contains(CharAction.Left) && pressedActions.Contains(CharAction.Right))
            {
                currentAnimation = animations["walk"];
                facingLeft = false;
                this.velocity = initialVelocity;
            }
            else
            {
                currentAnimation = animations["idle"];
            }

            if (oldAnimation != currentAnimation)
            {
                currentFrame = 0;
            }
        }
    }
}