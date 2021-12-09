using System;
using System.Collections.Generic;
using cse210_project.Casting;

namespace cse210_project
{
    class MasterChief : Actor
    {
        private int ChiefHealth = 5;
        public MasterChief()
        {
            SetPosition(new Point(25, Constants.MAX_Y / 2));
            SetImage(Constants.IMAGE_CHIEF);
            SetWidth(Constants.CHIEF_WIDTH);
            SetHeight(Constants.CHIEF_HEIGHT);
        }
        public void ChiefIsHit()
        {
            ChiefHealth -= 1;
        }
        public bool ChiefIsDead()
        {
            if (ChiefHealth == 0)
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