using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectiveUIInteractor : Interactable {
 
	[SerializeField] UIManager UIMan;
	[SerializeField] GameObject myAssociatedUI;



	public override void Interact () {
		UIMan.OpenUI(myAssociatedUI);
		UIMan.DeactivateInteractUI();
	}


	public override void Identify (string name) {
		UIMan.ActivateInteractUI(name);
	}


	public override void MoveAlong () {
		UIMan.DeactivateInteractUI();
	}


}
