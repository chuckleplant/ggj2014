using UnityEngine;
using System.Collections;

public class PunchControl : MonoBehaviour {
	private int lastLiveCount;
	public AudioSource source;

	// Use this for initialization
	void Start () {
		lastLiveCount = 3;
	}
	
	// Update is called once per frame
	void Update () {
		if (lastLiveCount != HealthControllerGUI.LIVES) {
			source.Play();
			lastLiveCount = HealthControllerGUI.LIVES;
		}
	}
}
