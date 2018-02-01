using System;
using UnityEngine;

namespace Feint.Command
{
    public class MoveCommand:Command
    {

        private Transform _transform;
        private MoveDir _dir;

        public MoveCommand(Transform transform,MoveDir dir)
        {
            _transform = transform;
            _dir = dir;
        }
        
        public Command Execute()
        {
            _transform.position += MoveUtils.Move(_dir);
            return this;
        }

        public Command Undo()
        {
            _transform.position -= MoveUtils.Move(_dir);
            return this;
        }

        public  Command Redo()
        {
            _transform.position += MoveUtils.Move(_dir);
            return this;
        }
    }
}