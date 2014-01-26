using UnityEngine;
using System.Collections;

public class Billboard : MonoBehaviour {
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update(){
		transform.LookAt (transform.position + Camera.main.transform.rotation * Vector3.back,
		                  Camera.main.transform.rotation * Vector3.up);
	}
}
