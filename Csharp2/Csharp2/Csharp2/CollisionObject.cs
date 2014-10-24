using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Csharp2
{
    class CollisionObject
    {
        protected int height;
        protected int width;
        protected Rectangle location;

        public int Width
        {
            get { return width; }
        }

        public Rectangle Location
        {
            get { return location; }
        }

        public CollisionObject()
        {
            CollisionObjects.add(this);
        }
    }
}
