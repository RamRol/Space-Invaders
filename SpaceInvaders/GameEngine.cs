using SpaceInvaders.GameObjectFactories;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

namespace SpaceInvaders
{
    class GameEngine
    {
        private bool _isNotOver;

        private static GameEngine _gameEngine;

        private GameSettings _gameSettings;

        private SceneRender _sceneRender;

        private Scene _scene;

        private int score = 0;

 

        public static GameEngine GetGameEngine(GameSettings gameSettings)
        {
            if(_gameEngine == null )
            {
                _gameEngine = new GameEngine(gameSettings);

            }
            return _gameEngine;
        }

        private GameEngine(GameSettings gameSettings)
        {
            _gameSettings = gameSettings;
            _isNotOver = true;
            _scene = Scene.GetScene(gameSettings);
            _sceneRender = new SceneRender(gameSettings);
        }

        public void Run()
        {
            int alienMoveCounter = 0;
            int playerRocketCounter = 0;
            do
            {
                _sceneRender.Render(_scene);

                Thread.Sleep(_gameSettings.GameSpeed);

                _sceneRender.EmptyScreen();



                if (alienMoveCounter == _gameSettings.AlienSpeed)
                {
                    CalculateAlienMove();
                    alienMoveCounter = 0;
                }
                alienMoveCounter++;

                if (playerRocketCounter == _gameSettings.PlayerRocketSPeed)
                {
                    CalculateMissileMove();
                    playerRocketCounter = 0;
                }
                playerRocketCounter++;

            } while (_isNotOver);
                Console.ForegroundColor = ConsoleColor.Red;
                _sceneRender.RenderGameOver();
        }

        public void CalculcatePlayerShipMoveLeft()
        {
            if (_scene.playerShip.GameObjectCoords.XCoord > 1)
            {
                _scene.playerShip.GameObjectCoords.XCoord--;
            }
        }

        public void CalculcatePlayerShipMoveRight()
        {
            if (_scene.playerShip.GameObjectCoords.XCoord < _gameSettings.ConsoleWidth)
            {
                _scene.playerShip.GameObjectCoords.XCoord++;
            }
        }

        public void CalculateAlienMove()
        {
            for (int i = 0; i < _scene.alien.Count; i++)
            {
                GameObject alienShip = _scene.alien[i];

                alienShip.GameObjectCoords.YCoord++;

                if (alienShip.GameObjectCoords.YCoord == _scene.playerShip.GameObjectCoords.YCoord)
                {
                    _isNotOver = false;
                }


            }
        }

        public void Shoot()
        {
            PlayerShootFactory rocketFactory = new PlayerShootFactory(_gameSettings);

            GameObject rocket = rocketFactory.GetGameObject(_scene.playerShip.GameObjectCoords);

            _scene.playerRocket.Add(rocket);

            Console.Beep(1000, 300);

        }

        public void CalculateMissileMove()
        {
            if(_scene.playerRocket.Count == 0 )
            {
                return;
            }

            for(int i=0;i < _scene.playerRocket.Count; i++)
            {
                GameObject rocket = _scene.playerRocket[i];
                if(rocket.GameObjectCoords.YCoord == 1)
                {
                    _scene.playerRocket.RemoveAt(i);
                }

                rocket.GameObjectCoords.YCoord--;
                for(int j = 0; j < _scene.alien.Count; j++ )
                {
                    GameObject alienShip = _scene.alien[j];
                    if(rocket.GameObjectCoords.Equals(alienShip.GameObjectCoords))
                    {
                        score++;
                        _scene.alien.RemoveAt(j);
                        _scene.playerRocket.RemoveAt(i);
                        _sceneRender.RenderPlayerScore(score, _gameSettings.ScoreStartYCoord, _gameSettings.ScoreStartXCoord);

                        break;
                    }
                }
            }

        }


    }
}
