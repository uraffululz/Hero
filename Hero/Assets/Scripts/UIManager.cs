using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	[SerializeField] GameObject interactUI;

	[SerializeField] Button detectiveUIButton;

	GameObject player;



    void Awake() {
		player = GameObject.FindGameObjectWithTag("Player");
		DetermineDetectiveUIAccess();
	}


	void Update() {
        
    }


	public void OpenUI(GameObject UItoOpen) {
		UItoOpen.SetActive(true);
		//player.GetComponent<PlayerMove>().canMove = false;
	}


	public void CloseUI(GameObject UItoClose) {
		UItoClose.SetActive(false);
		//player.GetComponent<PlayerMove>().canMove = true;
	}


	public void ActivateInteractUI (string interactableName) {
		interactUI.SetActive(true);
		interactUI.GetComponent<Text>().text = "Press E to interact with " + interactableName;
	}


	public void DeactivateInteractUI () {
		interactUI.SetActive(false);
	}


	public void DetermineDetectiveUIAccess () {
		Text detectiveUIButtonText = detectiveUIButton.GetComponentInChildren<Text>();

		if (ClueMaster.eventOngoing) {
			if (ClueMaster.eventUncovered) {
				detectiveUIButton.interactable = false;
				detectiveUIButtonText.text = "SOLVED";
				detectiveUIButtonText.color = Color.green;
			}
			else {
				detectiveUIButton.interactable = true;
				detectiveUIButtonText.text = "SOLVE EVENT";
				detectiveUIButtonText.color = Color.black;
			}
		}
		else {
			detectiveUIButton.interactable = false;
			detectiveUIButtonText.text = "INACCESSIBLE";
			detectiveUIButtonText.color = Color.red;
		}
	}
}
