using System;
using System.Collections.Generic;
using cse210_project.Casting;
using cse210_project.Services;
using cse210_project.Scripting;

namespace cse210_project
{
    /// <summary>
    /// The director is responsible to direct the game, including to keep track of all
    /// the actors and to control the sequence of play.
    /// 
    /// Stereotype:
    ///     Controller
    /// </summary>
    public class Director
    {
        private bool _keepPlaying = true;
        AudioService audioService = new AudioService();
        private Dictionary<string, List<Actor>> _cast;
        private Dictionary<string, List<Action>> _script;
        private InputService _inputservice = new InputService();
        private OutputService _outputservice = new OutputService();

        public Director(Dictionary<string, List<Actor>> cast, Dictionary<string, List<Action>> script)
        {
            _cast = cast;
            _script = script;
        }

        /// <summary>
        /// This method starts the game and continues running until it is finished.
        /// </summary>
        public void Direct()
        {
            while (_keepPlaying)
           {
                //master chief shooting
                if (_inputservice.Shoot())
                {
                    audioService.PlaySound(Constants.SOUND_SHOOT);
                    _cast["bullets"].Add(new Bullet(_cast["MasterChief"][0].GetX(),_cast["MasterChief"][0].GetY() + 10));
                    // _cast["enemyBullets"].Add(new EnemyBullet(_cast["grunts"][5].GetX() - 50,_cast["grunts"][5].GetY()));
                }
                //enemies shooting
                // if (_outputservice.EnemyShoot())
                // {
                //     _cast["enemyBullets"].Add(new EnemyBullet(_cast["grunts"][0].GetX() - 50,_cast["grunts"][0].GetY()));
                // }
                CueAction("input");
                CueAction("update");
                CueAction("output");

                if (Raylib_cs.Raylib.WindowShouldClose())
                {
                    _keepPlaying = false;
                }
                if (_cast["grunts"].Count == 0 && _cast["elites"].Count == 0)
                {
                    audioService.PlaySound(Constants.SOUND_OVER);
                    _keepPlaying = false;
                }
                // if (Collisions.DeadChief == true)
                // {
                //     audioService.PlaySound(Constants.SOUND_OVER);
                //     _keepPlaying = false;
                // }
            }
        }

        /// <summary>
        /// Executes all of the actions for the provided phase.
        /// </summary>
        /// <param name="phase"></param>
        private void CueAction(string phase)
        {
            List<Action> actions = _script[phase];

            foreach (Action action in actions)
            {
                action.Execute(_cast);
            }
        }

    }
}
