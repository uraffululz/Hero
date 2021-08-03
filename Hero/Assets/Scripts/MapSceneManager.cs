using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapSceneManager : MonoBehaviour {

	[SerializeField] public MapUIManager UIMan {get; private set;}

	[SerializeField] List<GameObject> mapNodes;
	public static ClueMaster.locations HTLocation;
	//static int mapLocNum;
	public static GameObject currentLocation;

	GameObject player;
	GameObject sidekick;

	enum mapState { Idle, Grappling, Moving };
	//[SerializeField] mapState myMapState;

	public static ClueMaster.attackTypes HTActivity;
	public static bool highTierActSet = false;

	public int nextSceneIndex;


	public void SetHighTierParameters() {
		int HTLocationIndex = Random.Range(1, System.Enum.GetValues(typeof(ClueMaster.locations)).Length);
		HTLocation = (ClueMaster.locations) HTLocationIndex;

		int HTActivityIndex = Random.Range(1, System.Enum.GetValues(typeof(ClueMaster.attackTypes)).Length);
		HTActivity = (ClueMaster.attackTypes) HTActivityIndex;

		highTierActSet = true;
	}

	public void LoadNextScene() {
		SceneManager.LoadScene(nextSceneIndex);
	}

	public void ReturnToHideout() {
		nextSceneIndex = 0;
		LoadNextScene();
	}


	public static void ResetHighTier () {
		currentLocation = null;
		HTLocation = ClueMaster.locations.none;
		HTActivity = ClueMaster.attackTypes.none;
		highTierActSet = false;

		//NodeDetails.myHighTierActivity = ClueMaster.attackTypes.none;
	}
}
