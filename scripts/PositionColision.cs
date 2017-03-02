using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PositionColision : MonoBehaviour {

	public int angleVulnerable = 90;
	public int score = 0;

	public Text scoreText;

	private ReplacementScript rep;

	// Use this for initialization
	void Start () {

		rep = GameObject.Find ("Script").GetComponent<ReplacementScript> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//On vérifie si la colision est détectée à l'arriere du joueur
	void OnCollisionEnter2D(Collision2D col){

		if (col.gameObject.tag == "Player") {
			foreach (ContactPoint2D contact in col.contacts) {

				Vector2 direction = new Vector2 ();
				direction.x = transform.position.x - contact.point.x; 
				direction.y = transform.position.y - contact.point.y; 

				Vector2 angle = new Vector2 (Mathf.Cos (transform.eulerAngles.z * Mathf.Deg2Rad), Mathf.Sin (transform.eulerAngles.z * Mathf.Deg2Rad));
				float angle2 = Vector2.Angle (angle, direction);

				Vector3 cross = Vector3.Cross (angle, direction);
				if (cross.z > 0)
					angle2 = 360 - angle2;

				//variateur est égale à la valeur des 2 zones invulnérables se trouvant derriere le joueur (variant entre 0 et 180)
				float variateur = (180 - angleVulnerable) / 2; 

				if (angle2 > (180 + variateur) && angle2 < (180 + variateur + angleVulnerable)) {
					SoundEffectHelper.Instance.MakeMaguichSound (transform.position);
					score++;
					scoreText.text = score.ToString ();
					rep.replacement ();
				}
			}
		}
	}
}
