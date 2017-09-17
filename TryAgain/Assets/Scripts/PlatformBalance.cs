using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBalance : MonoBehaviour {

	public Transform leftCtrl;
	public Transform rightCtrl;
	Camera c;

	// Use this for initialization
	void Start () {
		c = Camera.main;
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
		
		/*
		if (Input.GetMouseButton (0)) 
		{
			Vector3 pp = c.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
			Debug.Log(Input.mousePosition);
			Debug.Log(pp);
			if (Input.mousePosition.x < Screen.width / 3)
			{
				Vector3 p = c.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
				leftHeight = p.y;
			}
			else if (Input.mousePosition.x > Screen.width * 2 / 3)
			{
				Vector3 p = c.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
				rightHeight = p.y;
			}
		}
		*/
		#endif



		#if !UNITY_EDITOR
		if (Input.touchCount == 1) 
		{
			Touch touch0 = Input.GetTouch(0);
			if (touch0.position.x < Screen.width / 3)
			{
		        Vector3 p = c.ScreenToWorldPoint(new Vector3(touch0.position.x, touch0.position.y, 10));
				leftHeight = p.y;
			}
			else if (touch0.position.x > Screen.width * 2 / 3)
			{
		        Vector3 p = c.ScreenToWorldPoint(new Vector3(touch0.position.x, touch0.position.y, 10));
				rightHeight = p.y;
			}
		}

		if (Input.touchCount == 2) 
		{
			Touch touch0 = Input.GetTouch(0);
			if (touch0.position.x < Screen.width / 3)
			{
		        Vector3 p = c.ScreenToWorldPoint(new Vector3(touch0.position.x, touch0.position.y, 10));
				leftHeight = p.y;
			}
			else if (touch0.position.x > Screen.width * 2 / 3)
			{
		        Vector3 p = c.ScreenToWorldPoint(new Vector3(touch0.position.x, touch0.position.y, 10));
				rightHeight = p.y;
			}

			Touch touch1 = Input.GetTouch(1);
			if (touch1.position.x < Screen.width / 3)
			{
				Vector3 p = c.ScreenToWorldPoint(new Vector3(touch1.position.x, touch1.position.y, 10));
				leftHeight = p.y;
			}
			else if (touch1.position.x > Screen.width * 2 / 3)
			{
				Vector3 p = c.ScreenToWorldPoint(new Vector3(touch1.position.x, touch1.position.y, 10));
				rightHeight = p.y;
			}

		}

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
