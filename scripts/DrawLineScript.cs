using UnityEngine;
using System.Collections;


//A attacher à un LineRenderer

//Trace un trait entre l'obj origin et destination

//fonctionnel mais à modifier, car possède une fonction inutile de traçage de traits entre les 2 objs



public class DrawLineScript : MonoBehaviour {

	private float distMax = 2f;

	private LineRenderer lineRenderer;

	public Transform origin;
	public Transform destination;

	/*private bool create = false;
	private bool leftButtonPressed = false;
	private float counter;
	private float dist;
	public float lineDrawSpeed = 6f;*/

	// Use this for initialization
	void Start () {


	
		lineRenderer = GetComponent<LineRenderer> ();

	}

	// Update is called once per frame
	void Update () {


		float distance = Vector3.Distance (origin.position, destination.position);
		if (distance < 5) {


			lineRenderer.SetPosition (0, origin.position);
			lineRenderer.SetPosition (1, destination.position);
		} else {
			
			Vector3 scaledDirection = Vector3.Scale(destination.position,new Vector3(0.2f,0.2f,0.2f));
			Vector3 val = new Vector3 (0.2f, 0.2f, 0.2f);

		//	Debug.Log (destination.position);
		//	Debug.Log (scaledDirection);
			Vector3 temp = destination.position.normalized * 5;
		//	Debug.Log (temp);
		
			//on trace le trait
			lineRenderer.SetPosition (0, origin.position);
			lineRenderer.SetPosition (1, temp);
		}
		//pression de left button
	/*	if (Input.GetMouseButtonDown (0)) {
			create = true;
			counter = 0;
			leftButtonPressed = true;
			lineRenderer.SetPosition (0, origin.position);
		}
		if (leftButtonPressed) {
			dist = Vector3.Distance (origin.position, destination.position);
			if (counter < dist) {
				counter += 0.1f / lineDrawSpeed;

				//interpolate la distance que doit faire la ligne entre 2 frames
				float x = Mathf.Lerp (0, dist, counter);

				Vector3 pointA = origin.position;
				Vector3 pointB = destination.position;

				//Get the unit vector un the desired direction, multiply by the desired length and add the starting point
				Vector3 pointAlongLine = x * Vector3.Normalize (pointB - pointA) + pointA;

				//on trace le trait
				lineRenderer.SetPosition (0, origin.position);
				lineRenderer.SetPosition (1, destination.position);

				//si on relache le bouton gauche de la souris, on efface le trait
				if(Input.GetMouseButtonUp(0)){
					leftButtonPressed = false;
				}
					
			} else {
				lineRenderer.SetPosition (0, origin.position);
				leftButtonPressed = false;
				create = false;
				counter = 0;
			}
		}*/
	}

}
