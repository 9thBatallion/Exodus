using UnityEngine;
using System.Collections;

public class targetDamage : MonoBehaviour {

	public int DummyHealth;
	private int RemainingHealth;
	public GameObject dummyBroken;

	// Use this for initialization
	void Start () {
		RemainingHealth = DummyHealth;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision otherObj) {
		if (RemainingHealth > 0) {
			if (otherObj.gameObject.tag == "Missle") {

				BulletDestroy bullet = otherObj.collider.GetComponent<BulletDestroy>();
				RemainingHealth -= bullet.missleDamage;/*(BulletDestroy)(otherObj.gameObject).missleDamage;*/
			}
		} else {
			for (int i=0; i <= 10; i++) {
				GameObject broken = Instantiate (dummyBroken);
				broken.transform.position = otherObj.transform.position;
			}
			float power = 100.00F;
			int radius = 100;
			Vector3 explosionPos = transform.position;
			Collider[] colliders = Physics.OverlapSphere (explosionPos, radius);
			foreach (Collider hit in colliders) {
				if (hit && hit.GetComponent<Rigidbody> ())
					hit.GetComponent<Rigidbody> ().AddExplosionForce (power, explosionPos, radius, 3.0F);
			}

			Destroy (gameObject);
		}
	}

}
