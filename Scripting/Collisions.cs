using System.Collections.Generic;
using cse210_project.Casting;
using cse210_project.Services;

namespace cse210_project
{
    public class Collisions : Action
    {
        private List<Actor> _grunts;
        private List<Actor> _bullets;
        private List<Actor> _masterchief;
        private PhysicsService _physicsService;
        AudioService audioService = new AudioService();
        public Collisions(PhysicsService _PhysicsService)
        {
            _physicsService = _PhysicsService;
        }
        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            _grunts = cast["grunts"];
            _bullets = cast["bullets"];
            _masterchief = cast["MasterChief"];
            List<Actor> DeadGrunts = new List<Actor>();
            List<Actor> UsedBullets = new List<Actor>();

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
                    if (Grunt.GetBottomEdge() >= Constants.MAX_Y)
                    {
                        BounceActorsY(Grunt);
                    }
                    if (Grunt.GetTopEdge() <= 0)
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
            foreach (Bullet Bullet in _bullets)
            {
                if (Bullet.GetPosition().GetX() >= Constants.MAX_X - Constants.BULLET_WIDTH)
                {
                    UsedBullets.Add(Bullet);
                }
            }
            foreach (Actor Bullet in UsedBullets)
            {
                cast["bullets"].Remove(Bullet);
            }
            //master chief gets shot
            foreach (Actor MasterChief in _masterchief)
            {
                foreach (Actor Bullet in _bullets)
                {
                    if (_physicsService.IsCollision(Bullet, MasterChief))
                    {
                    
                    }
                }

            }
            
        }
        //grunt movement
            private void BounceActorsY(Actor actor)
            {
                int x = actor.GetVelocity().GetX();
                int y = actor.GetVelocity().GetY();
                y *= -1;
                actor.SetVelocity(new Point(x,y));
            }
        
    }
}