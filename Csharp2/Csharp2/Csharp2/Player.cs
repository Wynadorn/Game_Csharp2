﻿using System;
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
    class Player
    {
        Character character;
        KeyboardState oldState;
        List<CharAction> pressedActions = new List<CharAction>();

        public Player(Character character)
        {
            this.character = character;

            character.setLocation(new Point(60, 138));
            character.setFacingDirection(false);

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
            keyBinds.Add(CharAction.Left, Keys.A);
            keyBinds.Add(CharAction.Right, Keys.D);
            keyBinds.Add(CharAction.Down, Keys.S);
            

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