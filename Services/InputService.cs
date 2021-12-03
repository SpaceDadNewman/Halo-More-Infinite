using System;
using Raylib_cs;

using cse210_project.Casting;

namespace cse210_project.Services
{
    /// <summary>
    /// Handles all the interaction with the user input library.
    /// </summary>
    public class InputService
    {
        public InputService()
        {

        }
        public bool IsUpPressed()
        {
            return Raylib.IsKeyDown(Raylib_cs.KeyboardKey.KEY_UP);
        }
        public bool IsDownPressed()
        {
            return Raylib.IsKeyPressed(Raylib_cs.KeyboardKey.KEY_DOWN);
        }

        public bool IsSpacePressed()
        {
            return Raylib.IsKeyPressed(Raylib_cs.KeyboardKey.KEY_SPACE);
        }

        /// <summary>
        /// Gets the direction asked for by the current key presses
        /// </summary>
        /// <returns></returns>
        public Point GetDirection()
        {
            int x = 0;
            int y = 0;
            
            if (IsUpPressed())
            {
                y = -1;
            }
            
            if (IsDownPressed())
            {
                y = 1;
            }
            
            return new Point(x, y);
        }

        public bool Shoot()
        {
            if (IsSpacePressed())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Returns true if the user has attempted to close the window.
        /// </summary>
        /// <returns></returns>
        public bool IsWindowClosing()
        {
            return Raylib.WindowShouldClose();
        }
    }

}