using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepThrowPortal : MonoBehaviour
{

	public GameObject otherPortal;
	public GameObject newPlayer;
	public int identifier;








	//this portal is temporarily disabled when there is time left on the disableTimer - when it is greater than zero.
	//float disableTimer = 0;


	// Use this for initialization
	void Start ()
	{
		
	}


	void OnTriggerEnter (Collider other)
	{
		
		if (other.tag == "Player") {

			Vector3 oldVelocity = other.gameObject.GetComponent<Rigidbody> ().velocity;
			Destroy (other.gameObject);

			Vector3 newPosition = otherPortal.transform.position + otherPortal.transform.forward;
			//otherPortal.transform.ro
			Quaternion newRotation = otherPortal.transform.rotation;
			//newRotation.x = 0;
			Quaternion identityRotation = Quaternion.identity;
			identityRotation.y = newRotation.y;
			print ("x1",newRotation.y+"");

			//print ("x rotation",otherPortal.transform.rotation.x+"");
		//	print ("x euler rotation",otherPortal.transform.rotation.eulerAngles.x+"");

			//Vector3 newEulerAngle = newRotation.eulerAngles;
			//newEulerAngle.x = 0;
			//print ("euler x", newEulerAngle.x + "");
			//print ("euler y", newEulerAngle.y + "");
		//	print ("euler z", newEulerAngle.z + "");



			//newRotation.w = 0;

			GameObject o_newPlayer = Instantiate (newPlayer,newPosition,identityRotation);
			print ("y1",identityRotation.y+"");

			Rigidbody newRigidBody = o_newPlayer.GetComponent<Rigidbody> ();
			newRigidBody.velocity = otherPortal.transform.forward * (oldVelocity.magnitude);

		
		
		
			Debug.Log ("target speed: " + oldVelocity.magnitude);
		


			/*var pos : Vector3 = currentPortal.position - transform.position;
			pos = Vector3.Reflect(pos, currentPortal.forward);
			pos = otherPortal.TransformDirection(pos);
			pos += otherPortal.position;
			myDuplicate.position = pos;*/

		
			/*Vector3 exitVelocty = otherNormal * mag;
			rb.velocity = exitVelocty;

			Vector3 exitPosition = otherPortal.transform.position + otherNormal * 2;
			playerObj.transform.position = exitPosition;*/




		}
	}

	public void print(string tag1,string message){

		Debug.Log (tag1 + ": " + message);
			
	}



}
