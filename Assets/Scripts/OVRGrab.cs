using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OVRGrab : MonoBehaviour {
	public OVRInput.Controller thisController;
	public float throwForce;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
			
	}

	void OnTriggerStay(Collider coll){
		if(coll.gameObject.CompareTag("Throwable") || coll.gameObject.CompareTag("Ball") ){
			if(OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger, thisController)){
				ThrowObj(coll);		
			} else 
			if(OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, thisController)){
				GrabObj(coll);
			}
		}
	}

	void ThrowObj(Collider coll){
		print("Throw");
		coll.transform.SetParent(null);
		if(coll.gameObject.CompareTag("Ball")){
			Rigidbody body = coll.GetComponent<Rigidbody>();
			body.isKinematic = false;
			body.velocity = OVRInput.GetLocalControllerVelocity(thisController);
			body.angularVelocity = OVRInput.GetLocalControllerAngularVelocity(thisController);
		}
	}

	void GrabObj(Collider coll){
		coll.transform.SetParent(transform);
		coll.GetComponent<Rigidbody>().isKinematic = true;
	}
}
