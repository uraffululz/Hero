using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapUIManager : MonoBehaviour {

	[SerializeField] MapSceneManager mapSceneMan;
	[SerializeField] MapMovement mapMover;

	[SerializeField] GameObject activityBG;
	
	
	void Awake() {
        
    }


    void Update() {
        
    }


	public void OpenUI(GameObject UItoOpen) {
		UItoOpen.SetActive(true);
	}


	public void CloseUI(GameObject UItoClose) {
		UItoClose.SetActive(false);

		mapMover.canChangeNodes = true;
	}


	public void OpenActivityUI() {
		OpenUI(activityBG);
	}
}
