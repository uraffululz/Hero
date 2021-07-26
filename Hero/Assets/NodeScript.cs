using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeScript : MonoBehaviour {

	[SerializeField] MapSceneManager mapSceneMan;
	[SerializeField] MapUIManager mapUIMan;

	[SerializeField] int myLocationScene;


	
	void Awake() {
        
    }


    void Update() {
        
    }


	private void OnTriggerEnter (Collider other) {
		if (other.CompareTag("Player")) {
			mapSceneMan.nextSceneIndex = myLocationScene;
			mapUIMan.OpenActivityUI();
		}
	}
}
