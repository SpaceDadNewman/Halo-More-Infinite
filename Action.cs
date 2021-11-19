using System;
using System.Collections.Generic;
using cse210_project.Casting;

namespace cse210_project
{
    /// <summary>
    /// The base class of all other actions.
    /// </summary>
    public abstract class Action
    {
        public abstract void Execute(Dictionary<string, List<Actor>> cast);
    }
}