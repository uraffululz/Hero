using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NodeManager : MonoBehaviour {

	//DayNightCycle DNCycle;

	public GameObject[] neighborhoods;
	public List<GameObject> nodeList = new List<GameObject>();

//TODO This variable seems kind of unstable. Maybe see if there's a better way to keep the values consistent,
//Maybe using PlayerPrefs (which I'll be using eventually anyway)
	public static ClueMaster.gangs[] nodeGangs = new ClueMaster.gangs[10] {ClueMaster.gangs.none, ClueMaster.gangs.none, ClueMaster.gangs.none, ClueMaster.gangs.none, ClueMaster.gangs.none,
		ClueMaster.gangs.none, ClueMaster.gangs.none, ClueMaster.gangs.none, ClueMaster.gangs.none, ClueMaster.gangs.none};

	bool gangWarStarted = false;

	void Awake() {
		//DNCycle = GameObject.FindGameObjectWithTag("DayNightLight").GetComponent<DayNightCycle>();
	}


	void OnDisable() {
		//DNCycle.daylightEvent -= GangWarOnNode;
	}


	void Start () {
		//DNCycle.daylightEvent += GangWarOnNode;
		InitiateGangWars(2);

	}


	void Update () {
		//if (DNCycle.dayTime && !gangWarStarted) {
		//	gangWarStarted = true;
		//}
		//else if (!DNCycle.dayTime && DNCycle.isDusk) {
		//	gangWarStarted = false;
		//}
	}


	public void InitiateGangWars(int repetitions) {
		for (int i = 0; i < repetitions; i++) {
			PerformGangWar();
		}

		//Reset everything for next time
		foreach (GameObject node in nodeList) {
			node.GetComponent<NodeDetails>().battlingForControl = false;
		}
	}


	void PerformGangWar () {
		//DNCycle.daylightEvent -= GangWarOnNode;

		//TODO Set this as part of the listener for the "DaylightCome" event method when it is triggered on the DayNightCycle script (Not yet implemented)
		//Here, the gangs of the city fight for control of the map's nodes
		//foreach (GameObject node in nodeList) {
		List<NodeDetails> tempNodeDeetsGroup = new List<NodeDetails>();
		foreach (GameObject node in nodeList) {
			NodeDetails tempNodeDeets = node.GetComponent<NodeDetails>();
			if (!tempNodeDeets.battlingForControl) {
				tempNodeDeetsGroup.Add(tempNodeDeets);
			}
		}

		if (tempNodeDeetsGroup.Count > 0) {
			NodeDetails nodeDeets = nodeList[Random.Range(0, nodeList.Count)].GetComponent<NodeDetails>();//node.GetComponent<NodeDetails>();
		

			List<GameObject> enemyNeighbors = new List<GameObject>();

			foreach (GameObject neighbor in nodeDeets.myNeighbors) {
				NodeDetails possibleEnemyDeets = neighbor.GetComponent<NodeDetails>();
				if (possibleEnemyDeets.myGang != nodeDeets.myGang && !possibleEnemyDeets.battlingForControl && !possibleEnemyDeets.isGangHQ) {
					enemyNeighbors.Add(neighbor);
				}
			}

			if (enemyNeighbors.Count > 0) {
				GameObject neighborToFight = enemyNeighbors[Random.Range(0, enemyNeighbors.Count)];
				NodeDetails neighborDeets = neighborToFight.GetComponent<NodeDetails>();

				//if (/*!neighborDeets.battlingForControl &&*/ nodeDeets.myGang != neighborDeets.myGang) {
				Debug.Log(nodeDeets.gameObject.name + " fighting with " + neighborToFight.name);
				nodeDeets.battlingForControl = true;
				neighborDeets.battlingForControl = true;
				//int isKeepingControl = Random.Range(0, 2);

	///TOEVENTUALLYDO The following can basically be condensed into "if(Random.value > .5f /*&& !neighborDeets.isGangHQ*/) {WIN GANG WAR} else {NOTHING HAPPENS}
	/// Unless the player themselves needs to know SPECIFICALLY why a particular gang war failed, which is unlikely
				if (Random.value < .25f) {
					Debug.Log("Gang War ended in a stalemate! I was unable to take control!");
				}
				else {
					///The attacking gang takes control of the neighboring node
					//neighborDeets.myGang = nodeDeets.myGang;
					nodeGangs[neighborDeets.nodeNum] = nodeDeets.myGang;
					neighborDeets.SetMyGangInfluence();
					Debug.Log(nodeDeets.myGang + " took control of " + neighborToFight.name);

		//if (!nodeDeets.isGangHQ) {
		//			nodeGangs[nodeDeets.nodeNum] = neighborDeets.myGang;
		//			nodeDeets.SetMyGangInfluence();
		//			Debug.Log(nodeDeets.gameObject.name + ": I lost control of my territory!");
		//		}
		//		else {
		//			Debug.Log("This is my gang's home base! I can't lose!");
		//			//int isTakingControl = Random.Range(0, 2);
		//			if (Random.value > .5f) {
		//				Debug.Log(nodeDeets.gameObject.name + ": I was unable to take control!");
		//			}
		//			else {
		//				//nodeGangs[neighborDeets.nodeNum] = nodeDeets.myGang;
		//				neighborDeets.myGang = nodeDeets.myGang;
		//				neighborDeets.SetMyGangInfluence();
		//				Debug.Log(nodeDeets.gameObject.name + ": I was able to take control of " + neighborToFight.name);
		//			}
				//}
				}
			}
			else {
				Debug.Log(nodeDeets.gameObject.name + ": All neighbors are busy/friendly. No gang war here tonight");
				//No battling with the chosen neighbor
				//Choose another?
			}
		}
		else {
			Debug.Log("All nodes are busy. No gang war tonight");
		}
		//}

		
	}
}
