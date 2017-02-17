using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowPortal : MonoBehaviour {

	public GameObject leftPortal;
	public GameObject rightPortal;
	public GameObject newSphere;

	public static Vector3 rayCastNormal;
	public static Vector3 rayCastNormal2;

	GameObject mainCamera;
	// Use this for initialization
	void Start () {
			//mainCamera = GameObject.FindWithTag ("MainCamera");

		//if (leftPortal == null) {
			leftPortal = GameObject.Find("LeftPortal");
		//}
		//if (rightPortal == null) {
			rightPortal = GameObject.Find("RightPortal");
		//}
	
	}

	
	// Update is called once per frame
	void Update () {

		if(Input.GetMouseButtonDown(0)){
		//	Debug.Log ("left click");
			//leftPortal.SetActive (true);
			throwPortal (leftPortal,0);

		}
		if (Input.GetMouseButtonDown (1)) {
		//	Debug.Log ("right click");
			//rightPortal.SetActive (true);
			throwPortal (rightPortal,1);

			//checkVelocity();
		}

	}

	void throwPortal (GameObject portal,int identifier)
	{
		int x = Screen.width / 2;
		int y = Screen.height / 2;
		mainCamera = GameObject.FindWithTag ("MainCamera");
		Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay (new Vector3 (x, y));
		RaycastHit hit;

		if (Physics.Raycast (ray,out hit )) {


			Quaternion hitObjectRotation = Quaternion.LookRotation (hit.normal);
			portal.transform.position = hit.point;
				
			if (identifier == 0) {
				
				rayCastNormal = hit.normal;	
			} else {
				rayCastNormal2 = hit.normal;	
			}




			portal.transform.rotation = hitObjectRotation;

		}
	}

	void checkVelocity(){

		Rigidbody rb = GetComponent<Rigidbody> ();
		 
		Vector3 velocity = rb.velocity;
		velocity = Vector3.Reflect (velocity, transform.forward);
		velocity = transform.InverseTransformDirection (velocity);
		//velocity = transformOtherPortal.TransformDirection (velocity);
		rb.velocity = velocity;

	}







}
