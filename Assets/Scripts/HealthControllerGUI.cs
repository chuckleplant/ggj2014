using UnityEngine;
using System.Collections;

public class HealthControllerGUI : MonoBehaviour {
	
	public static int LIVES;
	// When you want to substract a life you are going to do the following:
	// HealthController.LIVES -= 1;
	public Texture2D healthX1;
	public Texture2D healthX2;
	public Texture2D healthX3;

	// Use this for initialization
	void Start () {
		LIVES = 3;
		int screenHeight = Screen.height;
		int screenWidth = Screen.width;
		int guiTextureWidth = guiTexture.texture.width;
		int guiTextureHeight = guiTexture.texture.height;

		float aspectRatio = guiTextureWidth/guiTextureHeight;

		//Debug.Log(screenWidth.ToString() + " " + screenHeight.ToString());
		//guiTexture.pixelInset = new Rect(-screenWidth/2+40, screenHeight/2-(guiTextureHeight+60), screenWidth/5.0f, (screenWidth/5.0f)/aspectRatio);
		//guiTexture.pixelInset = new Rect(40f, screenHeight-(40f+40f), screenWidth/5.0f, (screenWidth/5.0f)/aspectRatio);

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown("p")) {
			LIVES--;
		}
		else if (Input.GetKeyDown("l")) {
			LIVES++;
		}

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

		if (LIVES == 0)
			Application.LoadLevel (Application.loadedLevel);
	}
}
