using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Csharp2
{
    static class CollisionObjects
    {
        private static List<CollisionObject> collisionObjects = new List<CollisionObject>();

        public static List<CollisionObject> getList()
        {
            return collisionObjects;
        }

        public static void add(CollisionObject collisionObject)
        {
            collisionObjects.Add(collisionObject);
        }
    }
}
