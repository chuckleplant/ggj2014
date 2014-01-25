using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float 	maxSpeed = 10f;
	bool			facingRight = true;
	public Camera m_Camera;

	public Animator anim;

	// Use this for initialization
	void Start () {
		//anim = GameObject.Find ("Idle").animation;
		//anim = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float horizontalMove 	= Input.GetAxis("Horizontal");
		float verticalMove 		= Input.GetAxis("Vertical");

		rigidbody.velocity = new Vector3(horizontalMove, 0f, verticalMove) * maxSpeed;

		//anim.SetFloat("Speed", rigidbody.velocity.magnitude);

		if (verticalMove > 0 && !facingRight)
			FlipVertical();
		else if (verticalMove < 0 && facingRight)
			FlipVertical();
	}



	void FlipVertical()
	{
		facingRight 			= !facingRight;
		Vector3 theScale 		= transform.localScale;
		theScale.z				*= -1;
		transform.localScale 	= theScale;
	}
}
