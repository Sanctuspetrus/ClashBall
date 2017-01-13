using UnityEngine;
using System.Collections;

public class ViewPuissanceScript : MonoBehaviour
{
	public int segments;
	//public float xradius;
	//public float yradius;
	private LineRenderer line;

	public float tempCharge = 10f;

	private float chargement = 0;

	public Transform joueur;

	private bool leftButtonPressed = false;

	private float t = 0f;




	void Start ()
	{
		line = gameObject.GetComponent<LineRenderer>();

		line.SetVertexCount (segments + 1);
		line.useWorldSpace = false;
		CreatePoints (0.5f);
	}

	void Update(){

		if (Input.GetMouseButtonDown (0)) {
			leftButtonPressed = true;
		}
		if (Input.GetMouseButtonUp (0)) {
			leftButtonPressed = false;
		}

		if (leftButtonPressed && chargement < tempCharge) {

			Debug.Log ("chargement : " + chargement);

			float x = Mathf.Lerp (0, joueur.transform.localScale.x/2, chargement);

			CreatePoints (x);

			t += Time.deltaTime;

			//si le temps de charge n'est pas atteint, on 
			if (chargement < tempCharge) {
				chargement += Time.deltaTime;
			}
		} else {
			chargement = 0f;
		}


	}



	void CreatePoints (float val)
	{

		float x;
		float y;
		float z = 0f;

		float angle = 20f;

		for (int i = 0; i < (segments + 1); i++)
		{
			x = joueur.transform.position.x + Mathf.Sin (Mathf.Deg2Rad * angle) * val;
			y = joueur.transform.position.y + Mathf.Cos (Mathf.Deg2Rad * angle) * val;

			line.SetPosition (i,new Vector3(x,y,z) );

			angle += (360f / segments);
		}
	}


	void ChargementCercle (float val)
	{
		Debug.Log (val);

		float x;
		float y;
		float z = 0f;

		float angle = 20f;

		for (int i = 0; i < (segments + 1); i++)
		{
			x = joueur.transform.position.x + Mathf.Sin (Mathf.Deg2Rad * angle) * val;
			y = joueur.transform.position.y + Mathf.Cos (Mathf.Deg2Rad * angle) * val;

			line.SetPosition (i,new Vector3(x,y,z) );

			angle += (360f / segments);
		}
	}


}
	