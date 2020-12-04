using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceInvaders.GameObjectFactories
{
    class PlayerShipFactory : GameObjectFactory
    {
        public PlayerShipFactory (GameSettings gameSettings)
            :base(gameSettings)
        {

        }


        public override GameObject GetGameObject(GameObjectCoords objectCoords)
        {
            GameObject gameObject = new PlayerShip() { Shape = GameSettings.PlayerShip, GameObjectCoords = objectCoords, GameObjectType = GameObjectType.PlayerShip };

            return gameObject;
        }
        public GameObject GetGameObject()
        {
            GameObjectCoords Coords = new GameObjectCoords() { XCoord = GameSettings.PlayerShipStartXCoord, YCoord = GameSettings.PlayerShipStartYCoord };
            GameObject gameObject = GetGameObject(Coords);
            return gameObject;

        }
    }
}
