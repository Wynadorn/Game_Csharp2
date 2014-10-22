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
    class Computer
    {
        Character character;
        KeyboardState oldState;
        List<CharAction> pressedActions = new List<CharAction>();

        public Computer(Character character)
        {
            this.character = character;
            character.setLocation(new Point(518, 138));
            character.setFacingDirection(true);

            oldState = Keyboard.GetState();
        }

        public void load(ContentManager content)
        {
            character.load(content);
        }

        public void update(GameTime gameTime)
        {
            updateInput();
            character.update(gameTime, pressedActions);
        }

        public void updateInput()
        {
            //pressedActions.Clear();
            KeyboardState newState = Keyboard.GetState();

            Dictionary<CharAction, Keys> keyBinds = new Dictionary<CharAction, Keys>();
            keyBinds.Add(CharAction.Left, Keys.Left);
            keyBinds.Add(CharAction.Right, Keys.Right);
            keyBinds.Add(CharAction.Down, Keys.Down);
            

            if(newState.IsKeyDown(keyBinds[CharAction.Left]))
            {
                if(!oldState.IsKeyDown(keyBinds[CharAction.Left])) //Left was pressed
                {
                    pressedActions.Add(CharAction.Left);
                }
            }
            else if (oldState.IsKeyDown(keyBinds[CharAction.Left])) //Left was released
            {
                pressedActions.Remove(CharAction.Left);
            }

            if (newState.IsKeyDown(keyBinds[CharAction.Right]))
            {
                if (!oldState.IsKeyDown(keyBinds[CharAction.Right])) //Left was pressed
                {
                    pressedActions.Add(CharAction.Right);
                }
            }
            else if (oldState.IsKeyDown(keyBinds[CharAction.Right])) //Left was released
            {
                pressedActions.Remove(CharAction.Right);
            }

            if (newState.IsKeyDown(keyBinds[CharAction.Down]))
            {
                if (!oldState.IsKeyDown(keyBinds[CharAction.Down])) //Left was pressed
                {
                    pressedActions.Add(CharAction.Down);
                }
            }
            else if (oldState.IsKeyDown(keyBinds[CharAction.Down])) //Left was released
            {
                pressedActions.Remove(CharAction.Down);
            }

            oldState = newState;
        }

        public void draw(SpriteBatch spriteBatch)
        {
            character.draw(spriteBatch);
        }
    }
}