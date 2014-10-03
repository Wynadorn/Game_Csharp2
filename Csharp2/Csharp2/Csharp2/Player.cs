using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Csharp2.Characters;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Csharp2
{
    class Player : Character
    {
        public Player(Vector2 location, Model model)
        {
            this.location = location;
            this.model = model;
        }
    }
}