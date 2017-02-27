	using UnityEngine;
	using System.Collections;

	public class GrenadeExplosion : MonoBehaviour {
		public ParticleSystem explosion;
		public GameObject shake;
		public GameObject force;
		public float infuseTime;
		public float radius = 5.0F;
		public float power = 10.0F;

		// Use this for initialization
		void Start () {
		}
		
		// Update is called once per frame
		void Update () {
			infuseTime -= Time.deltaTime;
			if (infuseTime <= 0) {
				Explode ();
			}
		}

		void Explode() {
			Instantiate (explosion, gameObject.transform.position, Quaternion.identity);
			Instantiate (shake, gameObject.transform.position, Quaternion.identity);
			Instantiate (force, gameObject.transform.position, Quaternion.identity);
			Destroy (gameObject);
		}

		void ExplosionForce() {

		}

		void OnCollisionEnter2D(Collision2D coll) {
			if(coll.collider.CompareTag("Joueur")){
				Explode ();
			}
		}

	}
