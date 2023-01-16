using UnityEngine;

using UnityEngine.UI;

using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float jumpHeight = 7f;
	public bool isGrounded;
	public float speed;
	public Text countText;
	public Text winText;

	private Rigidbody ballRb;
	private int count;

	void Start ()
	{
		ballRb = GetComponent<Rigidbody>();

		count = 0;

		SetCountText ();

		winText.text = "";
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		ballRb.AddForce (movement * speed);
		
		 if (isGrounded)
    {
       if (Input.GetButtonDown("Jump"))
       {
       ballRb.AddForce(Vector3.up * jumpHeight);
       }
    }
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

	void SetCountText()
	{
		countText.text = "Count: " + count.ToString ();

		if (count >= 12) 
		{
			winText.text = "You Win!";
		}
	}
 
 void OnCollisionEnter(Collision other)
 {
     if (other.gameObject.tag == "Ground")
     {
         isGrounded = true;
     }
 }
 
 void OnCollisionExit(Collision other)
 {
     if (other.gameObject.tag == "Ground")
     {
         isGrounded = false;
     }
 }

}