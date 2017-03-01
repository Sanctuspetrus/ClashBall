using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCountDown : MonoBehaviour {

	private GameManagerScript GMS;

	public void Set_Count_Down(){

		GMS = GameObject.Find ("Script").GetComponent<GameManagerScript> ();
		GMS.counterDownDone = true;
	}
}
