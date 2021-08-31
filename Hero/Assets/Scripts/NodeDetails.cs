using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeDetails : MonoBehaviour {

	///[SerializeField] ComputerDisplay compDisplay;

	[SerializeField] MapSceneManager mapManager;
	[SerializeField] MapUIManager UIManager;
	[SerializeField] NodeManager nodeManager;

	[Space]
	GameObject myNeighborhood;
	//public List<GameObject> neighborObjects = new List<GameObject>();
	public GameObject[] myNeighbors;

	public ClueMaster.locations myLocation;
	public int nodeNum;
	[SerializeField] int myLocationScene;

	public bool isGangHQ;
	public ClueMaster.gangs myGang;
	Color gangColor;

	public bool battlingForControl = false;


	//public string[] highTierActivities;
	//public static ClueMaster.attackTypes myHighTierActivity = ClueMaster.attackTypes.none;
	bool isEventHappeningHere = false;


	void Awake() {
		//UIManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<MapUIManager>();
		//nodeManager = GetComponentInParent<NodeManager>();

		///myNeighbors = myNodeObject.neighborNodes;

		//SetupHighTierActivities();
		///TODO Set nodeNum manually in the Inspector, just to reduce the chances of some random fuck-up
		nodeNum = nodeManager.nodeList.IndexOf(gameObject);

		if (NodeManager.nodeGangs[nodeNum] == ClueMaster.gangs.none) {
			NodeManager.nodeGangs[nodeNum] = myGang;
		}
		//SetMyGangInfluence();

		DetermineIfEventHappeningHere();
	}


	void Start () {

		//SetupMyNeighborhood();

		//if (NodeManager.nodeGangs[nodeNum] == null || NodeManager.nodeGangs[nodeNum] == "") {
		//	///NodeManager.nodeGangs[nodeNum] = myLocManager.gangControllingLoc;
		//}

	}


	void Update () {
		//If the player is standing at the site of a low-tier activity, and a high-tier activity appears there, reset the Computer Display to
		//reflect this new activity, but reset the "activity selectors", so they don't suddenly accept a high-tier event at the same moment
		//that they click the "Commence" button
		//Hopefully I won't even need this, as the high-tier activity should be chosen when entering the map scene, and only "deleted" when
		//the sun comes up, at which point they return to the hideout anyway. Still, for now it can serve my testing purposes
		//if (MapSceneManager.highTierActSet /*&& MapSceneManager.currentLocation == MapSceneManager.mapLoc && compDisplay.activity.color != Color.yellow*/) {
		//	if (myHighTierActivity != ClueMaster.attackTypes.none) {
		//		CrimeManager.isHighTierActivityHere = true;
		//		CrimeManager.SetHTCrimeRates(myHighTierActivity, isEventHappeningHere, myGang, myLocation);
		//		///compDisplay.UpdateCompUI();
		//	}
		//}
	}


	void OnTriggerEnter(Collider enterCol) {
		if (enterCol.gameObject.CompareTag("Player") && gameObject == MapSceneManager.currentLocation) {
			//MapSceneManager.currentLocation = myLocation;
			mapManager.nextSceneIndex = myLocationScene;

			Color activityColor = Color.white;

			//DetermineIfEventHappeningHere();

			if (isEventHappeningHere) {
				//CrimeManager.isHighTierActivityHere = true;
				//CrimeManager.SetHTCrimeRates(ClueMaster.attackType, isEventHappeningHere, ClueMaster.gang, myLocation);
				CrimeManager.SetCrime(true, true, myLocation, ClueMaster.gang);
				activityColor = Color.green;
			}
			else if (myLocation == MapSceneManager.HTLocation) {// && MapSceneManager.HTActivity != ClueMaster.attackTypes.none) {
				//The Nightly Activity from the CrimeManager script becomes equal to "myHighTierActivity"
				//CrimeManager.isHighTierActivityHere = true;
				CrimeManager.SetCrime(false, true, myLocation, myGang);
				activityColor = Color.yellow;
				Debug.Log("Location is host to the high-tier activity");
			}
			else {
				//Debug.Log("Location is host to a minor activity");
				//CrimeManager.isHighTierActivityHere = false;
				//CrimeManager.isEvent = false;
				//GetComponent<MeshRenderer>().material.color = Color.black;
				CrimeManager.SetCrime(false, false, myLocation, myGang);
			}
			UIManager.OpenActivityUI(activityColor);
		}
	}


//	void SetupHighTierActivities() {
//		highTierActivities = new string[9] { "Arson", "Bomb Threat", "Chemical Attack", "Hostage Situation", "Kidnapping", "Mass Shooting", "Robbery",
//			"Blank", "Blank"/*, "Blank", "Blank", "Blank"*/};

////TOMAYBEDO If I want to set up location (or landmark)-specific activities, do it here
///*		switch (myLandmark) {
//			case "Bridge":
//				break;
//			case "City Hall":
//				break;
//			case "First Bank":
//				break;
//			case "International Corporation HQ":
//				break;

//			default:
//				break;
//		}
//*/
//	}


	void DetermineIfEventHappeningHere() {
		if (ClueMaster.eventOngoing && ClueMaster.eventUncovered && ClueMaster.nightsUntilEventEnds > 0) {
			if (ClueMaster.location == myLocation) {
				GetComponent<MeshRenderer>().material.color = Color.green;
				isEventHappeningHere = true;
				//myHighTierActivity = ClueMaster.attackType;
			}
			else {
				isEventHappeningHere = false;
			}
		}
	}


	//void SetupMyNeighborhood() {
//TODOLATER Just set this shit explicitly, in the inspector, after the placements of the locations and neighborhoods are finally decided. It will take less computing power then.
		//foreach (GameObject node in nodeManager.nodeList) {
		//	SphereCollider nodeCol = node.GetComponent<SphereCollider>();
		//	if (nodeCol.bounds.Intersects(gameObject.GetComponent<SphereCollider>().bounds)) {
		//		neighborObjects.Add(node);
		//	}
		//}
		//if (neighborObjects.Contains(gameObject)) {
		//	neighborObjects.Remove(gameObject);
		//}

	//	if (myNeighborhood == null) {
	//		foreach (GameObject neighborhood in nodeManager.neighborhoods) {
	//			if (neighborhood.GetComponent<MeshCollider>().bounds.Intersects(gameObject.GetComponent<SphereCollider>().bounds)) {
	//				myNeighborhood = neighborhood;
	//			}
	//		}
	//	}
	//}


	public void SetMyGangInfluence() {
		myGang = NodeManager.nodeGangs[nodeNum];

		switch (myGang) {
			case ClueMaster.gangs.The_Jackals:
				gangColor = Color.cyan;
				break;
			case ClueMaster.gangs.The_Clone_Army:
				gangColor = Color.blue;
				break;
			case ClueMaster.gangs.The_Eldritch:
				gangColor = Color.red;
				break;
			case ClueMaster.gangs.The_Leslies:
				gangColor = Color.magenta;
				break;
			default:
				gangColor = Color.gray;
				break;
		}

		if (myLocation == MapSceneManager.HTLocation) {
			GetComponent<MeshRenderer>().material.color = Color.yellow;
		}
		else {
			GetComponent<MeshRenderer>().material.color = gangColor;
		}
	}

}
