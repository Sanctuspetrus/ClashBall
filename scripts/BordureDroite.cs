using UnityEngine;
using System.Collections;

public class BordureDroite : MonoBehaviour {
	Vector3 hd;
	Vector3 bd;
	public float width = 0.5F;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float dist = Camera.main.transform.position.z;
		hd = Camera.main.ViewportToWorldPoint(new Vector3(1,1,-dist));
		bd = Camera.main.ViewportToWorldPoint(new Vector3(1,0,-dist));
		transform.position = bd;
		Vector3 dimensions = bd - hd;
		Vector3 position = dimensions;
		position.Scale (new Vector3 (0.5F, 0.5F, 0.5F));
		transform.Translate (position);
		dimensions.x = width;
		transform.localScale = dimensions;
	}
}
