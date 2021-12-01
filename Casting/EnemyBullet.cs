using System;
using System.Collections.Generic;
using cse210_project.Casting;

namespace cse210_project
{
    class EnemyBullet : Actor
    {
        public EnemyBullet(int x, int y)
        {
            SetPosition(new Point(x, y));
            SetImage(Constants.IMAGE_ENEMYBULLET);
            SetWidth(Constants.ENEMYBULLET_WIDTH);
            SetHeight(Constants.ENEMYBULLET_HEIGHT);
            SetVelocity(new Point(-20,0));
        }
    }
}