using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Graphics;

namespace Csharp2
{
    class Animation
    {
        private string spriteSheet;
        private int numberOfFrames;
        private int spriteWidth;
        private float updateSpeed;
        private Texture2D texture;

        public Texture2D Texture
        {
            get
            {
                return texture;
            }
            set
            {
                texture = value;
            }
        }

        public string SpriteSheet
        {
            get{ return spriteSheet; }
        }

        public int SpriteWidth
        {
            get{ return spriteWidth; }
        }

        public int NumberOfFrames
        {
            get { return numberOfFrames; }
        }

        public Animation(string spriteSheet, int numberOfFrames, int spriteWidth, float updateSpeed)
        {
            this.spriteSheet = spriteSheet;
            this.numberOfFrames = numberOfFrames;
            this.spriteWidth = spriteWidth;
            this.updateSpeed = updateSpeed;
        }
    }
}