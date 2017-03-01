using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockwaveOnCollision : MonoBehaviour {
	public ParticleSystem effet;
	public float shakeAmt = 0.1f;
	public float delay = 0.1f;

	Camera mainCamera;
	Vector3 originalCameraPosition;


	// Use this for initialization
	void Start () {
		mainCamera = Camera.main;
		originalCameraPosition = mainCamera.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionExit2D (Collision2D collision){
		Vector2 contactPoint = collision.contacts [0].point;
		float magnitude = collision.relativeVelocity.magnitude;
		shakeAmt = magnitude / 1000;
		var em = effet.emission;
		em.SetBursts (new ParticleSystem.Burst[]{new ParticleSystem.Burst (0f, (short)(magnitude*10))});
		Instantiate (effet, contactPoint, Quaternion.identity);
		CameraShake ();
	}

	void CameraShake(){
		InvokeRepeating("StartShake", 0, 0.01f);
		Invoke("StopShaking", delay);
	}

	void StartShake()
	{
		if(shakeAmt>0)
		{
			Vector3 pp = mainCamera.transform.position;
			float quakeAmt = Random.value*shakeAmt*2 - shakeAmt;
			pp.x+= quakeAmt; // can also add to x and/or z
			quakeAmt = Random.value*shakeAmt*2 - shakeAmt;
			pp.y+= quakeAmt; // can also add to x and/or z
			mainCamera.transform.position = pp;
		}
	}

	void StopShaking()
	{
		CancelInvoke("StartShake");
		mainCamera.transform.position = originalCameraPosition;
	}
}
