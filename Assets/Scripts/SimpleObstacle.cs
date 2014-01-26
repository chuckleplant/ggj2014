using UnityEngine;
using System.Collections;

public class SimpleObstacle : MonoBehaviour {
	
	private EyeManager.E_EyeEquiped currentEyeState;
	public Sprite kidObstacle;
	public Sprite normalObstacle;
	private SpriteRenderer currentObstacleRenderer;
	// Use this for initialization
	void Start () {
		currentObstacleRenderer = gameObject.GetComponent<SpriteRenderer>();
		currentEyeState = EyeManager.E_EyeEquiped.Normal;//EyeManager.E_EyeEquiped.Blind;
		currentObstacleRenderer.sprite = normalObstacle;
	}
	
	// Update is called once per frame
	void Update () {
		// check if we have to change the state
		if (currentEyeState != EyeManager.eyeState) {
			switch (EyeManager.eyeState) {
			case EyeManager.E_EyeEquiped.Blind:
			case EyeManager.E_EyeEquiped.Normal:
				UpdateBlindNormalState();
				break;
			case EyeManager.E_EyeEquiped.Kid:
				UpdateKidState();
				break;
			default:
				Debug.Log("The game object: " + ToString() + " is in an invalid state.");
				Debug.Break();
				break;
			}
			
			// update the current eye's state
			currentEyeState = EyeManager.eyeState;
		}
	}
	
	void UpdateBlindNormalState() {
		transform.collider.isTrigger = false;
		currentObstacleRenderer.sprite = normalObstacle;
	}
	
	void UpdateKidState() {
		transform.collider.isTrigger = true;
		currentObstacleRenderer.sprite = kidObstacle;
	}
}