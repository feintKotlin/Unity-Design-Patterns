using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Feint.Command
{

	public class BoxMove : MonoBehaviour
	{
		private PlaceHolder _placeHolder;
		// Use this for initialization
		void Start()
		{
			_placeHolder = GameObject.FindObjectOfType<PlaceHolder>();
		}

		// Update is called once per frame
		void Update()
		{

		}

		public bool CanMove(MoveDir dir)
		{
			bool noMove = false;

			Vector3 position = MoveUtils.Move(dir) + transform.position;
			
			_placeHolder.BoxPlace.ForEach((Transform item) =>
			{
				if (!MoveUtils.CanMove(item.position, position))
					noMove = true;
			});
			
			_placeHolder.WallPlace.ForEach((Transform item) =>
			{
				if (!MoveUtils.CanMove(item.position, position))
					noMove = true;
			});


			return !noMove;
		}
	}
}
