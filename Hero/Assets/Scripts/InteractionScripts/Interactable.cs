using UnityEngine;


[RequireComponent(typeof(SphereCollider))]
public abstract class Interactable : MonoBehaviour {

	//public UIManager UImanager;
		
	public abstract void Interact();
	public abstract void Identify(string myName);
	public abstract void MoveAlong();


	private void Reset () {
		GetComponent<SphereCollider>().isTrigger = true;
	}


	private void OnTriggerStay (Collider col) {
//TODO Combine this with the player's forward Raycast from the PlayerMove script (wherever it fits best), because for now, the player can be within this collider,
//and the Identify() text displays, even when the player is not facing the interactable object. Thus, the "interact input" doesn't do anything.
		if (col.CompareTag("Player")) {
			if (col.GetComponent<PlayerMove>().canMove) {
				Identify(name);
			}
		}
	}


	private void OnTriggerExit (Collider col) {
		MoveAlong();
	}

}
