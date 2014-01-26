using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class TestRenderImage : MonoBehaviour {
	
	#region Variables
	public Shader curShader;
	private float grayScaleAmount;
	private Material curMaterial;
	#endregion
	
	#region Properties
	Material material
	{
		get
		{
			if(curMaterial == null)
			{
				curMaterial = new Material(curShader);
				curMaterial.hideFlags = HideFlags.HideAndDontSave;
			}
			return curMaterial;
		}
	}
	#endregion
	
	// Use this for initialization
	void Start () {
		grayScaleAmount = 0.5f;
		if(!SystemInfo.supportsImageEffects)
		{
			enabled = false;
			return;
		}
		
		if(!curShader && !curShader.isSupported)
		{
			enabled = false;
		}
	}

	void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
	{
		if (curShader != null)
		{
			material.SetFloat("_LuminosityAmount", grayScaleAmount);
			Graphics.Blit(sourceTexture, destTexture, material);
		}
		else
		{
			Graphics.Blit(sourceTexture, destTexture);
		}
	}

	// Update is called once per frame
	void Update () {
		float increment = 0.85f;
		if (EyeManager.eyeState == EyeManager.E_EyeEquiped.Normal) {
			grayScaleAmount += increment * Time.deltaTime;
			if (grayScaleAmount > 0.85f) grayScaleAmount = 0.85f;
		}
		else {
			grayScaleAmount -= increment * Time.deltaTime;
			if (grayScaleAmount < 0.0f) grayScaleAmount = 0.0f;
		}		
	}

	void OnDisable() 
	{
		if (curMaterial)
		{
			DestroyImmediate(curMaterial);
		}
	}
}
