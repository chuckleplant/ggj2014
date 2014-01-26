using UnityEngine;
using System.Collections;

public class TreeController : MonoBehaviour {

	public Sprite treeNormal;
	public Sprite treeKid;
	private SpriteRenderer treeSpriteRenderer;

	// Use this for initialization
	void Start () {
		treeSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		switch (EyeManager.eyeState) {
		case EyeManager.E_EyeEquiped.Normal:
			treeSpriteRenderer.sprite = treeNormal;
			break;
		case EyeManager.E_EyeEquiped.Kid:
			treeSpriteRenderer.sprite = treeKid;
			break;
		default:
			treeSpriteRenderer.sprite = treeKid;
			break;
		}
	}

	void OnCollisionEnter(Collision collision) {
		if (EyeManager.eyeState == EyeManager.E_EyeEquiped.Kid) {
			--HealthControllerGUI.LIVES;
		}
	}
}
