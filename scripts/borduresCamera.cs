using UnityEngine;
using System.Collections;

public class BorduresCamera : MonoBehaviour {

	public float width = 0.5F;

	public GameObject bordure;
	private GameObject bordureGauche;
	private GameObject bordureDroite;
	private GameObject bordureHaut;
	private GameObject bordureBas;

	// Use this for initialization
	void Awake () {
		bordureGauche = Instantiate (bordure);
		bordureDroite = Instantiate (bordure);
		bordureHaut = Instantiate (bordure);
		bordureBas = Instantiate (bordure);
	}

	// Update is called once per frame
	void Update () {

		Vector3 hg;
		Vector3 bg;
		Vector3 hd;
		Vector3 bd;
		Vector3 dim;
		Vector3 pos;


		float dist = Camera.main.transform.position.z;

		hg = Camera.main.ViewportToWorldPoint(new Vector3(0,1,-dist));
		bg = Camera.main.ViewportToWorldPoint(new Vector3(0,0,-dist));

		hd = Camera.main.ViewportToWorldPoint(new Vector3(1,1,-dist));
		bd = Camera.main.ViewportToWorldPoint(new Vector3(1,0,-dist));

		//bordure Gauche
		bordureGauche.transform.position = hg;
		dim = bg - hg;
		pos = dim;
		bordureGauche.transform.position.Scale (new Vector3 (0.5F, 0.5F, 0.5F));
		bordureGauche.transform.Translate (pos/2);
		dim.x = width;
		bordureGauche.transform.localScale = dim;

		//bordure Droite
		bordureDroite.transform.position = hd;
		dim = bd - hd;
		pos = dim;
		bordureDroite.transform.position.Scale (new Vector3 (0.5F, 0.5F, 0.5F));
		bordureDroite.transform.Translate (pos/2);
		dim.x = width;
		bordureDroite.transform.localScale = dim;

		//bordure haut
		bordureHaut.transform.position = hd;
		dim = hg - hd;
		pos = dim;
		bordureHaut.transform.position.Scale (new Vector3 (0.5F, 0.5F, 0.5F));
		bordureHaut.transform.Translate (pos/2);
		dim.y = width;
		bordureHaut.transform.localScale = dim;

		//bordure bas
		bordureBas.transform.position = bd;
		dim = bg - bd;
		pos = dim;
		bordureBas.transform.position.Scale (new Vector3 (0.5F, 0.5F, 0.5F));
		bordureBas.transform.Translate (pos/2);
		dim.y = width;
		bordureBas.transform.localScale = dim;

	}
}