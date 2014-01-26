using UnityEngine;
using System.Collections;

public class EyeController1 : MonoBehaviour {
	
	public Texture2D eyeOn;
	public Texture2D eyeOff;

	// Use this for initialization
	void Start () {
		float aspectRatio = 1.0f;

		int screenHeight = Screen.height;
		int screenWidth = Screen.width;
		float guiTextureWidth = screenWidth/5.0f;
		float guiTextureHeight = (screenWidth/5.0f)/aspectRatio;

		//Debug.Log(screenWidth.ToString() + " " + guiTextureWidth/2);
		//guiTexture.pixelInset = new Rect(screenWidth-200f, screenHeight-(40f+20f), screenWidth/5.0f, (screenWidth/5.0f)/aspectRatio);
		//guiTexture.pixelInset = new Rect(screenWidth-(guiTextureWidth/2f), screenHeight-(guiTextureHeight/2f+40f), guiTextureWidth, guiTextureHeight);
	}
	
	// Update is called once per frame
	void Update () {
		switch (EyeManager.eyeState) {
		case EyeManager.E_EyeEquiped.Normal:
			guiTexture.texture = eyeOn;
			break;
		default:
			guiTexture.texture = eyeOff;
			break;
		}
	}
}
