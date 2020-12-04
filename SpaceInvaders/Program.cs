using System;
using System.Threading;

namespace SpaceInvaders
{
    class Program
    {
        static GameEngine gameEngine;

        static GameSettings gameSettings;

        static UIController uIController;

        static MusicController musicController;

        static void Main(string[] args)
        {
            Initialize();

            gameEngine.Run();
        }

        public static void Initialize()
        {
            gameSettings = new GameSettings();

            gameEngine = GameEngine.GetGameEngine(gameSettings);

            uIController = new UIController();

            uIController.OnAPress += (obj, arg) => gameEngine.CalculcatePlayerShipMoveLeft();

            uIController.OnDPress += (obj, arg) => gameEngine.CalculcatePlayerShipMoveRight();

            uIController.OnSpacePress += (obj, arg) => gameEngine.Shoot();


            Thread uIthread = new Thread(uIController.StartListning);

            uIthread.Start();

            musicController = new MusicController();
            Thread musicThread = new Thread(musicController.PlayBackgroundMusic);
            musicThread.Start();

            Thread.CurrentThread.Priority = ThreadPriority.AboveNormal;

        }
    }
}
