using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	#region Variables
	//public
	public GameObject scoreText;
	public Vector3 gravity;
	public float maxAngle = 30;

	//private
	[SerializeField]
	private float movementSpeed = 0.0f;
	private Rigidbody myRB;
	private UIFunctions uiFunctions;

	private Vector3 lastPos;
	private Vector3 vel;

	#endregion

	#region UnityFunctions

	void Start () 
	{
		myRB = GetComponent<Rigidbody> ();
		uiFunctions = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<UIFunctions> ();
		Physics.gravity = gravity;

		lastPos = transform.position;
		vel = Vector3.zero;
	}

	void FixedUpdate () 
	{
		//Move ();
		float speed = ((transform.position - lastPos) / Time.deltaTime).y;
		lastPos = transform.position;
		vel = transform.up * speed;
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

		if (collision.gameObject.tag == "CtrlPlatform") {
			//myRB.velocity = Vector3.Reflect (myRB.velocity, collision.contacts [0].normal) * 2;
			//myRB.AddForce (myRB.velocity.normalized * 1000);



			Vector3 normal = collision.contacts[0].normal;
			Vector3 localVel = vel; // myRB.velocity;
			Vector3 targetVel = collision.gameObject.GetComponent<PlatformBalance> ().GetVel();
			//Debug.Log (targetVel);

			///Debug.Log(Vector3.Angle(localVel, normal));
			// measure angle
			if (Vector3.Angle(localVel, normal) < maxAngle){
				// bullet bounces off the surface
				Vector3 newVel = Vector3.Reflect(localVel, normal);
				Debug.Log(Vector3.Dot(targetVel, newVel));
				//myRB.velocity = newVel * (Vector3.Dot (targetVel, newVel));
			} else {
			}
		}
	}
}
