using UnityEngine;
using System.Collections;

public class MouseScript : MonoBehaviour {

	//public Transform player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		Vector3 mousePos = Input.mousePosition;
		/*Vector3 parentPos = this.GetComponentInParent<Transform> ().transform.position;
		Vector3 direction = (mousePos - parentPos)*2;*/
		mousePos.z = 10;
		gameObject.transform.position = Camera.main.ScreenToWorldPoint (mousePos);
		//transform.position = direction;

	}
}
