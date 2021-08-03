using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HideoutSceneManager : MonoBehaviour {

	//public GameObject exitDoor;
	//public GameObject computer;



	
	void Start() {
        
    }


    void Update() {
		if (Keyboard.current.spaceKey.isPressed) {
			CreateEvent();
		}
    }


	public void CreateEvent() {
		ClueMaster.ChooseEventParameters();
	}


	public void OnFindClue() {
		ClueMaster.GetAClue();
	}
}
