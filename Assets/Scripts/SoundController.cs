using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour {

	public float fadeInVelocity = 0.3f;
	public float fadeOutVelocity = 0.3f;

	private enum E_SoundsState {
		Sounding,
		Changing
	}

	private EyeManager.E_EyeEquiped lastEyeEquiped;
	private E_SoundsState soundsState;

	// Audios
	public AudioSource adultEyes;
	public AudioSource childEyes;
	private AudioSource actualSound;
	private AudioSource oldSound;

	void Awake()
	{
		//lastEyeEquiped = EyeManager.E_EyeEquiped.Normal;
		//soundsState = E_SoundsState.Sounding;
		lastEyeEquiped = EyeManager.E_EyeEquiped.Normal;

		// Starting sounds
		oldSound = childEyes;
		actualSound = adultEyes;
		adultEyes.Play();
		adultEyes.volume = 0f;
	}

	void FixedUpdate()
	{
		if (lastEyeEquiped != EyeManager.eyeState) {
			Debug.Log ("Cambiamos de ojo");
			// Acabamos de cambiar
			switch (EyeManager.eyeState) {	// Switch new sound
			case EyeManager.E_EyeEquiped.Normal:
				adultEyes.Play();
				adultEyes.volume = 0f;
				oldSound = actualSound;
				actualSound = adultEyes;
				break;
			case EyeManager.E_EyeEquiped.Kid:
				childEyes.Play();
				childEyes.volume = 0f;
				oldSound = actualSound;
				actualSound = childEyes;
				break;
			default: break;
			}

			lastEyeEquiped = EyeManager.eyeState;
			//soundsState = E_SoundsState.Changing;
		}

		// Si estamos cambiando, FadeIn y FadeOut
		//if (soundsState == E_SoundsState.Changing) {
			FadeInSound(actualSound);
			FadeOutSound(oldSound);
		//}

	}

	void FadeInSound(AudioSource sound)
	{
		if (sound.volume < 1f) {
			sound.volume += fadeInVelocity*Time.deltaTime;
		}
	}

	void FadeOutSound(AudioSource sound)
	{
		if (sound.volume > 0f) {
			sound.volume -= fadeOutVelocity*Time.deltaTime;
		}
		if (sound.volume <= 0f) sound.Pause();
	}


}
