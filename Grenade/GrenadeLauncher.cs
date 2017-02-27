using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeLauncher : MonoBehaviour {
	public GameObject grenade;

	private bool mouseButtonHold = false;
	private Rigidbody2D grenadeRB;
	private Vector2 deplacement;

	public float miniPuissance = 0;
	public float maxPuissance = 250;
	public float pasPuissance = 500;
	public float coeffPuissance = 0;

	// Use this for initialization
	void Start () {
		coeffPuissance = miniPuissance;
		deplacement = new Vector2 ();
		grenadeRB = grenade.GetComponent<Rigidbody2D>();

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			mouseButtonHold = true;
			mouseDown ();
		}
		if (Input.GetMouseButtonUp (0)) {
			mouseUp();
			mouseButtonHold = false;
		}
		if (mouseButtonHold) {
			mouseDown ();
		}
	}

	void OnCollisionExit2D (Collision2D collision){
		if(collision.gameObject.tag == "noire"){

		}
	}

	void launch(Vector2 destination, float puissance){
		// Récupération de la position du lanceur sur un plan 2d
		Vector2 pos = transform.position;
		// Calcule de la trajectoire de la grenade
		Vector2 trajet = calcTrajet (pos, destination);
		// On rend le trajet virtuellement infini pour en faire une trajectoire
		trajet.Scale (new Vector2 (100000, 100000));
		// On tronque la trajectoire pour en faire l'équivalent d'un vecteur de vitesse
		deplacement = Vector3.ClampMagnitude (trajet, puissance);
		// On applique la vitesse à la grenade
		grenadeRB.velocity = deplacement;

		//rotation de l'object dans la direction du lancer
		float angle = Mathf.Atan2 (trajet.y, trajet.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

		// Instanciation de la grenade
		GameObject gre = Instantiate(grenade, pos, transform.rotation) as GameObject;
		Transform ori = gre.transform.parent;
		gre.transform.parent = transform;
		gre.transform.Translate (new Vector3 (0.7f,0.14f,0));
		gre.GetComponent<Rigidbody2D> ().velocity = deplacement;
		gre.transform.parent = ori;

	}

	Vector2 calcTrajet(Vector2 depart, Vector2 arrive){
		return arrive - depart;
	}

	void mouseDown(){
		if (coeffPuissance < maxPuissance) {
			coeffPuissance += pasPuissance * Time.deltaTime;
		}
	}

	void mouseUp(){
		Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		launch (pos, coeffPuissance);
		coeffPuissance = miniPuissance;
	}

}
