using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallReset : MonoBehaviour {
	Vector3 StartPos;

	Rigidbody body;
	public Transform StarController;
	public Material whiteMat;
	// Use this for initialization
	void Start () {
		StartPos = transform.position;
		body = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if(body.IsSleeping() && !body.isKinematic){
			Reset();
		}
	}

	void OnCollisionEnter(Collision coll){
		if(coll.gameObject.CompareTag("Ground")){
			Reset();
		}
	}

	void Reset(){
		body.velocity = Vector2.zero;
		transform.position = StartPos;
		gameObject.tag = "Ball";
		GetComponent<Renderer>().material = whiteMat;
		ResetStars();
	}

	void ResetStars(){
		foreach(Transform star in StarController){
			star.gameObject.SetActive(true);
		}
	}
}
