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
        private List<Actor> _elites;
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
            _enemyBullets = cast["enemyBullets"];
            _masterchief = cast["MasterChief"];
            _elites = cast["elites"];
            List<Actor> DeadGrunts = new List<Actor>();
            List<Actor> UsedBullets = new List<Actor>();
            List<Actor> DeadElites = new List<Actor>();
            List<Actor> DeadChief = new List<Actor>();

            //grunt collisions
            foreach (Actor Grunt in _grunts)
            {
                foreach (Actor Bullet in _bullets)
                {
                    if (_physicsService.IsCollision(Bullet, Grunt))
                    {
                        DeadGrunts.Add(Grunt);
                        UsedBullets.Add(Bullet);
                        audioService.PlaySound(Constants.SOUND_DAMAGE);
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
                    // if (_physicsService.IsCollision(Grunt, Grunt))
                    // {
                    //     BounceActorsY(Grunt);
                    // }
                }
            }
            //elite collisions
            foreach (Elite Elite in _elites)
            {
                foreach (Actor Bullet in _bullets)
                {
                    if (_physicsService.IsCollision(Bullet, Elite))
                    {
                       Elite.EliteIsHit();
                       UsedBullets.Add(Bullet);
                       if (Elite.EliteIsDead())
                       {
                           DeadElites.Add(Elite);
                       }
                       audioService.PlaySound(Constants.SOUND_DAMAGE);
                    }
                // moves elites up and down
                    if (Elite.GetBottomEdge() >= Constants.MAX_Y - Constants.ELITE_HEIGHT)
                    {
                        BounceActorsY(Elite);
                    }
                    if (Elite.GetTopEdge() <= 0 - Constants.ELITE_HEIGHT)
                    {
                        BounceActorsY(Elite);
                    }
                    // if (_physicsService.IsCollision(Elite, Elite))
                    // {
                    //     BounceActorsY(Elite);
                    // }
                }
            }
            foreach (Actor Grunt in DeadGrunts)
            {
                cast["grunts"].Remove(Grunt);
            }
            foreach (Actor Elite in DeadElites)
            {
                cast["elites"].Remove(Elite);
            }
            //bullets
            foreach (EnemyBullet EnemyBullet in _enemyBullets)
            {
                if (EnemyBullet.GetPosition().GetX() <= 0 + Constants.ENEMYBULLET_WIDTH)
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
            foreach (MasterChief masterChief in _masterchief)
            {
                foreach (Actor EnemyBullet in _enemyBullets)
                {
                    if (_physicsService.IsCollision(EnemyBullet, masterChief))
                    {
                       UsedBullets.Add(EnemyBullet);
                       //health system
                       masterChief.ChiefIsHit();
                       if (masterChief.ChiefIsDead())
                       {
                           DeadChief.Add(masterChief);
                       }
                       audioService.PlaySound(Constants.SOUND_CHIEFDAMAGE);
                    }
                }
                //master chief hitting the top and bottom
                if (masterChief.GetBottomEdge() >= Constants.MAX_Y - 15)
                {
                    masterChief.SetPosition(new Point(masterChief.GetPosition().GetX(), Constants.MAX_Y - Constants.CHIEF_HEIGHT - 15));
                }
                if (masterChief.GetTopEdge() <= 15)
                {
                    masterChief.SetPosition(new Point(masterChief.GetPosition().GetX(), 15));
                }

            }
            foreach (Actor Bullet in UsedBullets)
            {
                cast["bullets"].Remove(Bullet);
            }
            foreach (Actor EnemyBullet in UsedBullets)
            {
                cast["enemyBullets"].Remove(EnemyBullet);
            }
            foreach (Actor MasterChief in DeadChief)
            {
                cast["MasterChief"].Remove(MasterChief);
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