using System;
using UnityEngine;

namespace Feint.Command
{
    public class MoveCommand:CommandEntity
    {

        private Transform _transform;

        public Transform Action
        {
            get { return _transform; }
        }

        public MoveCommand(Transform transform)
        {
            _transform = transform;
        }
        
        public override Command Execute()
        {
            _transform.position+=new Vector3(2,0,0)*Time.deltaTime;
            MoveCommand mc = new MoveCommand(_transform);
            _commandStack.Push(mc);
            return mc;
        }

        public override Command Undo()
        {
            if (_commandStack.Count == 0)
                return null;
            Transform transform = ((MoveCommand) _commandStack.Pop()).Action;
            transform.position-=new Vector3(2,0,0)*Time.deltaTime;
            MoveCommand mc=new MoveCommand(transform);
            return mc;
        }

        public override Command Redo()
        {
            return null;
        }
    }
}