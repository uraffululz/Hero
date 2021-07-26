using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapSceneManager : MonoBehaviour {

	public int nextSceneIndex;

	public void LoadNextScene() {
		SceneManager.LoadScene(nextSceneIndex);
	}

	public void ReturnToHideout() {
		nextSceneIndex = 0;
		LoadNextScene();
	}
}
