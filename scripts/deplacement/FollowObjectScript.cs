using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObjectScript : MonoBehaviour {

	public Transform curseur;

	/*// Use this for initialization
	void Start () {
		
	}*/
	
	// Update is called once per frame
	void Update () {

		Vector2 trajet = curseur.position - transform.position;
		Debug.Log (trajet.magnitude);
		if (trajet.magnitude > 0.1) { // Pour éviter la zone d'incertitude quand le curseur est au repos
			float angle = Mathf.Atan2 (trajet.y, trajet.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.Euler (new Vector3 (0, 0, angle - 90));
		}
	}
}
