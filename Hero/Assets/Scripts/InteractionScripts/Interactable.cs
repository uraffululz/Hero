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
