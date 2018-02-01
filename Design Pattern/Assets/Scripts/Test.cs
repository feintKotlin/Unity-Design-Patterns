using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Feint.Command;
public class Test : MonoBehaviour
{
	[SerializeField] private KeyCode doMove;

	[SerializeField] private KeyCode undoMove;

	private MoveCommand _command;
	// Use this for initialization
	void Start () {
		_command=new MoveCommand(transform);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(doMove))
		{
			_command.Execute();
		}

		if (Input.GetKey(undoMove))
		{
			_command.Undo();
		}
	}
}
