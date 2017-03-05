using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour {
	// EVENT
	public delegate void EventAction();
	public static event EventAction OnEndRound;
	public static event EventAction OnStartRound;

	void OnEnable() {
		Player.OnPlayerDeath += ReinitState;
	}

	void OnDisable(){
		Player.OnPlayerDeath -= ReinitState;
	}

	void ReinitState(GameObject player){
		Debug.Log ("Replacement");
		Invoke ("sendStart", 1);
	}

	void sendEnd(){
		if (OnEndRound != null) {
			OnEndRound ();
		}
	}

	void sendStart(){
		if (OnStartRound != null) {
			OnStartRound ();
		}
	}


}
