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
            for(int grunts = 0; grunts < 10; grunts ++)
            {
                cast["grunts"].Add(new Grunt(Constants.MAX_X - Constants.GRUNT_WIDTH, Constants.GRUNT_HEIGHT));
            }

            // The Ball (or balls if desired)
            cast["bullets"] = new List<Actor>();

            // TODO: Add your ball here
            cast["bullets"].Add(new Bullet(25, Constants.MAX_Y / 2));
            // cast["bullets"].Add(new Bullet(x,y));

            // The paddle
            cast["MasterChief"] = new List<Actor>();

            // TODO: Add your paddle here
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
            outputService.OpenWindow(Constants.MAX_X, Constants.MAX_Y, "Batter", Constants.FRAME_RATE);
            audioService.StartAudio();
            audioService.PlaySound(Constants.SOUND_START);

            Director theDirector = new Director(cast, script);
            theDirector.Direct();

            audioService.StopAudio();
        }
    }
}
