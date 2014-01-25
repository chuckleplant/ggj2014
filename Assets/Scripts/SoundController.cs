using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour {

	public float fadeInVelocity = 0.1f;
	public float fadeOutVelocity = 0.1f;

	private enum E_SoundsState {
		Sounding,
		Changing
	}

	private EyeManager.E_EyeEquiped lastEyeEquiped;
	private E_SoundsState soundsState;

	// Audios
	public AudioSource childEyes;

	void Awake()
	{
		lastEyeEquiped = EyeManager.E_EyeEquiped.Normal;
		soundsState = E_SoundsState.Sounding;

		// TODO: Hacer que este sonando el sonido de ojo normal
	}

	void FixedUpdate()
	{
		if (lastEyeEquiped != EyeManager.eyeState) {
			soundsState = E_SoundsState.Changing;
		}

		// IMPLEMENTAR THIS SHIT

		// SI ACABAMOS DE CAMBIAR
		// Cambiar el sonido antiguo y actual

		// SI ESTAMOS CAMBIANDO
		// Fade Out del sonido antiguo
		// Fade In del sonido nuevo

		// SI NO ESTAMOS CAMBIANDO
		// Seguir sonando lo mismo a toda mecha, no fades






			/*FadeOutAllSounds();

			lastEyeEquiped = EyeManager.eyeState;

			switch (lastEyeEquiped) {
			case EyeManager.E_EyeEquiped.Kid:
				FadeInSound(childEyes);
				childEyes.Play();
				break;
			default: break;

		}*/
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
	}


}
