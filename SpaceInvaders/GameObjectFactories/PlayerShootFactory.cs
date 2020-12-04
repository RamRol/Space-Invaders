using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceInvaders.GameObjectFactories
{
    class PlayerShootFactory : GameObjectFactory
    {
        public PlayerShootFactory(GameSettings gameSettings)
            :base(gameSettings)
        {

        }
        public override GameObject GetGameObject(GameObjectCoords objectCoords)
        {
            GameObjectCoords rocketCoords = new GameObjectCoords() { XCoord = objectCoords.XCoord, YCoord = objectCoords.YCoord - 1 };
            GameObject rocket = new PlayerRocket() { Shape = GameSettings.PlayerRocket, GameObjectCoords = rocketCoords, GameObjectType = GameObjectType.PlayerRocket };

            return rocket;
        }
    }
}
