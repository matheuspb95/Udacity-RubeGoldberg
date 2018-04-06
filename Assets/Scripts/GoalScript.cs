using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour {
	public Transform StarController;
	public string NextLevel;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision coll){
		if(coll.gameObject.CompareTag("Ball")){
			if(VerifyStars()){
				print("yes");
				//Load Next Scene;
				SteamVR_LoadLevel.Begin(NextLevel);

			}
		}
	}

	bool VerifyStars(){
		foreach(Transform star in StarController){
			if(star.gameObject.activeSelf) return false;
		}
		return true;
	}
}
