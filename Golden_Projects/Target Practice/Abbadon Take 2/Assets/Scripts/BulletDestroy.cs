using UnityEngine;
using System.Collections;

public class BulletDestroy : MonoBehaviour {

	public int framesToLive;
	private int initialCounter;
	public GameObject Shrapnel;
	public float shrapnelMass;
	public float shrapnelVelocity;
	private Vector3 explosionPos;
	public float radius = 5.0F;
	public float power = 10.0F;
	public int missleDamage;
	// Use this for initialization
	void Start () {
		initialCounter = 0;
	}
	
	// Update is called once per frame
	void Update () {
	if (initialCounter++ >= framesToLive) {
			DestroyAndExplode(gameObject);
		}
	}

	void OnCollisionEnter(Collision otherObj) {
		DestroyAndExplode (otherObj.gameObject);
	}

	void DestroyAndExplode(GameObject otherObj)
	{
		if (otherObj.tag == "Missle"){
			for (int i=0; i <= 5; i++) {
				GameObject shrapnel = Instantiate (Shrapnel);
				explosionPos = otherObj.transform.position;
				shrapnel.transform.position = explosionPos;
			}
			
			explosionPos = transform.position;
			Collider[] colliders = Physics.OverlapSphere (explosionPos, radius);
			foreach (Collider hit in colliders) {
				if (hit && hit.GetComponent<Rigidbody> ())
					hit.GetComponent<Rigidbody> ().AddExplosionForce (power, explosionPos, radius, 3.0F);
			}
			Destroy (otherObj);
		} else if (otherObj.tag == "Sharpnel" || gameObject.tag == "Sharpnel") {
			Destroy (otherObj);
		}
	}
}
