using System;
using System.Collections.Generic;
using cse210_project.Casting;

namespace cse210_project
{
    //was the brick class
    class Grunt : Actor
    {
        public Grunt(int x, int y)
        {
            SetPosition(new Point(x,y));
            SetImage(Constants.IMAGE_BRICK);
            SetWidth(Constants.BRICK_WIDTH);
            SetHeight(Constants.BRICK_HEIGHT);
        }
    }
}