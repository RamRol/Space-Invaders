using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceInvaders.GameObjectFactories
{
    abstract class GameObjectFactory
    {
        public GameSettings GameSettings { get; set; }

        public abstract GameObject GetGameObject(GameObjectCoords objectCoords);

        public GameObjectFactory(GameSettings gameSettings)
        {
            GameSettings = gameSettings;
        }
    }
}
