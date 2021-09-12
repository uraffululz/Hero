using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class ArenaSceneManager : MonoBehaviour {

	GameObject player;
	GameObject sidekick;

	[SerializeField] GameObject enemyPrefab;
	[SerializeField] GameObject civilianPrefab;

	[Header("UI")]
	[SerializeField] ArenaSceneUIManager arenaUIMan;


	bool activityStarted = false;

	int enemySpawnNum = 1; //For now
	int civSpawnNum = 3; //For now

	public List<GameObject> enemies;
	public List<GameObject> civilians;

	[SerializeField] public List<Bounds> spawnBounds;

	public int gainedNotoriety = 0;
	float HTNotorietyAdjustment = 1.5f;


	private void Awake() {
		//string activityName = "";
		//string gangName = "";

		SceneSetup();//ref activityName, ref gangName);
		arenaUIMan.OpenActivityStartUI();//activityName, gangName);

		//player = GameObject.FindWithTag("Player");
		//sidekick = GameObject.FindWithTag("Sidekick");

		//spawnBounds = new List<Bounds>();

		//if (player != null) {
		//	//Vector3 playerSpawnPos = new Vector3(10, 0, 10);
		//	//player.transform.position = playerSpawnPos;
		//	///player.GetComponent<HeroActivity>().enabled = true;
		//	///player.GetComponent<HeroAttack>().enabled = true;
		//	///player.GetComponent<PlayerInteracting>().enabled = false; //until I can figure out how to use the "scene loading" events

		//	spawnBounds.Add(player.GetComponent<CapsuleCollider>().bounds);
		//}

		//if (sidekick != null) {
		//	sidekick.transform.position = Vector3.right;

		//	spawnBounds.Add(sidekick.GetComponent<CapsuleCollider>().bounds);

		//}

		//SpawnCivilians();
		//SpawnEnemies();
	}


	void Start () {
		//enemies = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
		//civilians = new List<GameObject>(GameObject.FindGameObjectsWithTag("Civilian"));
	}


	void Update () {
		if (Keyboard.current.spaceKey.wasPressedThisFrame) {
			if (activityStarted) {
				ActivityCompletion(true);
			}
			else {
				arenaUIMan.CloseActivityStartUI();
				activityStarted = true;
			}
		}

		if (Keyboard.current.fKey.wasPressedThisFrame) {
			arenaUIMan.CloseActivityStartUI();
			ActivityCompletion(false);
		}
	}


	void SceneSetup(){//ref string activityType, ref string gangType) {
		GangSetup(CrimeManager.gangInvolved);
		ActivitySetup(CrimeManager.activity);
	}


	void ActivitySetup (ClueMaster.attackTypes activity) {
		activity = ClueMaster.attackTypes.none;

		switch (activity) {
			case ClueMaster.attackTypes.none:
				if (CrimeManager.isEvent) {
					print("Event activity setup");
				}
				else if (CrimeManager.isHighTier) {
					print("High Tier activity setup");
				}
				else {
					print("Regular actvity setup");
				}
				break;
			case ClueMaster.attackTypes.Arson:
				break;
			case ClueMaster.attackTypes.Bomb_Threat:
				break;
			case ClueMaster.attackTypes.Chemical_Attack:
				break;
			case ClueMaster.attackTypes.Hostage_Situation:
				break;
			case ClueMaster.attackTypes.Kidnapping:
				break;
			case ClueMaster.attackTypes.Mass_Shooting:
				break;
			case ClueMaster.attackTypes.Robbery:
				break;
			case ClueMaster.attackTypes.Vandalism:
				break;
			default:
				Debug.LogError("YOU FUCKED UP HERE");
				break;
		}

		//return activity.ToString();
		arenaUIMan.startActivityText.text = "Activity: " + activity;

	}


	void GangSetup(ClueMaster.gangs gang) {
		List<GameObject> gangUnits = new List<GameObject>();

		switch (gang) {
			case ClueMaster.gangs.none:
				break;
			case ClueMaster.gangs.The_Jackals:
				break;
			case ClueMaster.gangs.The_Clone_Army:
				break;
			case ClueMaster.gangs.The_Eldritch:
				break;
			case ClueMaster.gangs.The_Leslies:
				break;
			default:
				///gangUnits = [List of gang units from a separate "GangManager" script]
				SpawnEnemies(gangUnits);
				break;
		}

		//return gang.ToString();
		arenaUIMan.startGangText.text = "Gang: " + gang;

	}


	//void SpawnCivilians () {
	//	for (int c = 0; c < civSpawnNum; c++) {
	//		//TOMAYBEDO Adjust the civilian spawn points to that they are closer to an enemy (May need to declare their lists up here first)
	//		float civSpawnX = Random.Range(-10, 10);
	//		float civSpawnZ = Random.Range(-10, 10);
	//		Vector3 civSpawnPoint = new Vector3(civSpawnX, 0, civSpawnZ);

	//		GameObject spawnedCiv = Instantiate(civilianPrefab, civSpawnPoint, Quaternion.identity);

	//		foreach (Bounds colBounds in spawnBounds) {
	//			if (spawnedCiv.GetComponent<CapsuleCollider>().bounds.Intersects(colBounds)) {
	//				Destroy(spawnedCiv);
	//				c--;
	//			}
	//		}

	//		if (spawnedCiv != null) {
	//			spawnBounds.Add(spawnedCiv.GetComponent<CapsuleCollider>().bounds);
	//			spawnedCiv.transform.LookAt(Vector3.zero);
	//		}
	//	}
	//}


	void SpawnEnemies (List<GameObject> unitList) {
		enemies = new List<GameObject>();

///TODO Adjust enemy unit stats based on CrimeManager.currentCrimeRate

	//	for (int e = 0; e < enemySpawnNum; e++) {
	//		float enemySpawnX = Random.Range(-10, 10);
	//		float enemySpawnZ = Random.Range(-10, 10);
	//		Vector3 enemySpawnPoint = new Vector3(enemySpawnX, 0, enemySpawnZ);

	//		GameObject spawnedEnemy = Instantiate(enemyPrefab, enemySpawnPoint, Quaternion.identity);

	//		foreach (Bounds colBounds in spawnBounds) {
	//			if (spawnedEnemy.GetComponent<CapsuleCollider>().bounds.Intersects(colBounds)) {
	//				Destroy(spawnedEnemy);
	//				e--;
	//			}
	//		}

	//		if (spawnedEnemy != null) {
	//			spawnBounds.Add(spawnedEnemy.GetComponent<CapsuleCollider>().bounds);
	//			spawnedEnemy.transform.LookAt(Vector3.zero);
	//		}
	//	}
	}


	public void ActivityCompletion(bool succeeded) {//, string notorietyText) {
		string completionText = "";
		//string eventText = "";
		string clueText = "";
		string notorietyText = "";
		Color completionColor = Color.white;

		int baseNotoriety = 10 * CrimeManager.currentCrimeRate;

		if (succeeded) {
			completionText = "ACTIVITY SUCCEEDED";
			//gainedNotoriety += (CrimeManager.isHighTier) ? (int)150 * CrimeManager.currentCrimeRate : (int)100 * CrimeManager.currentCrimeRate;
			//print("High Tier = " + CrimeManager.isHighTier + "Difficulty: " + CrimeManager.currentCrimeRate + " | " + "Notoriety = " + gainedNotoriety);

			clueText = DetermineEventProgress();

///Keep the following if-statement for later, when obtaining a clue after success is not 100% guaranteed
			///if (ClueMaster.eventOngoing) {
				if (CrimeManager.isEvent) {
				baseNotoriety *= (int) 2f;

				clueText = "";
					completionText = "EVENT COMPLETED";
					completionColor = Color.green;
					//ClueMaster.EventSuccess();
					ClueMaster.ResetEvent();
				}
				else if (CrimeManager.isHighTier) {
				baseNotoriety *= (int) 1.5f;

				completionColor = Color.yellow;
					//MapSceneManager.ResetHighTier();
				}
			///}
			///TOMAYBEDO In the case that there is no "else" concerning the status of ClueMaster.eventOngoing (basically if obtaining a clue is NOT 100% certain), combine the above "if" statements
		}
		else {
			//Debug.Log("Activity FAILED");
			completionText = "ACTIVITY FAILED";

			baseNotoriety  *= (int) -1f;
			//gainedNotoriety -= (CrimeManager.isHighTier) ? (int) 150 * CrimeManager.currentCrimeRate : (int) 100 * CrimeManager.currentCrimeRate;
			//print("High Tier = " + CrimeManager.isHighTier + "Difficulty: " + CrimeManager.currentCrimeRate + " | " + "Notoriety = " + gainedNotoriety);
			
			///if (ClueMaster.eventOngoing) {
				if (CrimeManager.isEvent) {
					clueText = "";
					completionText = "EVENT FAILED";
					completionColor = Color.red;
					//ClueMaster.EventFailure();
					ClueMaster.ResetEvent();
				}
				else {
					clueText = "No clue found";
				}
			///}
			///else {
			///	clueText = "No clue found";
			///}
		}

		//if (CrimeManager.isHighTier) {//CrimeManager.activityLoc == MapSceneManager.HTLocation) {// && NodeDetails.myHighTierActivity != ClueMaster.attackTypes.none) {
			//completionColor = Color.yellow;
			MapSceneManager.ResetHighTier();
		//}

		///Add the gainedNotoriety total to the player's notoriety stat and display both amounts (gains from activity, and total overall notoriety)
		///StatsPlayer.notoriety += gainedNotoriety;
		gainedNotoriety = baseNotoriety;
		string gainedOrLost = ((gainedNotoriety >= 0) ? "Notoriety gained: " : "Notoriety lost: ");
		notorietyText = (gainedOrLost + gainedNotoriety);/// + " || Total: " + StatsPlayer.notoriety);

		arenaUIMan.OpenCompletionDisplay(completionText, clueText, notorietyText, completionColor);
	}

	#region Hopefully Obsolete Code

	//public void ActivitySuccess () {
	//	//Debug.Log("Activity SUCCEEDED");
	//	completionText.text = "Activity Succeeded";

	//	clueText.text = "";
	//	eventResults.text = "One of the city's gangs is planning something big";

	//	DetermineEventProgress();

	//	if (ClueMaster.eventOngoing) {
	//		if (CrimeManager.isEvent) {
	//			///If the player has just successfully completed the ongoing event
	//			eventResults.text = "Event completed";
	//			ClueMaster.EventSuccess();
	//		}
	//		//#region TODO Reconcile this shit into something more efficient
	//		//			else {
	//		//				eventResults.text = ("One of the city's gangs is planning something big");
	//		//				DetermineEventProgress();
	//		//			}
	//		//		}
	//		//		else {
	//		//			//ClueMaster.ChooseEventParameters();
	//		//			DetermineEventProgress();

	//		//			eventResults.text = ("One of the city's gangs is planning something big");			
	//	}
	//		//#endregion

	//	FinishActivity();
	//}


	//public void ActivityFailed () {
	//	//Debug.Log("Activity FAILED");
	//	completionText.text = "Activity Failed";
	//	gainedNotoriety -= 100 * CrimeManager.currentCrimeRate;

	//	if (ClueMaster.eventOngoing) {
	//		if (CrimeManager.isEvent) {
	//			eventResults.text = "Event failed";
	//			ClueMaster.EventFailure();
	//		}
	//	}
	//	else {
	//		clueText.text = "No clue found";
	//	}

	//	FinishActivity();
	//}


	//void FinishActivity() {
	//	if (CrimeManager.activityLoc == MapSceneManager.HTLocation) {// && NodeDetails.myHighTierActivity != ClueMaster.attackTypes.none) {

	//		MapSceneManager.ResetHighTier();
	//	}

	//	///Display "activity completion" UI menu
	//	completionDisplay.gameObject.SetActive(true);
	//	//completionDisplay.GetComponent<Animator>().SetBool("compActivated", true);

	//	///Add the gainedNotoriety total to the player's notoriety stat and display both amounts
	//	///StatsPlayer.notoriety += gainedNotoriety;
	//	string gainedOrLost = ((gainedNotoriety >= 0) ? "Notoriety gained: " : "Notoriety lost: ");
	//	notorietyText.text = (gainedOrLost + gainedNotoriety);/// + " || Total: " + StatsPlayer.notoriety);
	//}

	#endregion


	string DetermineEventProgress () {
		///%Chance of finding a clue is based on CrimeManager.currentCrimeRate
		
////TODO Knock down to 10% chance or so later (ALSO DO THE SAME ELSEWHERE, WHENEVER DETERMINING "chanceClueFound")
////or have it influenced by the activity's difficulty/rarity/whatever

//		int chanceClueFound = Random.Range(0, 100);

//		if (CrimeManager.isHighTier) {
//			//High-tier activities give the player a better chance to find a clue
//			chanceClueFound = (int)(chanceClueFound / 2);
//		}

		//if (ClueMaster.eventOngoing) {
			if (ClueMaster.numberOfCluesFound < ClueMaster.maxNumberOfClues) {
//			if (CrimeManager.isHighTierActivityHere) {
//				//if (CrimeManager.gangInvolved == ClueMaster.gangInvolvedInEvent) {
//					if (chanceClueFound < 100) {
//						ClueMaster.GetAClue();
//						//Display each clue when found
//						clueText.text = ("Clue found: " + ClueMaster.mostRecentClue);
//					}
//				//}
//			}
//			else {
//				//if (NightManager.gangInvolved == ClueMaster.gangInvolvedInEvent) {
//					if (chanceClueFound < 100) {
						ClueMaster.UncoverEventElement();
						//ClueMaster.GetAClue();
						///Display each clue when found
						return "Clue found: " + ClueMaster.mostRecentClue;
//					}
//				//}
//			}
			}	
			else {
				return "Max number of clues found. Access Hideout computer to solve event";
			}
		//}
		//else {

		//}
	}


	public void ReturnToMap () {
		//CrimeManager.isHighTierActivityHere = false;
		SceneManager.LoadScene(1);
	}


	public void ReturnToHideout () {
		//CrimeManager.isHighTierActivityHere = false;
		SceneManager.LoadScene(0);
	}
}
