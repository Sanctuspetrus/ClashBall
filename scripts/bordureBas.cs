using UnityEngine;
using System.Collections;

public class bordureBas : MonoBehaviour {
	Vector3 bd;
	Vector3 bg;
	public float width = 0.5F;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		float dist = Camera.main.transform.position.z;
		bg = Camera.main.ViewportToWorldPoint(new Vector3(0,0,-dist));
		bd = Camera.main.ViewportToWorldPoint(new Vector3(1,0,-dist));
		transform.position = bg;
		Vector3 dimensions = bg - bd;
		Vector3 position = dimensions;
		dimensions.y = width;
		position.Scale (new Vector3 (0.5F, 0.5F, 0.5F));
		transform.localScale = dimensions;
		transform.Translate (position);
	
	}
}
