using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MapMovement : MonoBehaviour {
	
	Camera mainCam;
	GameObject player;

	MapSceneManager mapManager;

	public bool canChangeNodes = true;
	float moveSpeed = 8;


	void Awake () {
		mainCam = Camera.main;
		player = GameObject.FindGameObjectWithTag("Player");

		mapManager = GetComponent<MapSceneManager>();
	}


	void Update () {

	}


	//void OnMouseDown () {
	//	Ray clickRay = mainCam.ScreenPointToRay(Input.mousePosition);
	//}


	void OnSelect () {
		//Debug.Log("You clicked");
		Ray selectRay = mainCam.ScreenPointToRay(Mouse.current.position.ReadValue());
		//RaycastHit selectHit;

		RaycastHit[] hits = Physics.RaycastAll(selectRay, 100, 1 << 3);

		if (canChangeNodes && hits.Length > 0) {
			foreach (RaycastHit hit in hits) {
				if (hit.collider.gameObject.layer == 3) {
					StartCoroutine(MoveToNode(hit.collider.gameObject));
					break;
				}
			}
		}
	}


	IEnumerator MoveToNode (GameObject node) {
		MapSceneManager.currentLocation = node;
		//Debug.Log("Moving to node");
		canChangeNodes = false;

		Vector3 startPos = player.transform.position;
		float distance = Vector3.Distance(startPos, node.transform.position);
		float traveled = 0;

		for (float i = 0; i < distance; i += moveSpeed * Time.deltaTime) {
			traveled += moveSpeed * Time.deltaTime;
			//print(traveled/distance);
			player.transform.position = Vector3.Lerp(startPos, node.transform.position, traveled / distance);

			yield return null;
		}

	}
}
