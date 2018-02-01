

using System.Collections;
using System.Collections.Generic;

namespace Feint.Command
{
    public abstract class CommandEntity : Command
    {
        public abstract Command Execute();
        public abstract Command Undo();
        public abstract Command Redo();

        protected Stack<Command> _commandStack=new Stack<Command>();

    }
}