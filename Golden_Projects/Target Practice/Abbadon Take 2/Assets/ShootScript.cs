using UnityEngine;
using System.Collections;

public class ShootScript : MonoBehaviour {

	public int bulletMass;
	public int bulletVelocity;
	public float shotDirection;
	public float scaleX;
	public float scaleY;
	public float scaleZ;
	public int colliderdirection;
	public int bulletBurstNumber;

	public float vX;
	public float vY;
	public float vZ;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetButton ("Fire1")) {
		
			fireRound();

			//CapsuleCollider bulletCollider = new CapsuleCollider();
			//bulletCollider.isTrigger = true;
			//bulletCollider.direction = colliderdirection;
			//GetComponent<Collider>().attachedRigidbody.AddForce(vX,vY,vZ);



		}

		if (Input.GetButtonDown ("Fire2")) {
			for(int i = 0; i <= bulletBurstNumber; i++)
			{
				fireRound();

			}
		}
	}

	void fireRound()
	{
		Vector3 shootDirection = new Vector3();
		
		shootDirection = transform.TransformPoint(new Vector3(vX, vY, vZ) * shotDirection);
		
		GameObject bullet = GameObject.CreatePrimitive(PrimitiveType.Capsule);
		bullet.transform.position = shootDirection;
		bullet.transform.rotation = transform.rotation;
		bullet.transform.localScale += new Vector3(scaleX, scaleY, scaleZ);
		Rigidbody bulletRigidBody = bullet.AddComponent<Rigidbody>();
		bulletRigidBody.mass = bulletMass;
		
		bulletRigidBody.velocity = transform.TransformDirection(Vector3.up * bulletVelocity);
	}
}
