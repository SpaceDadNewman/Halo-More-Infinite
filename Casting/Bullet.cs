using System;
using System.Collections.Generic;
using cse210_project.Casting;

namespace cse210_project
{
    //was the ball class
    class Bullet : Actor
    {
        public Bullet()
        {
            SetPosition(new Point(Constants.MAX_X / 2, Constants.MAX_Y / 2));
            SetImage(Constants.IMAGE_BALL);
            SetWidth(Constants.BALL_WIDTH);
            SetHeight(Constants.BALL_HEIGHT);
            SetVelocity(new Point(-5,-5));
        }
    }
}