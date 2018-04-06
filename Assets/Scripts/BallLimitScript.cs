using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLimitScript : MonoBehaviour {
	public Material redMat;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerExit(Collider coll){
		if(coll.gameObject.CompareTag("Ball")){
			if(coll.GetComponent<Rigidbody>().isKinematic){
				coll.GetComponent<Renderer>().material = redMat;
				coll.gameObject.tag = "Respawn";
			}
		}
	}
}
