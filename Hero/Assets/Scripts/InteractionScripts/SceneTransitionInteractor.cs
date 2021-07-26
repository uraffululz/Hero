using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionInteractor : Interactable {

	UIManager UImanager;

	[SerializeField] int sceneToLoad;


	void Awake () {
		UImanager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
	}


	public override void Interact () {
		SceneManager.LoadScene(sceneToLoad);
	}


	public override void Identify (string name) {
		UImanager.ActivateInteractUI(name);
	}


	public override void MoveAlong () {
		UImanager.DeactivateInteractUI();
	}

}
