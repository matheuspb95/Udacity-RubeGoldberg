using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObjects : MonoBehaviour {
	SteamVR_TrackedObject trackedObject;
	SteamVR_Controller.Device device;
	public float throwForce;
	// Use this for initialization
	void Start () {
		trackedObject = GetComponent<SteamVR_TrackedObject>();
	}
	
	// Update is called once per frame
	void Update () {
		device = SteamVR_Controller.Input((int)trackedObject.index);		
	}

	void OnTriggerStay(Collider coll){
		if(coll.gameObject.CompareTag("Box") || coll.gameObject.CompareTag("Throwable") || coll.gameObject.CompareTag("Ball") || coll.gameObject.CompareTag("Respawn")){
			if(device.GetPressUp(SteamVR_Controller.ButtonMask.Grip)){
				ThrowObj(coll);		
			} else 
			if(device.GetPressDown(SteamVR_Controller.ButtonMask.Grip)){
				GrabObj(coll);
			}
		}
	}

	void ThrowObj(Collider coll){
		coll.transform.SetParent(null);
		if(coll.gameObject.CompareTag("Box") || coll.gameObject.CompareTag("Ball") || coll.gameObject.CompareTag("Respawn")){
			Rigidbody body = coll.GetComponent<Rigidbody>();
			body.isKinematic = false;
			body.velocity = device.velocity * throwForce;
			body.angularVelocity = device.angularVelocity;
		}
	}

	void GrabObj(Collider coll){
		coll.transform.SetParent(transform);
		coll.GetComponent<Rigidbody>().isKinematic = true;
		device.TriggerHapticPulse(2000);
	}
}
