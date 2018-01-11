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
	public float jump_height;
	private float jump;
	private float yvelocity;
	public Text GameOver;
	private bool Loss;



	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText ();
		winText.text = "";
		GameOver.text = "";
		Loss = false;


	
	}
	void FixedUpdate()
	{
		float moveHorizantal = Input.GetAxis ("Horizontal");
		float MoveVertical = Input.GetAxis ("Vertical");
		bool space_down = Input.GetKeyDown ("space");
		yvelocity = rb.velocity.y;
		if (space_down == true && yvelocity == 0 ) {
			jump = jump_height;
		} else {
			jump = 0.0f;
		}

		print (jump);
		Vector3 movement = new Vector3 (moveHorizantal, jump, MoveVertical);

		rb.AddForce (movement * speed);
		jump = 0;

	
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("o"))
		{
			GameOver.text = "GAME OVER";
		}
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
		if (count >= 18) 
		{
			winText.text = "YOU WIN!!!";
		}
	}

}