using UnityEngine;
using System.Collections;

public class GrenadeMouvement : MonoBehaviour {
	public float puissance = 10;
	public Vector2 force;
	public Vector2 deplacement;
	public Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		deplacement = new Vector2 ();
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)  == true) {
			force = objectToMouseVect ();
			force.Scale (new Vector2 (100000, 100000));
			deplacement = Vector3.ClampMagnitude (force, puissance);
			rb.velocity = deplacement;
		}

	}

	Vector2 mousePos(){
		Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		return pos;
	}

	void moveToMouse(){
		Vector3 pos = Input.mousePosition;
		pos.z = transform.position.z - Camera.main.transform.position.z;
		transform.position = Camera.main.ScreenToWorldPoint(pos);
	}



	Vector2 objectToMouseVect(){
		Vector2 pos = transform.position;
		return mousePos () - pos;
	}
}
