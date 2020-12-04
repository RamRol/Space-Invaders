using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SpaceInvaders
{
    class GameObjectCoords
    {
        public int XCoord { get; set; }

        public int YCoord { get; set; }


        public override bool Equals(object obj)
        {
            GameObjectCoords newObj = obj as GameObjectCoords;
            if (newObj != null &&
                this.XCoord == newObj.XCoord &&
                this.YCoord == newObj.YCoord)
            {
                return true;
            }
            return false;
        }


        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
