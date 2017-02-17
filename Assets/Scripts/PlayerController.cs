using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed;
	private Rigidbody rb;
	private int count;

	public Text countText;
	public Text WinText;

	void Start(){
		rb = GetComponent<Rigidbody> ();
		count = 0;
		setCountText ();
		WinText.text = "";

	}

	void FixedUpdate(){

		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");


		Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);
		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other) {
		//Destroy(other.gameObject);
		if (other.CompareTag ("Pick Up")) {
			other.gameObject.SetActive (false);
			count++;
			setCountText ();
		}
	}

	void setCountText(){
		countText.text = "Count: " + count;

		if (count >= 13) {
			WinText.text = "You Win!";	
		}
			
	}
}
