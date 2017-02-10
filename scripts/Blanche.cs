using UnityEngine;
using System.Collections;

public class Blanche : MonoBehaviour {
	
	private bool mouseButtonHold = false;
	private Rigidbody2D rb;
	private Vector2 deplacement;

	public float miniPuissance = 0;
	public float maxPuissance = 250;
	public float pasPuissance = 500;
	public float coeffPuissance = 0;

	// Use this for initialization
	void Start () {
		coeffPuissance = miniPuissance;
		deplacement = new Vector2 ();
		rb = GetComponent<Rigidbody2D>();
	
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

	void dash(Vector2 destination, float puissance){
		// Récupération de la position de l'objet sur un plan 2d
		Vector2 pos = transform.position;
		// Calcule de la trajectoire de l'objet
		Vector2 trajet = calcTrajet (pos, destination);
		// On rend le trajet virtuellement infini pour en faire une trajectoire
		trajet.Scale (new Vector2 (100000, 100000));
		// On tronque la trajectoire pour en faire l'équivalent d'un vecteur de vitesse
		deplacement = Vector3.ClampMagnitude (trajet, puissance);
		// On applique la vitesse à l'objet
		rb.velocity = deplacement;

		//rotation de l'object dans la direciton du dash
		float angle = Mathf.Atan2 (trajet.y, trajet.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle-90));

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
		dash (pos, coeffPuissance);
		coeffPuissance = miniPuissance;
	}

}
