using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

	public PlayerController Player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Player.horizontalMove 	= Input.GetAxis("Horizontal");
		Player.verticalMove 	= Input.GetAxis("Vertical");
	}
}
