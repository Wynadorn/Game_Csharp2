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
    class Computer : Controller
    {
        public Computer(Character character) : base(character)
        {
            character.setLocation(new Point(518, 138));
            character.setFacingDirection(true);
        }

        protected override void setKeybinds()
        {
            keyBinds.Add(CharAction.Left, Keys.Left);
            keyBinds.Add(CharAction.Right, Keys.Right);
            keyBinds.Add(CharAction.Down, Keys.Down);
        }

        //public override void updateInput()
        //{
        //    //pressedActions.Clear();
        //    //if(newState.IsKeyDown(keyBinds[CharAction.Left]))
        //    //{
        //    //    if(!oldState.IsKeyDown(keyBinds[CharAction.Left])) //Left was pressed
        //    //    {
        //    //        pressedActions.Add(CharAction.Left);
        //    //    }
        //    //}
        //    //else if (oldState.IsKeyDown(keyBinds[CharAction.Left])) //Left was released
        //    //{
        //    //    pressedActions.Remove(CharAction.Left);
        //    //}

        //    //if (newState.IsKeyDown(keyBinds[CharAction.Right]))
        //    //{
        //    //    if (!oldState.IsKeyDown(keyBinds[CharAction.Right])) //Left was pressed
        //    //    {
        //    //        pressedActions.Add(CharAction.Right);
        //    //    }
        //    //}
        //    //else if (oldState.IsKeyDown(keyBinds[CharAction.Right])) //Left was released
        //    //{
        //    //    pressedActions.Remove(CharAction.Right);
        //    //}

        //    //if (newState.IsKeyDown(keyBinds[CharAction.Down]))
        //    //{
        //    //    if (!oldState.IsKeyDown(keyBinds[CharAction.Down])) //Left was pressed
        //    //    {
        //    //        pressedActions.Add(CharAction.Down);
        //    //    }
        //    //}
        //    //else if (oldState.IsKeyDown(keyBinds[CharAction.Down])) //Left was released
        //    //{
        //    //    pressedActions.Remove(CharAction.Down);
        //    //}
        //}
    }
}