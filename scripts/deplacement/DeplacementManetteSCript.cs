using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementManetteSCript : MonoBehaviour {


	void Awake(){
		string[] names = Input.GetJoystickNames();
		Debug.Log ("Connoected Joysticks ");
		for (int i = 0; i < names.Length; i++) {
			Debug.Log("Joystick" + (i+1) + " = " + names[i]);
		
		}

	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		Component parent;
		if ((parent = this.GetComponentInParent<Noire>()) == null) {
			Debug.Log ("ERREUR GET PARENT");
		} else {
			
			Vector3 positionCurseur = getAxisDirection () * 2;
			positionCurseur.x += parent.gameObject.transform.position.x;
			positionCurseur.y += parent.gameObject.transform.position.y;
			positionCurseur.z += parent.gameObject.transform.position.z + 1;

			//Debug.Log (positionCurseur);

			gameObject.transform.position = positionCurseur;
		}

	}


	void DebugJoystickButtonPressed(){
		int joyNum = 1;
		int buttonNum = 0;
		int keyCode = 0;

		for (int i = 0; i < 600; i++) {
			if (Input.GetKeyDown ("" + i))
				Debug.Log ("Pressed! Joystick " + joyNum + " Button " + buttonNum + " @ " + Time.time);

			buttonNum++;
			if(buttonNum == 20){
				buttonNum = 0;
				joyNum++;
			}
		}
	}

	Vector3 getAxisDirection(){
		return new Vector3 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"), 0);
	}
}
