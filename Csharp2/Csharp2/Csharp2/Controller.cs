using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Csharp2
{
    abstract class Controller
    {
        private KeyboardState oldState;
        private List<CharAction> pressedActions;

        protected Character character;
        protected Dictionary<CharAction, Keys> keyBinds;

        protected Controller(Character character)
        {
            this.character = character;

            oldState = Keyboard.GetState();
            pressedActions = new List<CharAction>();
            keyBinds = new Dictionary<CharAction, Keys>();

            setKeybinds();
        }

        private void updateInput()
        {
            KeyboardState newState = Keyboard.GetState();

            foreach(KeyValuePair<CharAction, Keys> KVP in keyBinds)
            {
                if(newState.IsKeyDown(KVP.Value))
                {
                    if(!oldState.IsKeyDown(KVP.Value)) //Left was pressed
                    {
                        pressedActions.Add(KVP.Key);
                    }
                }
                else if (oldState.IsKeyDown(KVP.Value)) //Left was released
                {
                    pressedActions.Remove(KVP.Key);
                }
            }
            oldState = newState;
        }

        protected abstract void setKeybinds();

        public void draw(SpriteBatch spriteBatch)
        {
            character.draw(spriteBatch);
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
    }
}
