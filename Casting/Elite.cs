using System;
using System.Collections.Generic;
using cse210_project.Casting;

namespace cse210_project
{
    class Elite : Actor
    {
        private int EliteHealth = 5;
        public Elite(int x, int y)
        {
            SetPosition(new Point(Constants.MAX_X - Constants.ELITE_WIDTH - 5,y));
            SetImage(Constants.IMAGE_ELITE);
            SetWidth(Constants.ELITE_WIDTH);
            SetHeight(Constants.ELITE_HEIGHT);
            SetVelocity(new Point(0,5));
        }
        public void EliteIsHit()
        {
            EliteHealth -= 1;
        }
        public bool EliteIsDead()
        {
            if (EliteHealth == 0)
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