using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace Csharp2.Characters
{
    class Ryu : Character
    {
        

        #region Constructors
        public Ryu()
        {
            Initialize(new Vector2(0, 0));
        }

        public Ryu(Vector2 location)
        {
            Initialize(location);
        }
        #endregion

        private void Initialize(Vector2 location)
        {
            addAnimations();
            
            this.health = 100;
            this.location = location;
        }

        private void addAnimations()
        {
            animations.Add("idle", new Animation("idle", 4, 43, 0.15f));
            animations.Add("walk", new Animation("walk", 5, 43, 0.15f));
        }
    }
}