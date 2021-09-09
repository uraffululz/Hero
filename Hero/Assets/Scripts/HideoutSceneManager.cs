using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HideoutSceneManager : MonoBehaviour {

	//public GameObject exitDoor;
	//public GameObject computer;

	[SerializeField] GameObject player;


	
	void Start() {
        
    }


    void Update() {
		
    }


	public void AllowPlayerMove(bool allow) {
		player.GetComponent<PlayerMove>().canMove = allow;
	}


	//public void CreateEvent() {
	//	ClueMaster.ChooseEventParameters();
	//}


	//public void OnFindClue() {
	//	ClueMaster.GetAClue();
	//}
}
