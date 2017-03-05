using UnityEngine;
using System.Collections;

public class SoundEffectHelper : MonoBehaviour {

	public static SoundEffectHelper Instance;

	public AudioClip explosionSound;
	public AudioClip maguichSound;
	public AudioClip bumpSound;
	public AudioClip clashSound;

	void Awake(){

		//Singleton
		if (Instance != null) {
			Debug.LogError ("Multiple instances of SoundEffectsHelper!");
		}
		Instance = this;
	}

	public void MakeExplosionSound(Vector3 pos)
	{
		MakeSound(explosionSound, pos);
	}

	public void MakeMaguichSound(Vector3 pos)
	{
		MakeSound(maguichSound, pos);
	}

	public void MakeBumpSound(Vector3 pos)
	{
		MakeSound(bumpSound, pos);
	}

	public void MakeClashSound(Vector3 pos)
	{
		MakeSound(clashSound, pos);
	}



	private void MakeSound(AudioClip originalClip, Vector3 pos){
		AudioSource.PlayClipAtPoint (originalClip, pos);
	}


}
