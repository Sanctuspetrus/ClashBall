using UnityEngine;
using System.Collections;

public class borduresCamera : MonoBehaviour
{
	private Vector3 dh; // Coin à droite en haut
	private Vector3 db; // Coin à droite en bas
	private Vector3 gh; // Coin à gauche en haut
	private Vector3 gb; // Coin à gauche en bas

	private LineRenderer bordure;

	// Use this for initialization
	void Start ()
	{
		

		bordure = gameObject.AddComponent<LineRenderer> () as LineRenderer;
		bordure.SetVertexCount (5);
		bordure.
		bordure.SetWidth (1F, 1F);
		bordure.SetColors (Color.black, Color.black);

		miseAJourCoins ();
		setBordure ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		miseAJourCoins ();
		setBordure ();
	}

	void miseAJourCoins(){
		float dist = Camera.main.transform.position.z;
		dh = Camera.main.ViewportToWorldPoint(new Vector3(1,1,-dist));
		db = Camera.main.ViewportToWorldPoint(new Vector3(1,0,-dist));
		gh = Camera.main.ViewportToWorldPoint(new Vector3(0,1,-dist));
		gb = Camera.main.ViewportToWorldPoint(new Vector3(0,0,-dist));
	}

	void setBordure(){
		bordure.SetPositions(new Vector3[]{dh, db, gb, gh, dh});
	}


}

