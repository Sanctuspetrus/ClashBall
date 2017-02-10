using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionColision : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//On vérifie si la colision est détectée à l'arriere du joueur
	void OnCollisionEnter2D(Collision2D col){
		foreach (ContactPoint2D contact in col.contacts) {
			Debug.Log (contact.point);

			Vector2 direction = new Vector2 ();
			direction.x = transform.position.x - contact.point.x; 
			direction.y = transform.position.y - contact.point.y; 

			Vector2 angle = new Vector2(Mathf.Cos(transform.eulerAngles.z * Mathf.Deg2Rad), Mathf.Sin(transform.eulerAngles.z * Mathf.Deg2Rad));
			float angle2 = Vector2.Angle (angle, direction);

			Vector3 cross = Vector3.Cross(angle, direction);
			if (cross.z > 0)
				angle2 = 360-angle2;

			//Debug.Log ("angle : " + angle2 + " || rotation : " + direction + "  || tranfo : " + transform.eulerAngles.z);
			if (angle2 > 180) {
				Debug.Log ("zertghyjuk");
				SoundEffectHelper.Instance.MakeMaguichSound (transform.position);
			}



		}

	}
}
