using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockwaveOnCollision : MonoBehaviour {
	public ParticleSystem effet;
	public float shakeAmt = 0.1f;
	public float delay = 0.1f;

	ShakeCamera shake;


	// Use this for initialization
	void Start () {
		shake = GameObject.Find ("Script").GetComponent<ShakeCamera>();
	}

	void OnEnable () {
		Player.OnPlayerCollisionWithPlayer += Shockwave;
		Player.OnPlayerCollisionWithWall += Shockwave;
	}

	void OnDisable () {
		Player.OnPlayerCollisionWithPlayer -= Shockwave;
		Player.OnPlayerCollisionWithWall -= Shockwave;
	}

	void Shockwave (Collision2D collision){
		Vector2 contactPoint = collision.contacts [0].point;
		float magnitude = collision.relativeVelocity.magnitude;
		// Particules
		var em = effet.emission;
		em.SetBursts (new ParticleSystem.Burst[]{new ParticleSystem.Burst (0f, (short)(magnitude*5))});
		Instantiate (effet, contactPoint, Quaternion.identity);
		// Camera Shake
		shake.shakeAmt = magnitude / 700;
		shake.delay = delay;
		shake.Play ();
	}

}
