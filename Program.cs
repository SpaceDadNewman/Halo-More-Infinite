using System;
using cse210_project.Services;
using cse210_project.Casting;
using cse210_project.Scripting;
using System.Collections.Generic;

namespace cse210_project
{
    class Program
    {
        InputService inputservice = new InputService();
        static void Main(string[] args)
        {
            // Create the cast
            Dictionary<string, List<Actor>> cast = new Dictionary<string, List<Actor>>();

            // grunts
            cast["grunts"] = new List<Actor>();

            // grunt spawning
            for(int rows = 0; rows < 10; rows++)
            {
                for(int columns = 0; columns < Constants.MAX_Y; columns += Constants.GRUNT_HEIGHT + 10)
                {
                    // cast["grunts"].Add(new Grunt(Constants.MAX_X - Constants.GRUNT_WIDTH, Constants.GRUNT_HEIGHT));
                    cast["grunts"].Add(new Grunt(columns - 20, rows * Constants.GRUNT_HEIGHT));
                }
            }

            // bullets
            cast["bullets"] = new List<Actor>();
            cast["enemyBullets"] = new List<Actor>();

            // initial bullet spawn
            // cast["bullets"].Add(new Bullet(25, Constants.MAX_Y / 2));

            // masterchief
            cast["MasterChief"] = new List<Actor>();
            cast["MasterChief"].Add(new MasterChief());

            // Create the script
            Dictionary<string, List<Action>> script = new Dictionary<string, List<Action>>();

            OutputService outputService = new OutputService();
            InputService inputService = new InputService();
            PhysicsService physicsService = new PhysicsService();
            AudioService audioService = new AudioService();

            script["output"] = new List<Action>();
            script["input"] = new List<Action>();
            script["update"] = new List<Action>();

            DrawActorsAction drawActorsAction = new DrawActorsAction(outputService);
            script["output"].Add(drawActorsAction);

            // TODO: Add additional actions here to handle the input, move the actors, handle collisions, etc.'
            MoveActorsAction moveActorsAction = new MoveActorsAction();
            script["update"].Add(moveActorsAction);

            Collisions collisions = new Collisions(physicsService);
            script["update"].Add(collisions);

            ControlActorsAction controlActorsAction = new ControlActorsAction(inputService);
            script["update"].Add(controlActorsAction);

            // Start up the game
            outputService.OpenWindow(Constants.MAX_X, Constants.MAX_Y, "Tell that to the Covenant", Constants.FRAME_RATE);
            audioService.StartAudio();
            audioService.PlaySound(Constants.SOUND_START);

            Director theDirector = new Director(cast, script);
            theDirector.Direct();

            audioService.StopAudio();
        }
    }
}
