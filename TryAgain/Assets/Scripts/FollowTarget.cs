using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour {

	#region Variables
	//public
	public Transform target;
	public float yHeight;
	public float zDistance;

	//private

	#endregion

	#region UnityFunctions

	void Update () 
	{
		Follow ();
	}

	#endregion 


	private void Follow()
	{
		transform.position = new Vector3 (target.position.x, yHeight, target.position.z - zDistance);
	}
}
