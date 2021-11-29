using System;
using System.Collections.Generic;
using cse210_project.Casting;

namespace cse210_project
{
    class Bullet : Actor
    {
        public Bullet(int x, int y)
        {
            SetPosition(new Point(x, y));
            SetImage(Constants.IMAGE_BULLET);
            SetWidth(Constants.BULLET_WIDTH);
            SetHeight(Constants.BULLET_HEIGHT);
            SetVelocity(new Point(5,0));
        }
    }
}