using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceInvaders
{
    class GameSettings
    {

        public int ConsoleWidth { get; set; } = 100;

        public int ConsoleHight { get; set; } = 50;

        // console settings
    
        public int PlayerShipStartXCoord { get; set; } = 35;

        public int PlayerShipStartYCoord{ get; set; } = 19;

        public char PlayerShip { get; set; } = '^';

        // player settings

        public int GroundStartXCoord { get; set; } = 1;

        public int GroundStartYCoord { get; set; } = 20;

        public char Ground { get; set; } = '=';

        public int NumberOfGroundRows { get; set; } = 3;

        public int NumberOfGroundColls { get; set; } = 100;

        // ground settings

        public char PlayerRocket { get; set; } = 'A';

        public int PlayerRocketSPeed { get; set; } = 5;

        // Player Missile settings

        public int NumberOfAlienRows { get; set; } = 5;

        public int NumberOfAlienColls { get; set; } = 8;

        public int AlienStartXCoord { get; set; } = 30;

        public int AlienStartYCoord { get; set; } = 2;

        public char AlienShip { get; set; } = '0';

        public int AlienSpeed { get; set; } = 20;

        // alien settings

        public int GameSpeed { get; set; } = 200;

        public int ScoreStartXCoord { get; set; } = 50;

        public int ScoreStartYCoord { get; set; } = 23;

        // score settings
        


    }
}
