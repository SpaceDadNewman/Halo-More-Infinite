using System;
using cse210_project.Services;
using cse210_project.Casting;
using cse210_project.Scripting;
using System.Collections.Generic;

namespace cse210_project
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create the cast
            Dictionary<string, List<Actor>> cast = new Dictionary<string, List<Actor>>();

            // Bricks
            cast["Grunts"] = new List<Actor>();

            // TODO: line of grunts is placed

            for(int grunts = Constants.MAX_X; grunts < Constants.MAX_X; grunts += Constants.BRICK_WIDTH + 10)
            {
                cast["Grunts"].Add(new Grunt(grunts, 25));
            }

            // The Ball (or balls if desired)
            cast["bullets"] = new List<Actor>();

            // TODO: Add your ball here
            cast["bullets"].Add(new Bullet());

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

            // HandleOffScreenAction handleOffScreenAction = new HandleOffScreenAction();
            // script["update"].Add(handleOffScreenAction);

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
