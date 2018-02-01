using UnityEngine;

namespace Feint.Command
{
    public class BoxCommand:Command
    {
        private Transform _box;
        private Transform _player;
        private MoveDir _dir;
        public BoxCommand(Transform box, Transform player, MoveDir dir)
        {
            this._box = box;
            this._player = player;
            this._dir = dir;
        }

        public Command Execute()
        {
            _box.position += MoveUtils.Move(_dir);
            _player.position += MoveUtils.Move(_dir);

            return this;
        }

        public Command Undo()
        {
            _box.position -= MoveUtils.Move(_dir);
            _player.position -= MoveUtils.Move(_dir);

            return this;
        }

        public Command Redo()
        {
            _box.position += MoveUtils.Move(_dir);
            _player.position += MoveUtils.Move(_dir);

            return this;
        }
    }
}