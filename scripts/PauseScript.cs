using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour {

	public bool pause;

	// Use this for initialization
	void Start () {
		pause = false;
	}
	
	// Update is called once per frame
	void Update () {


		if(Input.GetKeyDown(KeyCode.Escape)){
			Debug.Log ("ECHAP");
			action();
		}
		if (pause) {
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
		}
	}


	void OnGUI()
	{
		if (pause) {
			const int buttonWidth = 84;
			const int buttonHeight = 60;

			// Affiche un bouton pour démarrer la partie
			if (
				GUI.Button (
				// Centré en x, 2/3 en y
					new Rect (
						Screen.width / 2 - (buttonWidth / 2),
						(2 * Screen.height / 3) - (buttonHeight / 2),
						buttonWidth,
						buttonHeight
					),
					"RESUME!"
				)) {
				//on relance le jeu
				action ();
			}
		}
	}

	//fonction appelé lors de la pression du bouton echap, ou du bouton de l'objet 
	public void action(){
		pause = !pause;
	}
}
