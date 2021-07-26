using UnityEngine;

public class UIInteractor : Interactable
{
	UIManager UImanager;
	//GameObject player;
	[SerializeField] GameObject myAssociatedUI;


	private void Awake () {
		UImanager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
		//player = GameObject.FindGameObjectWithTag("Player");
	}


	public override void Interact () {
		UImanager.OpenUI(myAssociatedUI);
		UImanager.DeactivateInteractUI();
	}


	public override void Identify(string name) {
		UImanager.ActivateInteractUI(name);
	}


	public override void MoveAlong () {
		UImanager.DeactivateInteractUI();
	}


}
