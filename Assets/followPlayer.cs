using UnityEngine;
using System.Collections;

public class followPlayer : MonoBehaviour {
	public GameObject player;
	public float lockedY;
	public float zoffset;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (player == null) {
			switch(EyeManager.eyeState) {
			case EyeManager.E_EyeEquiped.Normal:
				player = GameObject.FindWithTag("PlayerNormal");
				break;
			case EyeManager.E_EyeEquiped.Kid:
				player = GameObject.FindWithTag("PlayerKid");
				break;
			}
		}

		transform.position = new Vector3 (player.transform.position.x, lockedY, player.transform.position.z - zoffset);
	}
}
