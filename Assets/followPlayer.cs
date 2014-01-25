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
		transform.position = new Vector3 (player.transform.position.x, lockedY, player.transform.position.z - zoffset);

	}
}
