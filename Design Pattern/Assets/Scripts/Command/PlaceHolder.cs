using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceHolder : MonoBehaviour
{
	[SerializeField] private List<Transform> _wallPlace;

	[SerializeField] private List<Transform> _boxPlace; 

	public List<Transform> WallPlace
	{
		get { return _wallPlace; }
	}

	public List<Transform> BoxPlace
	{
		get { return _boxPlace; }
	}
}
