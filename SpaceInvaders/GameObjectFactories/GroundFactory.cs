using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceInvaders.GameObjectFactories
{
    class GroundFactory : GameObjectFactory
    {
        public GroundFactory(GameSettings gameSettings)
           : base(gameSettings)
        {

        }


        public override GameObject GetGameObject(GameObjectCoords objectCoords)
        {
            GameObject groundObject = new GroundObject() { Shape = GameSettings.Ground, GameObjectCoords = objectCoords, GameObjectType = GameObjectType.GroundObject };

            return groundObject;
        }

        public List<GameObject> GetGround()
        {
            List<GameObject> ground = new List<GameObject>();

            int startX = GameSettings.GroundStartXCoord;

            int startY = GameSettings.GroundStartYCoord;

            for (int y = 0; y < GameSettings.NumberOfGroundRows; y++)
            {
                for (int x = 0; x < GameSettings.NumberOfGroundColls; x++)
                {
                    GameObjectCoords objectCoords = new GameObjectCoords() { XCoord = startX + x, YCoord = startY + y };
                    GameObject groundObj = GetGameObject(objectCoords);
                    ground.Add(groundObj);
                }
            }
            return ground;
        }
    }
}
