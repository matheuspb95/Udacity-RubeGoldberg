using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {
	public List<GameObject> itens;
	public List<GameObject> prefabs;
	public int actualIndex;
	public GameObject objectMenu;

	SteamVR_TrackedObject trackedObj;
	public SteamVR_Controller.Device device;
	// Use this for initialization
	void Start () {
		trackedObj = GetComponent<SteamVR_TrackedObject>();
	}
	
	// Update is called once per frame
	void Update () {
		device = SteamVR_Controller.Input((int)trackedObj.index);
		if(device.GetTouchDown(SteamVR_Controller.ButtonMask.Touchpad)){
			objectMenu.SetActive(true);
		}		

		if(device.GetTouchUp(SteamVR_Controller.ButtonMask.Touchpad)){
			objectMenu.SetActive(false);
		}

		if(device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger)){
			if(objectMenu.activeSelf)
				Instantiate(prefabs[actualIndex], itens[actualIndex].transform.position, itens[actualIndex].transform.rotation);			
		}

		if(device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad)){
			float axis = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).x;
			if(axis < 0){
				MenuLeft();
			}
			else if(axis > 0){
				MenuRight();
			}
		}
	}

	public void MenuLeft(){
		itens[actualIndex].SetActive(false);
		actualIndex--;
		if(actualIndex < 0){
			actualIndex = itens.Count - 1;
		}
		itens[actualIndex].SetActive(true);
	}

	public void MenuRight(){
		itens[actualIndex].SetActive(false);
		actualIndex++;
		if(actualIndex > itens.Count - 1){
			actualIndex = 0;
		}
		itens[actualIndex].SetActive(true);
	}
}
