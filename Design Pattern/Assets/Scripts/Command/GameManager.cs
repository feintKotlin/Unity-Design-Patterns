using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Feint.Command
{
	public class GameManager : MonoBehaviour
	{
		private PlaceHolder _placeHolder;
		//Add by 命令模式
		[SerializeField] private KeyCode Undo;
		//Add by 命令模式
		[SerializeField] private KeyCode Redo;
		//Add by 命令模式
		private CommandHandler _commandHandler;
		
		void Start()
		{
			
			_placeHolder = GameObject.FindObjectOfType<PlaceHolder>();
			//Add by 命令模式
			_commandHandler = new CommandHandler();
		}
		//Add by 命令模式
		private void Update()
		{
			if (Input.GetKeyDown(Undo))
			{
				_commandHandler.handle(Action.Undo);
			}

			if (Input.GetKeyDown(Redo))
			{
				_commandHandler.handle(Action.Redo);
			}
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
			{
			//	msg.transform.position += MoveUtils.Move(msg.dir);
				
				//Add by 命令模式
				Command command=new MoveCommand(msg.transform,msg.dir);
				_commandHandler.handle(Action.Exe,command);
			}

			if (type == CubeType.Box )
			{
				BoxMove bm = trans.gameObject.GetComponent<BoxMove>();

				if (bm.CanMove(msg.dir))
				{
//					msg.transform.position += MoveUtils.Move(msg.dir);
//					trans.position += MoveUtils.Move(msg.dir);
					
					//Add by 命令模式
					Command command=new BoxCommand(trans,msg.transform,msg.dir);
					_commandHandler.handle(Action.Exe,command);
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