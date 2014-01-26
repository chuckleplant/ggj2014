using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

	public PlayerController Player;

	// Use this for initialization
	void Start () {
		GameObject go = GameObject.FindWithTag("PlayerNormal");
		Player = (PlayerController)go.GetComponent("PlayerController");
	}
	
	// Update is called once per frame
	void Update () {
		if (Player == null) {
			GameObject go;
			switch(EyeManager.eyeState) {
			case EyeManager.E_EyeEquiped.Normal:
				go = GameObject.FindWithTag("PlayerNormal");
				Player = (PlayerController)go.GetComponent("PlayerController");
				break;
			case EyeManager.E_EyeEquiped.Kid:
				go = GameObject.FindWithTag("PlayerKid");
				Player = (PlayerController)go.GetComponent("PlayerController");
				break;
			}
		} 

		Player.horizontalMove 	= Input.GetAxis("Horizontal");
		Player.verticalMove 	= Input.GetAxis("Vertical");
	}
}
