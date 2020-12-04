using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceInvaders.GameObjectFactories
{
    class SwarmShipFactory : GameObjectFactory
    {
        public SwarmShipFactory(GameSettings gameSettings)
            : base(gameSettings)
        {

        }


        public override GameObject GetGameObject(GameObjectCoords objectCoords)
        {
            GameObject alienShip = new SwarmShip() { Shape = GameSettings.AlienShip, GameObjectCoords = objectCoords, GameObjectType = GameObjectType.SwarmShip };

            return alienShip;
        }

        public List<GameObject> GetAlien()
        {
            List<GameObject> alien = new List<GameObject>();

            int startX = GameSettings.AlienStartXCoord;

            int startY = GameSettings.AlienStartYCoord;

            for(int y = 0; y<GameSettings.NumberOfAlienRows; y++)
            {
                for(int x = 0; x<GameSettings.NumberOfAlienColls;x++)
                {
                    GameObjectCoords objectCoords = new GameObjectCoords() { XCoord = startX + x, YCoord = startY + y };
                    GameObject alienShip = GetGameObject(objectCoords);
                    alien.Add(alienShip);
                }
            }
            return alien;
        }
    }
}
