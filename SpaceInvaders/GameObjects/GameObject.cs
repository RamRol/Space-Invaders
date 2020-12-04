using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceInvaders
{
    abstract class GameObject
    {
        public GameObjectCoords GameObjectCoords { get; set; }

        public char Shape { get; set; }

        public GameObjectType GameObjectType { get; set; }


    }
}
