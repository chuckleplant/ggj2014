using UnityEngine;
using System.Collections;

public class ChangePlayerController : MonoBehaviour {

	//Animators
	public RuntimeAnimatorController normalPlayerAnimatorController;
	public RuntimeAnimatorController kidPlayerAnimatorController;

	//Sprites
	public Sprite normalPlayerSprite; 
	public Sprite kidPlayerSprite;


	//Animator
	private Animator playerAnimator;

	//Sprite Renderer
	private SpriteRenderer playerSpriteRenderer;

	// Use this for initialization
	void Start () {
		playerAnimator = gameObject.GetComponent<Animator>();
		playerSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		switch (EyeManager.eyeState) {
		case EyeManager.E_EyeEquiped.Normal:
			playerSpriteRenderer.sprite = normalPlayerSprite; 
			playerAnimator.runtimeAnimatorController = normalPlayerAnimatorController;
			break;
		case EyeManager.E_EyeEquiped.Kid:
			playerSpriteRenderer.sprite = kidPlayerSprite;
			playerAnimator.runtimeAnimatorController = kidPlayerAnimatorController;
			break;
		default:
			//playerSpriteRenderer.sprite = normalPlayerSprite; 
			//playerAnimator.runtimeAnimatorController = normalPlayerAnimatorController;
			break;
	}
	}
}