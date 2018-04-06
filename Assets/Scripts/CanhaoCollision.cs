using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanhaoCollision : MonoBehaviour {
	Rigidbody body;
	public float ShootForce;
	// Use this for initialization

	void OnTriggerEnter(Collider coll){
		if(coll.gameObject.CompareTag("Ball")){
			if(body == null)
				body = coll.gameObject.GetComponent<Rigidbody>();
			if(body.isKinematic) return;
			coll.transform.position = transform.position;
			body.velocity = Vector3.zero;
			body.AddForce(transform.up * ShootForce);
		}
	}
}
