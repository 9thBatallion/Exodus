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

	// Use this for initialization
	void Start () {
		initialCounter = 0;
	}
	
	// Update is called once per frame
	void Update () {
	if (initialCounter++ >= framesToLive) {
			DestroyAndExplode(gameObject, false);
		}
	}

	void OnCollisionEnter(Collision otherObj) {
		DestroyAndExplode (otherObj.gameObject, true);
	/*	if (otherObj.gameObject.tag == "Missle"){// && gameObject.tag == "Targetable") {
			//for (int i=0; i <= 5; i++) {
				GameObject shrapnel = Instantiate (Shrapnel);
				explosionPos = otherObj.gameObject.transform.position;
				shrapnel.transform.position = explosionPos; // transform.TransformPoint(new Vector3(vX, vY, vZ) * shotDirection);
				//shrapnel.gameObject.GetComponent<Rigidbody>().velocity = otherObj.gameObject.GetComponent<Rigidbody>().velocity;
			//}
			Vector3 expliosionPos = transform.position;
			Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
			foreach(Collider hit in colliders){
			if(hit && hit.GetComponent<Rigidbody>())
					hit.GetComponent<Rigidbody>().AddExplosionForce(power, expliosionPos, radius, 3.0F);
			}
			Destroy (otherObj.gameObject);
		} else if (otherObj.gameObject.tag == "Sharpnel" || gameObject.tag == "Sharpnel") {
			Destroy (otherObj.gameObject);
		}*/
	}

	void DestroyAndExplode(GameObject otherObj, bool collision)
	{
		//if (collision) {
			if (otherObj.tag == "Missle") {// && gameObject.tag == "Targetable") {
				for (int i=0; i <= 5; i++) {
					GameObject shrapnel = Instantiate (Shrapnel);
					explosionPos = otherObj.transform.position;
					shrapnel.transform.position = explosionPos;
				}

				Vector3 expliosionPos = transform.position;
				Collider[] colliders = Physics.OverlapSphere (explosionPos, radius);
				foreach (Collider hit in colliders) {
					if (hit && hit.GetComponent<Rigidbody> ())
						hit.GetComponent<Rigidbody> ().AddExplosionForce (power, expliosionPos, radius, 3.0F);
				}
				Destroy (otherObj);
			} else if (otherObj.tag == "Sharpnel" || gameObject.tag == "Sharpnel") {
				Destroy (otherObj);
			}
		//} 
		/*else if(otherObj){

			GameObject shrapnel = Instantiate (Shrapnel);
			explosionPos = otherObj.transform.position;
			shrapnel.transform.position = explosionPos;
			
			Vector3 expliosionPos = transform.position;
			Collider[] colliders = Physics.OverlapSphere (explosionPos, radius);
			foreach (Collider hit in colliders) {
				if (hit && hit.GetComponent<Rigidbody> ())
					hit.GetComponent<Rigidbody> ().AddExplosionForce (power, expliosionPos, radius, 3.0F);
			}
			Destroy (otherObj);





			GameObject shrapnel = Instantiate (Shrapnel);
			shrapnel.transform.position = gameObject.transform.position; // transform.TransformPoint(new Vector3(vX, vY, vZ) * shotDirection);
			shrapnel.gameObject.GetComponent<Rigidbody>().velocity = gameObject.GetComponent<Rigidbody>().velocity;
			Destroy(gameObject);*/
		//}
	}
}
