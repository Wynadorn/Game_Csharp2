using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Csharp2.Characters;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Csharp2
{
    class Player
    {
        Character character;

        public Player(Character character)
        {
            this.character = character;
        }

        public void load(ContentManager content)
        {
            character.load(content);
        }

        public void update(GameTime gameTime)
        {
            if(Control)
            character.update(gameTime);
        }

        public void draw(SpriteBatch spriteBatch)
        {
            character.draw(spriteBatch);
        }
    }
}