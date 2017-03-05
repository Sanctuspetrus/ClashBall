using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyedEffect : MonoBehaviour {

	public ParticleSystem effect;

	void OnEnable() {
		Player.OnPlayerDeath += Explode;
	}

	void OnDisable() {
		Player.OnPlayerDeath -= Explode;
	}

	void Explode(GameObject player){
		Instantiate (effect, player.transform);
	}
}
