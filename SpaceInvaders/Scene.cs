using SpaceInvaders.GameObjectFactories;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SpaceInvaders
{
    class Scene
    {
        public List<GameObject> alien;

        public List<GameObject> ground;

        public GameObject playerShip;

        public List<GameObject> playerRocket;

        GameSettings _gameSettings;

        private static Scene _scene;

        private Scene()
        {

        }
        private Scene(GameSettings gameSettings)
        {
            _gameSettings = gameSettings;
            playerShip = new PlayerShipFactory(_gameSettings).GetGameObject();
            playerRocket = new List<GameObject>();
            alien = new SwarmShipFactory(_gameSettings).GetAlien();
            ground = new GroundFactory(_gameSettings).GetGround();

        }
        public static Scene GetScene(GameSettings gameSettings)
        {
            if(_scene == null)
            {
                _scene = new Scene(gameSettings);
            }

            return _scene;
        }

    }
}
