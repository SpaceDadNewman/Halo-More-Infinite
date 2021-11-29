using System;
using System.Collections.Generic;
using cse210_project.Casting;

namespace cse210_project
{
    class Grunt : Actor
    {
        public Grunt(int x, int y)
        {
            SetPosition(new Point(Constants.MAX_X - Constants.GRUNT_WIDTH - 5,y));
            SetImage(Constants.IMAGE_GRUNT);
            SetWidth(Constants.GRUNT_WIDTH);
            SetHeight(Constants.GRUNT_HEIGHT);
            SetVelocity(new Point(0,3));
        }
    }
}