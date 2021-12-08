using System;

namespace cse210_project
{
    /// <summary>
    /// This is a set of program wide constants to be used in other classes.
    /// </summary>
    public static class Constants
    {
        public const int MAX_X = 800;
        public const int MAX_Y = 600;
        public const int FRAME_RATE = 30;

        public const int DEFAULT_SQUARE_SIZE = 20;
        public const int DEFAULT_FONT_SIZE = 20;
        public const int DEFAULT_TEXT_OFFSET = 4;

        public const string IMAGE_GRUNT = "./Assets/grunt.png";
        public const string IMAGE_CHIEF = "./Assets/master_chief.png";
        public const string IMAGE_BULLET = "./Assets/nerf.png";
        public const string IMAGE_ENEMYBULLET = "./Assets/nerf_enemy.png";
        public const string IMAGE_ELITE = "./Assets/elite.png";

        public const string SOUND_START = "./Assets/Halo_Start.wav";
        public const string SOUND_SHOOT = "./Assets/pew.wav";
        public const string SOUND_OVER = "./Assets/Halo_End.wav";
        public const string SOUND_DAMAGE = "./Assets/damage.wav";
        public const string SOUND_CHIEFDAMAGE = "./Assets/ChiefisHit.wav";

        public const int CHIEF_X = MAX_X / 2;
        public const int CHIEF_Y = MAX_Y - 25;

        public const int GRUNT_WIDTH = 42;
        public const int GRUNT_HEIGHT = 46;

        public const int GRUNT_SPACE = 5;
        public const int ELITE_WIDTH = 75;
        public const int ELITE_HEIGHT = 108;

        public const int ELITE_SPACE = 5;

        public const int CHIEF_SPEED = 15;

        public const int CHIEF_WIDTH = 90;
        public const int CHIEF_HEIGHT = 104;

        public const int BULLET_WIDTH = 77;
        public const int BULLET_HEIGHT = 14;
        public const int ENEMYBULLET_WIDTH = 77;
        public const int ENEMYBULLET_HEIGHT = 14;
    }

}