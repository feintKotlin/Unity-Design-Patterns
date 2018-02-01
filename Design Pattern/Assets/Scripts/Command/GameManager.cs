using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Feint.Command
{
	public class GameManager : MonoBehaviour
	{
		private PlaceHolder _placeHolder;
		// Use this for initialization

		
		void Start()
		{
			_placeHolder = GameObject.FindObjectOfType<PlaceHolder>();
			
		}


		void Move(CubeMsg msg)
		{
			Transform trans=new GameObject("").transform;	

			Vector3 position= msg.transform.position + MoveUtils.Move(msg.dir) ;

			CubeType type=CubeType.None;
			
			_placeHolder.BoxPlace.ForEach((Transform item) =>
			{
				if (!MoveUtils.CanMove(item.position, position))
				{
					trans = item;
					type = CubeType.Box;
				}
			});
			
			_placeHolder.WallPlace.ForEach((Transform item) =>
			{
				if (!MoveUtils.CanMove(item.position, position))
				{
					trans = item;
					type = CubeType.Wall;
				}
			});

			if (type == CubeType.None)
				msg.transform.position +=  MoveUtils.Move(msg.dir);
			if (type == CubeType.Box )
			{
				BoxMove bm = trans.gameObject.GetComponent<BoxMove>();

				if (bm.CanMove(msg.dir))
				{
					msg.transform.position += MoveUtils.Move(msg.dir);
					trans.position += MoveUtils.Move(msg.dir);
				}
			}
			
		}
		
	}

	public enum CubeType
	{
		Wall,Box,None
	}

	public enum MoveDir
	{
		Up,Down,Right,Left
	}

}