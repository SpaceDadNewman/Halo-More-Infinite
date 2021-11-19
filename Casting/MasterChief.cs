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
            SetPosition(new Point(Constants.MAX_X / 2,Constants.MAX_Y - 25));
            SetImage(Constants.IMAGE_PADDLE);
            SetWidth(Constants.PADDLE_WIDTH);
            SetHeight(Constants.PADDLE_HEIGHT);
        }
    }
}