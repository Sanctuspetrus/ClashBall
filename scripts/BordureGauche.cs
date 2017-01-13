using UnityEngine;
using System.Collections;

public class BordureGauche : MonoBehaviour {
	Vector3 hg;
	Vector3 bg;
	public float width = 0.5F;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float dist = Camera.main.transform.position.z;
		hg = Camera.main.ViewportToWorldPoint(new Vector3(0,1,-dist));
		bg = Camera.main.ViewportToWorldPoint(new Vector3(0,0,-dist));
		transform.position = bg;
		Vector3 dimensions = bg - hg;
		Vector3 position = dimensions;
		position.Scale (new Vector3 (0.5F, 0.5F, 0.5F));
		transform.Translate (position);
		dimensions.x = width;
		transform.localScale = dimensions;
	}
}
