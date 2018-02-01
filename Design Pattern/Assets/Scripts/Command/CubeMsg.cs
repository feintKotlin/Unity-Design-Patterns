using UnityEngine;
using UnityEngine.Networking;

namespace Feint.Command
{
    
    public class CubeMsg
    {
        public Transform transform;
        public MoveDir dir;

        CubeMsg(Transform transform,MoveDir dir)
        {
            this.transform = transform;
            
            this.dir = dir;
        }

        public static CubeMsg msg(Transform transform, MoveDir dir)
        {
            return new CubeMsg(transform,dir);
        }
    }
}