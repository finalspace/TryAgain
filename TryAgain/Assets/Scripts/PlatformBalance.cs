using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBalance : MonoBehaviour {

	public Transform leftCtrl;
	public Transform rightCtrl;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate () 
	{
		/*
		float newZ = transform.eulerAngles.z;
		if (newZ > 330)
			newZ -= 360;
		if (Input.GetKey (KeyCode.O)) {
			transform.eulerAngles = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, Mathf.Min (10, newZ + 1f));
		}
		else if (Input.GetKey (KeyCode.P)) {
			transform.eulerAngles = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, Mathf.Max (-10, newZ - 1f));
		}
*/



		float leftHeight = leftCtrl.position.y;
		float rightHeight = rightCtrl.position.y;

		#if UNITY_EDITOR
		if (Input.GetKey (KeyCode.F)) {
			leftHeight += 0.3f;
		}
		else if (Input.GetKey (KeyCode.V)) {
			leftHeight -= 0.3f;
		}

		if (Input.GetKey (KeyCode.K)) {
			rightHeight += 0.3f;
		}
		else if (Input.GetKey (KeyCode.M)) {
			rightHeight -= 0.3f;
		}
		#endif


		#if !UNITY_EDITOR

		Touch touch0 = Input.GetTouch(0);
		Vector2 deltaPosition = touch0.deltaPosition;

		//float rotX = deltaPosition.x * Mathf.Deg2Rad;

		//Vector3 playerScreenPos = _camera.WorldToScreenPoint(transform.position);
		/*
		if (Input.mousePosition.y >= playerScreenPos.y)
		{
		transform.RotateAround(Vector3.up, -rotX);
		} 
		else
		{
		transform.RotateAround(Vector3.up, rotX);
		}
		}
		*/
		leftHeight += deltaPosition.y;

		#endif

		leftHeight = Mathf.Min (leftHeight, 3);
		leftHeight = Mathf.Max (leftHeight, 1);
		rightHeight = Mathf.Min (rightHeight, 3);
		rightHeight = Mathf.Max (rightHeight, 1);
		leftCtrl.position = new Vector3 (leftCtrl.position.x, leftHeight, leftCtrl.position.z);
		rightCtrl.position = new Vector3 (rightCtrl.position.x, rightHeight, rightCtrl.position.z);


		Vector3 v = rightCtrl.transform.position - leftCtrl.transform.position;
		Vector3 normalDir = new Vector3 (-v.y, v.x, 0) / Mathf.Sqrt (v.x * v.x + v.y * v.y);
		Vector3 normalNormalized = normalDir.normalized;
		//Debug.Log (normalNormalized);
		Vector3 p1 = (leftCtrl.transform.position + rightCtrl.transform.position) / 2;
		Vector3 p2 = p1 + normalDir * 20;
		Debug.DrawLine (p1, p2, Color.red);

		transform.eulerAngles = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, -normalNormalized.x * 50);
		transform.position = new Vector3 (transform.position.x, p1.y, transform.position.z);
	}
}
