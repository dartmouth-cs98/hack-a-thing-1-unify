using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;

	public float speed;
	private int count;
	public Text countText;
	public Text winText;

	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText ();
		winText.text = "";

	
	}
	void FixedUpdate()
	{
		float moveHorizantal = Input.GetAxis ("Horizontal");
		float MoveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizantal, 0.0f, MoveVertical);

		rb.AddForce (movement * speed);


	
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Pick Up"))
		{
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();
		}
	}


	void SetCountText ()
	{
		countText.text = "Count: " + count.ToString ();
		if (count >= 11) 
		{
			winText.text = "You win!!!";
		}
	}

}