using UnityEngine;
using System.Collections;

public class bordureHaute : MonoBehaviour {
	Vector3 hg;
	Vector3 hd;
	public float width = 0.5F;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float dist = Camera.main.transform.position.z;
		hd = Camera.main.ViewportToWorldPoint(new Vector3(1,1,-dist));
		hg = Camera.main.ViewportToWorldPoint(new Vector3(0,1,-dist));
		transform.position = hg;
		Vector3 dimensions = hg - hd;
		Vector3 position = dimensions;
		position.Scale (new Vector3 (0.5F, 0.5F, 0.5F));
		transform.Translate (position);
		dimensions.y = width;
		transform.localScale = dimensions;
	}
}
