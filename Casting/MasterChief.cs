using System;
using System.Collections.Generic;
using cse210_project.Casting;

namespace cse210_project
{
    //was the paddle class
    class MasterChief : Actor
    {
        public MasterChief()
        {
            SetPosition(new Point(25, Constants.MAX_Y / 2));
            SetImage(Constants.IMAGE_PADDLE);
            SetWidth(Constants.PADDLE_WIDTH);
            SetHeight(Constants.PADDLE_HEIGHT);
        }
    }
}