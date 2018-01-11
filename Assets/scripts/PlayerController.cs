using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;

	public float speed;

	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
	
	}
	void FixedUpdate()
	{
		float moveHorizantal = Input.GetAxis ("Horizontal");
		float MoveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizantal, 0.0f, MoveVertical);

		rb.AddForce (movement * speed);


	
	}
}
