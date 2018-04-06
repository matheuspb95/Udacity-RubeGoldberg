using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OVRInputMovementManager : MonoBehaviour {
	//Teleport
	LineRenderer laser;
	public GameObject teleportAimerObject;
	public Vector3 teleportLocation;
	public GameObject player;
	public LayerMask laserMask;
    bool isDashing;
	public float dashSpeed;
	float lerpTime;
	Vector3 playerStartPos;
	Vector3 movementDirection;
	public Transform playerCam;
	public float moveSpeed;
	public float yAmount;
	void Start () {
		laser = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
		if(isDashing){
			lerpTime += Time.deltaTime * dashSpeed;
			player.transform.position = Vector3.Lerp(playerStartPos, teleportLocation + Vector3.down * 0.5f, lerpTime);
			if(lerpTime >= 1){
				isDashing = false;
				lerpTime = 0;
			}
		} else {
			if(OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger)){
				laser.enabled = true;
				teleportAimerObject.gameObject.SetActive(true);

				laser.SetPosition(0, gameObject.transform.position);
				RaycastHit hit;
				if(Physics.Raycast(transform.position, transform.forward, out hit, 15, laserMask)){
					teleportLocation = hit.point;
					laser.SetPosition(1, teleportLocation);

					teleportAimerObject.transform.position = new Vector3(teleportLocation.x, teleportLocation.y + yAmount, teleportLocation.z);
				} else {
					teleportAimerObject.transform.position = new Vector3(transform.forward.x * 15 + transform.position.x,
																		transform.forward.y * 15 + transform.position.y,
																		transform.forward.z * 15 + transform.position.z);
					RaycastHit groundRay;
					if(Physics.Raycast(teleportLocation, -Vector3.up, out groundRay, 17, laserMask)){
						teleportLocation = new Vector3(teleportLocation.x, groundRay.point.y, teleportLocation.z);

					}
					laser.SetPosition(1, transform.forward * 15 + transform.position);
					teleportAimerObject.transform.position = teleportLocation + new Vector3(0, yAmount, 0);
				}
			}


			if(OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger)){
				laser.enabled = false;
				teleportAimerObject.gameObject.SetActive(false);
				//player.transform.position = teleportLocation;
				playerStartPos = player.transform.position;
				isDashing = true;
			}
		}
	}
}
