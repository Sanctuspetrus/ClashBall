using UnityEngine;
using System.Collections;

public class ShakeCamera : MonoBehaviour
{
	Vector3 originalCameraPosition;

	public float shakeAmt = 0.5f;
	public float delay = 0.1f;

	public Camera mainCamera;

	public void Start() 
	{
		mainCamera = Camera.main;
		originalCameraPosition = mainCamera.transform.position;
		InvokeRepeating("CameraShake", 0, .001f);
		Invoke("StopShaking", delay);
		Destroy (gameObject, delay+1);
	}

	public void Update() 
	{
		
	}

	void CameraShake()
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
		CancelInvoke("CameraShake");
		mainCamera.transform.position = originalCameraPosition;
	}
}

