using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementManetteSCript : MonoBehaviour {

	void Awake(){
		string[] names = Input.GetJoystickNames();
		Debug.Log ("Connected Joysticks ");
		for (int i = 0; i < names.Length; i++) {
			Debug.Log("Joystick" + (i+1) + " = " + names[i]);
		
		}

	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		DebugJoystickButtonPressed ();
	}


	void DebugJoystickButtonPressed(){
		int joyNum = 1;
		int buttonNum = 0;
		int keyCode = 350;

		for (int i = 0; i < 60; i++) {
			if (Input.GetKeyDown ("" + keyCode + i))
				Debug.Log ("Pressed! Joystick " + joyNum + " Button " + buttonNum + " @ " + Time.time);

			buttonNum++;
			if(buttonNum == 20){
				buttonNum = 0;
				joyNum++;
			}
		}
	}
}
