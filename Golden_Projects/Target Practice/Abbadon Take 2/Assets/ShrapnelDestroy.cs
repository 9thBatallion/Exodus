using UnityEngine;
using System.Collections;

public class ShrapnelDestroy : MonoBehaviour {

	public int framesToLive;
	private int timer;
	// Use this for initialization
	void Start () {
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (timer++ >= framesToLive) {
			Destroy(gameObject);
		}
	}

	void OnCollisionEnter(Collision otherObj) {
		if (otherObj.gameObject.tag == "Sharpnel"){
			Destroy (otherObj.gameObject);
		}
	}
}
