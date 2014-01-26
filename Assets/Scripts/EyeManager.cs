using UnityEngine;
using System.Collections;

public class EyeManager : MonoBehaviour {

	public enum E_EyeEquiped {
		Blind,
		Normal,
		Kid,
		Invalid
	};

	public static E_EyeEquiped 	eyeState;
	

	// Use this for initialization
	void Start () {
		eyeState = E_EyeEquiped.Normal;
	}
	
	// Update is called once per frame
	void Update () {
		//check if we want to change the eye state
		if (Input.GetButtonDown("EyeBlind"))
			eyeState = E_EyeEquiped.Blind;

		else if (Input.GetButtonDown("EyeNormal"))
			eyeState = E_EyeEquiped.Normal;

		else if (Input.GetButtonDown("EyeKid"))
			eyeState = E_EyeEquiped.Kid;
	}
}
