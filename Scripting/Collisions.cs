using System.Collections.Generic;
using cse210_project.Casting;
using cse210_project.Services;

namespace cse210_project
{
    public class Collisions : Action
    {
        private List<Actor> _grunts;
        private List<Actor> _bullets;
        private List<Actor> _enemyBullets;
        private List<Actor> _masterchief;
        private PhysicsService _physicsService;
        AudioService audioService = new AudioService();
        // private bool DeadChief;
        public Collisions(PhysicsService _PhysicsService)
        {
            _physicsService = _PhysicsService;
        }
        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            _grunts = cast["grunts"];
            _bullets = cast["bullets"];
            _enemyBullets = cast["enemyBullets"];
            _masterchief = cast["MasterChief"];
            List<Actor> DeadGrunts = new List<Actor>();
            List<Actor> UsedBullets = new List<Actor>();
            // DeadChief = false;

            //when bullet hits
            foreach (Actor Grunt in _grunts)
            {
                foreach (Actor Bullet in _bullets)
                {
                    if (_physicsService.IsCollision(Bullet, Grunt))
                    {
                        DeadGrunts.Add(Grunt);
                    }
                // moves grunts up and down
                    if (Grunt.GetBottomEdge() >= Constants.MAX_Y - Constants.GRUNT_HEIGHT)
                    {
                        BounceActorsY(Grunt);
                    }
                    if (Grunt.GetTopEdge() <= 0 - Constants.GRUNT_HEIGHT)
                    {
                        BounceActorsY(Grunt);
                    }
                }
            }
            foreach (Actor Grunt in DeadGrunts)
            {
                cast["grunts"].Remove(Grunt);
            }
            //bullets
            foreach (EnemyBullet EnemyBullet in _enemyBullets)
            {
                if (EnemyBullet.GetPosition().GetX() <= 0 + Constants.ENEMYBULLET_WIDTH || 
                EnemyBullet.GetPosition().GetX() >= Constants.MAX_X - Constants.ENEMYBULLET_WIDTH)
                {
                    UsedBullets.Add(EnemyBullet);
                }
            }
            foreach (Bullet Bullet in _bullets)
            {
                if (Bullet.GetPosition().GetX() >= Constants.MAX_X - Constants.BULLET_WIDTH)
                {
                    UsedBullets.Add(Bullet);
                }
            }
            //master chief gets shot
            foreach (Actor MasterChief in _masterchief)
            {
                foreach (Actor EnemyBullet in _enemyBullets)
                {
                    if (_physicsService.IsCollision(EnemyBullet, MasterChief))
                    {
                        // DeadChief = true;
                    }
                }
                //master chief hitting the top and bottom
                if (MasterChief.GetBottomEdge() >= Constants.MAX_Y - Constants.CHIEF_HEIGHT)
                {
                    StopActors(MasterChief);
                }
                if (MasterChief.GetTopEdge() <= 0 + Constants.CHIEF_HEIGHT)
                {
                    StopActors(MasterChief);
                }

            }
            foreach (Actor Bullet in UsedBullets)
            {
                cast["bullets"].Remove(Bullet);
            }
            // foreach (Actor MasterChief in DeadChief)
            // {
            //     cast["MasterChief"].Remove(MasterChief);
            // }
        }
        //grunt movement
            private void BounceActorsY(Actor actor)
            {
                int x = actor.GetVelocity().GetX();
                int y = actor.GetVelocity().GetY();
                y *= -1;
                actor.SetVelocity(new Point(x,y));
            }
            private void StopActors(Actor actor)
            {
                int x = actor.GetVelocity().GetX();
                int y = actor.GetVelocity().GetY();
                x = 0;
                y = 0;
                actor.SetVelocity(new Point(x,y));
            }
        
    }
}