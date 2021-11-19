using System.Collections.Generic;
using cse210_project.Casting;
using cse210_project.Services;

namespace cse210_project
{
    public class Collisions : Action
    {
        private List<Actor> _grunts;
        private Actor _bullets;
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
            _bullets = cast["bullets"][0];
            _masterchief = cast["MasterChief"];
            List<Actor> DeadGrunts = new List<Actor>();

            //when get collisions
            foreach (Actor Grunt in _grunts)
            {
                if (_physicsService.IsCollision(_bullets, Grunt))
                {
                    BounceActorsY(_bullets);
                    DeadGrunts.Add(Grunt);
                    audioService.PlaySound(Constants.SOUND_BOUNCE);
                }
            }
            foreach (Actor Grunt in DeadGrunts)
            {
                cast["grunts"].Remove(Grunt);
            }
            //paddle collisions
            foreach (Actor Paddle in _masterchief)
            {
                if (_physicsService.IsCollision(_bullets, Paddle))
                {
                    BounceActorsY(_bullets);
                    audioService.PlaySound(Constants.SOUND_BOUNCE);
                    int x = _bullets.GetVelocity().GetX();
                    int y = _bullets.GetVelocity().GetY();
                    if (x > 0)
                    {
                        x += 1;
                    }
                    else
                    {
                        x -= 1;
                    }
                    if (y > 0)
                    {
                        y += 1;
                    }
                    else
                    {
                        y -= 1;
                    }
                    _bullets.SetVelocity(new Point(x, y));
                }
            }
        }

        private void BounceActorsX(Actor actor)
        {
            int x = actor.GetVelocity().GetX();
            int y = actor.GetVelocity().GetY();
            x *= -1;
            actor.SetVelocity(new Point(x,y));
        }
        private void BounceActorsY(Actor actor)
        {
            int x = actor.GetVelocity().GetX();
            int y = actor.GetVelocity().GetY();
            y *= -1;
            actor.SetVelocity(new Point(x,y));
        }
        
    }
}