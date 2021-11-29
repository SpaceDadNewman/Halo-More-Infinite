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

        public const string IMAGE_GRUNT = "./Assets/grunt.jpg";
        public const string IMAGE_PADDLE = "./Assets/bat.png";
        public const string IMAGE_BULLET = "./Assets/nerf.png";

        public const string SOUND_START = "./Assets/start.wav";
        public const string SOUND_BOUNCE = "./Assets/boing.wav";
        public const string SOUND_OVER = "./Assets/over.wav";

        public const int BULLET_X = MAX_X / 2;
        public const int BULLET_Y = MAX_Y - 125;

        public const int BULLET_DX = 8;
        public const int BULLET_DY = BULLET_DX * -1;

        public const int PADDLE_X = MAX_X / 2;
        public const int PADDLE_Y = MAX_Y - 25;

        public const int GRUNT_WIDTH = 47;
        public const int GRUNT_HEIGHT = 45;

        public const int GRUNT_SPACE = 5;

        public const int PADDLE_SPEED = 15;

        public const int PADDLE_WIDTH = 96;
        public const int PADDLE_HEIGHT = 24;

        public const int BULLET_WIDTH = 77;
        public const int BULLET_HEIGHT = 14;
    }

}