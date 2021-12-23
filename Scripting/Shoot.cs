using System.Collections.Generic;
using cse210_project.Casting;
using cse210_project.Services;
using System;

namespace cse210_project.Scripting
{
    public class Shoot : Action
    {
        AudioService _audioService;
        InputService _inputService;
        int _count = 0;
        public Shoot(InputService inputService, AudioService audioService)
        { 
            _inputService = inputService;
            _audioService = audioService;
        }
        public override void Execute(Dictionary<string, List<Actor>> _cast)
        {
            //master chief shooting
                if (_inputService.Shoot())
                {
                    _audioService.PlaySound(Constants.SOUND_SHOOT);
                    _cast["bullets"].Add(new Bullet(_cast["MasterChief"][0].GetX(),_cast["MasterChief"][0].GetY() + 10));
                }
                if (_count % 60 == 0)
                {
                    int gruntNumber;
                    int eliteNumber;
                    int gruntLength = _cast["grunts"].Count;
                    int eliteLength = _cast["elites"].Count;
                    Random rnd = new Random();
                    gruntNumber = rnd.Next(0,gruntLength);
                    eliteNumber = rnd.Next(0,eliteLength);
                    if (gruntNumber <= gruntLength && gruntLength > 0)
                    {
                        _cast["enemyBullets"].Add(new EnemyBullet(_cast["grunts"][gruntNumber].GetX(),_cast["grunts"][gruntNumber].GetY()));
                    }
                    if (eliteNumber <= eliteLength && eliteLength > 0)
                    {
                        _cast["enemyBullets"].Add(new EnemyBullet(_cast["elites"][eliteNumber].GetX(),_cast["elites"][eliteNumber].GetY()));
                    }
                }
                _count++;
        }
    }
}