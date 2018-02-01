using System;
using System.Collections;
using NUnit.Framework.Constraints;
using UnityEngine;

namespace Feint.Command
{
    public class MoveUtils
    {
        private static Hashtable _hashtable=new Hashtable();

        public static Vector3 Move(MoveDir dir)
        {
            if (_hashtable.Count == 0)
            {
                _hashtable[MoveDir.Up]=new  Vector3(0,1,0);
                _hashtable[MoveDir.Down]=new Vector3(0,-1,0);
                _hashtable[MoveDir.Left]=new Vector3(-1,0,0);
                _hashtable[MoveDir.Right]=new Vector3(1,0,0);
            }

            return (Vector3)_hashtable[dir];
        }

        public static bool CanMove(Vector3 posA, Vector3 posB)
        {
            return !(Math.Abs(posA.x - posB.x) < 0.05 && Math.Abs(posA.y - posB.y) < 0.05);
        }
    }
    
}