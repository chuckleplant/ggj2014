using UnityEngine;
using System.Collections;

public class Billboard : MonoBehaviour {
	public Camera m_Camera;
	// Use this for initialization
	void Start () {
		m_Camera = Camera.main;
	}
	
	// Update is called once per frame
	void Update(){
		transform.LookAt (transform.position + m_Camera.transform.rotation * Vector3.back,
	         m_Camera.transform.rotation * Vector3.up);
	}
}
