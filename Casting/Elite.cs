using System;
using System.Collections.Generic;
using cse210_project.Casting;

namespace cse210_project
{
    class Elite : Actor
    {
        private int Health = 5;
        public Elite(int x, int y)
        {
            SetPosition(new Point(Constants.MAX_X - Constants.ELITE_WIDTH - 5,y));
            SetImage(Constants.IMAGE_ELITE);
            SetWidth(Constants.ELITE_WIDTH);
            SetHeight(Constants.ELITE_HEIGHT);
            SetVelocity(new Point(0,5));
        }
        public void IsHit()
        {
            Health -= 1;
        }
        public bool IsDead()
        {
            if (Health == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}