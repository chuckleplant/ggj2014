using UnityEngine;
using System.Collections;

public class EyeController2 : MonoBehaviour {

	public Texture2D eyeOn;
	public Texture2D eyeOff;
	
	// Use this for initialization
	void Start () {
		int screenHeight = Screen.height;
		int screenWidth = Screen.width;
		int guiTextureWidth = guiTexture.texture.width;
		int guiTextureHeight = guiTexture.texture.height;
		
		float aspectRatio = guiTextureWidth/guiTextureHeight;
		
		//Debug.Log(screenWidth.ToString() + " " + screenHeight.ToString());
		//guiTexture.pixelInset = new Rect(screenWidth-300f, screenHeight-(40f+60f), 128f, 128f);
	}
	
	// Update is called once per frame
	void Update () {
		switch (EyeManager.eyeState) {
		case EyeManager.E_EyeEquiped.Kid:
			guiTexture.texture = eyeOn;
			break;
		default:
			guiTexture.texture = eyeOff;
			break;
		}
	}
}