using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Csharp2.Characters;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace Csharp2
{
    class Player : Controller
    {
        public Player(Character character) : base(character)
        {
            character.setLocation(new Point(60, 138));
            character.setFacingDirection(false);
        }

        protected override void setKeybinds()
        {
            keyBinds.Add(CharAction.Left, Keys.A);
            keyBinds.Add(CharAction.Right, Keys.D);
            keyBinds.Add(CharAction.Down, Keys.S);
        }
    }
}