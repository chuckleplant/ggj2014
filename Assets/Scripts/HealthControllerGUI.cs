using UnityEngine;
using System.Collections;

public class HealthControllerGUI : MonoBehaviour {
	
	public static int LIVES = 3;
	// When you want to substract a life you are going to do the following:
	// HealthController.LIVES -= 1;
	public Texture2D healthX1;
	public Texture2D healthX2;
	public Texture2D healthX3;
	
	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {
		/*
		if (Input.GetKey("p")) {
			LIVES--;
		}
		*/
		switch(LIVES) {
		case 3:
			guiTexture.texture = healthX3;
			break;
		case 2:
			guiTexture.texture = healthX2;
			break;
		case 1:
			guiTexture.texture = healthX1;
			break;
		case 0:
			
			break;
		}
	}
}
