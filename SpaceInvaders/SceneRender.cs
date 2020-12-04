using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceInvaders
{
    class SceneRender
    {
        int _scoreStartXCoord;

        int _scoreStartYCoord;

        int _playerScore = 0;

        int _screenWidth;

        int _ScreenHeight;

        char[,] _screenMatrix;

        public SceneRender(GameSettings gameSettings)
        {
            _screenWidth = gameSettings.ConsoleWidth;
            _ScreenHeight = gameSettings.ConsoleHight;
            _screenMatrix = new char[gameSettings.ConsoleHight, gameSettings.ConsoleWidth];
            _scoreStartXCoord = gameSettings.ScoreStartXCoord;
            _scoreStartYCoord = gameSettings.ScoreStartYCoord;

            Console.WindowHeight = gameSettings.ConsoleHight;
            Console.WindowWidth = gameSettings.ConsoleWidth;


            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
        }

        public void Render(Scene scene)
        {

            AddListForRendering(scene.alien);
            AddListForRendering(scene.ground);
            AddListForRendering(scene.playerRocket);


            AddGameObjectForRendering(scene.playerShip);


            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < _playerScore.ToString().Length; i++)
            {
                _screenMatrix[_scoreStartYCoord, _scoreStartXCoord + (i + 1)] = _playerScore.ToString()[i];
            }

            for (int y = 0; y < _ScreenHeight; y++)
            {
                for(int x = 0; x <_screenWidth; x++)
                {
                    stringBuilder.Append(_screenMatrix[y, x]);
                }
                stringBuilder.Append(Environment.NewLine);

            }

            Console.WriteLine(stringBuilder.ToString());
            Console.SetCursorPosition(0, 0);
        }

        public void AddGameObjectForRendering(GameObject gameObject)
        {
            if(gameObject.GameObjectCoords.YCoord < _screenMatrix.GetLength(0) &&
                gameObject.GameObjectCoords.XCoord < _screenMatrix.GetLength(1))
            {
                _screenMatrix[gameObject.GameObjectCoords.YCoord, gameObject.GameObjectCoords.XCoord] = gameObject.Shape;
            }
        }

        public void AddListForRendering(List<GameObject> gameObjects)
        {
            foreach(GameObject gameObject in gameObjects)
            {
                AddGameObjectForRendering(gameObject);
            }
        }

        public void EmptyScreen()
        {
            for (int y = 0; y < _ScreenHeight; y++)
            {
                for (int x = 0; x < _screenWidth; x++)
                {
                    _screenMatrix[y, x] = ' ';
                }

            }

        }
        public void RenderGameOver()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("Game Over!!!!!!");

            Console.WriteLine(stringBuilder.ToString());
        }

        public void RenderPlayerScore(int playerScore, int scoreYCoord, int scoreXCoord)
        {
            _playerScore = playerScore;
            _scoreStartXCoord = scoreXCoord;
            _scoreStartYCoord = scoreYCoord;
        }

        public void RenderGameWon()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("Game won!!!");

            Console.WriteLine(stringBuilder.ToString());
        }


    }
}
