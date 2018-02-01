using System.Collections.Generic;
using UnityEditor.Experimental.Build.AssetBundle;

namespace Feint.Command
{
    public class CommandHandler
    {
        private Stack<Command> _undoCommandStack;
        private Stack<Command> _redoCommandStack;

        public CommandHandler()
        {
            _undoCommandStack = new Stack<Command>();
            _redoCommandStack = new Stack<Command>();
        }

        public void handle(Action act,Command command=null)
        {
            if (act == Action.Exe)
            {
                command.Execute();
                _undoCommandStack.Push(command);
                _redoCommandStack.Clear();
            }

            if (act == Action.Undo&&_undoCommandStack.Count>0)
            {
                Command comm = _undoCommandStack.Pop();
                comm.Undo();
                _redoCommandStack.Push(comm);
            }

            if (act == Action.Redo&&_redoCommandStack.Count>0)
            {
                Command comm = _redoCommandStack.Pop();
                comm.Redo();
                _undoCommandStack.Push(comm);
            }
        }
        
        
    }

    public enum Action
    {
        Exe,Undo,Redo
    }
}