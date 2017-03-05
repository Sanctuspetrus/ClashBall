using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour
{
	// EVENT
	public delegate void EventAction(GameObject player);
	public delegate void CollisionAction(Collision2D coll);
	public static event EventAction OnPlayerDeath;
	public static event EventAction OnPlayerAlive;
	public static event CollisionAction OnPlayerCollisionWithPlayer;
	public static event CollisionAction OnPlayerCollisionWithWall;

	// PRIVATE

	// PUBLIC
	public Text scoreText;
	public int angleVulnerable = 90;
	public int score = 0;


	void OnEnable(){
		GameScript.OnStartRound += RevivePlayer;
	}

	void OnDisable(){
		GameScript.OnStartRound -= RevivePlayer;
	}


	public void KillPlayer(){
		GameObject core = transform.Find ("Core").gameObject;
		core.SetActive(false);
		if (OnPlayerDeath != null) {
			OnPlayerDeath (gameObject);
		}
	}

	public void RevivePlayer(){
		GameObject core = transform.Find ("Core").gameObject;
		core.SetActive(true);
		if (OnPlayerAlive != null) {
			OnPlayerAlive (gameObject);
		}
	}

	// Envoie l'évennement de collision avec un Joueur
	void sendCollisionPlayer(Collision2D coll){
		if (OnPlayerCollisionWithPlayer != null) {
			OnPlayerCollisionWithPlayer (coll);
		}
	}

	// Envoie l'évennement de collision avec un mur
	void sendCollisionWall(Collision2D coll){
		if (OnPlayerCollisionWithWall != null) {
			OnPlayerCollisionWithWall (coll);
		}
	}

	void OnCollisionEnter2D(Collision2D collision){
		if (CollisionPlayer (collision)) {
			if (CollisionBack (collision)) {
				// Tue le joueur si la collision à eu lieu dans le dos
				GameObject killer = collision.gameObject;
				killer.GetComponent<Player> ().UpScore();
				KillPlayer ();
				return;
			}
			sendCollisionPlayer (collision);
			SoundEffectHelper.Instance.MakeClashSound (transform.position);
		} else {
			sendCollisionWall (collision);
			SoundEffectHelper.Instance.MakeBumpSound (transform.position);
		}
	}

	bool CollisionBack(Collision2D col){
		foreach (ContactPoint2D contact in col.contacts) {

			Vector2 direction = new Vector2 ();
			direction.x = transform.position.x - contact.point.x; 
			direction.y = transform.position.y - contact.point.y; 

			Vector2 angle = new Vector2 (Mathf.Cos (transform.eulerAngles.z * Mathf.Deg2Rad), Mathf.Sin (transform.eulerAngles.z * Mathf.Deg2Rad));
			float angle2 = Vector2.Angle (angle, direction);

			Vector3 cross = Vector3.Cross (angle, direction);
			if (cross.z > 0)
				angle2 = 360 - angle2;

			//variateur est égale à la valeur des 2 zones invulnérables se trouvant derriere le joueur (variant entre 0 et 180)
			float variateur = (180 - angleVulnerable) / 2; 

			if (angle2 > (180 + variateur) && angle2 < (180 + variateur + angleVulnerable)) {
				return true;
			}
		}
		return false;
	}

	bool CollisionPlayer(Collision2D collision) {
		return collision.gameObject.tag == "Player";
	}

	public void UpScore(){
		score++;
		scoreText.text = score.ToString ();
	}
}

