using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverProps : MonoBehaviour {

	#region Variables
	//public


	//private
	#endregion
	private Vector3 originalPos;
	private Rigidbody myRB;

	#region UnityFunctions

	void Start()
	{
		originalPos = transform.position;
		myRB = GetComponent<Rigidbody> ();
	}

	void FixedUpdate()
	{
		//  myRB.AddForce (Vector3.right * 80.0f * Time.fixedDeltaTime);
		myRB.velocity = Vector3.right * 100 * Time.fixedDeltaTime;  
	}

	#endregion 

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "RiverEnd") 
		{
			transform.position = originalPos;
		}
	}
}
