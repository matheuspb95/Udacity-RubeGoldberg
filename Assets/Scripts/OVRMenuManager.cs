using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OVRMenuManager : MonoBehaviour {

	public List<GameObject> itens;
	public List<GameObject> prefabs;
	public int actualIndex;
	public GameObject objectMenu;
	// Use this for initialization
	
	bool menuSwipe;
	float axis;
	bool showing;
	// Update is called once per frame
	void Update () {
		axis = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).x;
		
		if(axis < 0.45f && axis > -0.45f){
			menuSwipe = true;
		}

		if(menuSwipe){
			if(axis <= -0.45f){
				MenuLeft();
			}
			else if(axis >= 0.45f){
				MenuRight();
			}
			menuSwipe = false;
		}

		if(OVRInput.GetDown(OVRInput.Button.Three)){
			if(showing){
				Instantiate(prefabs[actualIndex], itens[actualIndex].transform.position, itens[actualIndex].transform.rotation);			
			} else {
				objectMenu.SetActive(true);
			}
		}

		if(OVRInput.GetDown(OVRInput.Button.Four)){
			objectMenu.SetActive(false);
			showing = false;
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
