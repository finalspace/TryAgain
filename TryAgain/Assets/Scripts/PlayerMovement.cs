using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	#region Variables
	//public
	public GameObject scoreText;
	public Vector3 gravity;


	//private
	[SerializeField]
	private float movementSpeed = 0.0f;
	private Rigidbody myRB;
	private UIFunctions uiFunctions;

	#endregion

	#region UnityFunctions

	void Start () 
	{
		myRB = GetComponent<Rigidbody> ();
		uiFunctions = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<UIFunctions> ();
		Physics.gravity = gravity;
	}

	void FixedUpdate () 
	{
		Move ();
		Physics.gravity = gravity;
	}
	#endregion 

	private void Move()
	{
		if (Input.GetAxis ("Horizontal") != 0) 
		{
			float hAxis = Input.GetAxis ("Horizontal");
			Vector3 moveDir = new Vector3 (hAxis, 0, 0);
			myRB.velocity = moveDir * movementSpeed * Time.fixedDeltaTime;
			
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Water") 
		{
			scoreText.SetActive (false);
			uiFunctions.gameStarted = false;    //Disable the game
			uiFunctions.GameEnded();
		}
	}
}
