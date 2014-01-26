using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float maxSpeed = 10f;
	public bool facingRight = true;
	public bool facingUp = false;

	public Animator anim;

	public float horizontalMove;
	public float verticalMove;

	// Use this for initialization
	void Start () {
		//anim = GameObject.Find ("Idle").animation;
		anim = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		rigidbody.velocity = new Vector3(horizontalMove, 0f, verticalMove) * maxSpeed;

		if (horizontalMove > 0 && !facingRight) {
			FlipHorizontal();
		}else if (horizontalMove < 0 && facingRight) {
			FlipHorizontal ();
		}

		if (verticalMove > 0 && !facingUp) {
			facingUp = !facingUp;
		}else if (verticalMove < 0 && facingUp) {
			facingUp = !facingUp;
		}

		//animSets
		anim.SetFloat ("horizontalSpeed", Mathf.Abs(horizontalMove));
		anim.SetFloat ("verticalSpeed", Mathf.Abs(verticalMove));
		anim.SetBool ("facingUp", facingUp);
	}



	void FlipHorizontal()
	{
		facingRight 			= !facingRight;
		Vector3 theScale 		= transform.localScale;
		theScale.x				*= -1;
		transform.localScale 	= theScale;

	}
}
