using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour {

	//[SerializeField] InputActionAsset controls;

	///Local Components
	Rigidbody rb;

	///Movement Variables
	public bool canMove = true;
	float moveSpeed = 10f;
	Vector3 moveDir;

	
	
	void Awake() {
        //controls = GetComponent<PlayerInput>().actions;
		rb = GetComponent<Rigidbody>();
    }


    void Update() {
		if (canMove) {
			rb.MovePosition(transform.position + (moveDir * moveSpeed * Time.deltaTime));
			transform.LookAt(transform.position + moveDir);
		}
		
	}


	void OnMove (InputValue cxt) {
		moveDir = new Vector3(cxt.Get<Vector2>().x, 0, cxt.Get<Vector2>().y);
	}


	void OnInteract() {
		RaycastHit interactHit;

		if (Physics.Raycast(transform.position, transform.forward, out interactHit)) {
			//print("You're interacting with " + interactHit.collider.gameObject.name);

			if (interactHit.collider.GetComponent<Interactable>()) {
				interactHit.collider.GetComponent<Interactable>().Interact();
				canMove = false;
			}
		}

	}
	
}
