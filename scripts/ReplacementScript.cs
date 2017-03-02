using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplacementScript : MonoBehaviour {

	private GameObject joueur1;
	private GameObject joueur2;

	public Animator animator;

	private GameManagerScript GMS;



	// Use this for initialization
	void Start () {

		GMS = this.GetComponent<GameManagerScript> ();
		animator = GameObject.Find ("readyAnimation").GetComponent<Animator> ();
		joueur1 = GameObject.Find ("joueurBlanc");
		joueur2 = GameObject.Find ("joueurNoir");

	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void replacement(){

		GMS.counterDownDone = false;

		Vector3 newPos1 = new Vector3 (-5f, 0f, 0f);
		Vector3 newPos2 = new Vector3 (5f, 0f, 0f);
		Quaternion newRot1 = Quaternion.Euler (0f, 0f, 90f);
		Quaternion newRot2 = Quaternion.Euler (0f, 0f, -90f);

		//on replace les deux joueurs dans leur position initiale
		joueur1.transform.position = newPos1;
		joueur1.transform.rotation = newRot1;
		joueur1.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0f, 0f);

		joueur2.transform.position = newPos2;
		joueur2.transform.rotation = newRot2;
		joueur2.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0f, 0f);

		animator.Play ("ReadyAnimation", -1, 0f);

	}

}
