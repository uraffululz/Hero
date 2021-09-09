using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public static class CrimeManager {

	public static ClueMaster.locations activityLoc;
	//public static string activitySceneToLoad;

	public static ClueMaster.gangs gangInvolved;
	
	public static ClueMaster.attackTypes activity;
	public static bool isEvent = true;
	public static bool isHighTier = false;

	public static int currentCrimeRate = 1;
	static int crimeRate;
	public static string crimeStars = "*";
	static bool HTCrimeRateSet = false;
	static int HTCrimeRate;
	static int eventCrimeRate;
	static bool eventCrimeRateSet = false;

	public static int enemyHPBonus = 0;
	public static int enemyFPBonus = 0;
	public static int enemyStrBonus = 0;
	public static int enemyAgiBonus = 0;
	public static int enemyIntBonus = 0;
	public static int enemyNotBonus = 0;

	public static int baseFatigueDmg = 0;
	public static int baseStressDmg = 0;

	public static int baseNotoriety = 0;

	

	public static void SetCrime (bool isAnEvent, bool isHT, ClueMaster.locations passedLoc, ClueMaster.gangs passedGang) {
		isEvent = isAnEvent;
		isHighTier = isHT;
		activityLoc = passedLoc;
		gangInvolved = passedGang;

		if (isEvent) {
			///An Event is happening here
			if (!eventCrimeRateSet) {
				eventCrimeRate = Random.Range(1, 6);
				//activityLoc = ClueMaster.location; //Redundant? (is declared above in this method)
				//gangInvolved = ClueMaster.gang; //Redundant? (is declared above in this method)
				//activity = ClueMaster.attackType;

				eventCrimeRateSet = true;
			}
			activity = ClueMaster.attackType;

			SetCrimeStars(eventCrimeRate);
		}
		else if (isHighTier) {
			///A High-Tier activity is happening here
			if (!HTCrimeRateSet) {
///TOMAYBEDO Create a persistent HTCrimeRate variable, like the "eventCrimeRate" used above, so that it doesn't change if the player leaves the node and returns
				HTCrimeRate = Random.Range(1, 6);
				//activityLoc = passedLoc;
				//gangInvolved = passedGang;
				//activity = passedAct;

				HTCrimeRateSet = true;
			}
			activity = MapSceneManager.HTActivity;
			SetCrimeStars(HTCrimeRate);
		}
		else {
			///Just a normal, random activity happening here
			int activityIndex = Random.Range(1, System.Enum.GetValues(typeof(ClueMaster.attackTypes)).Length);
			activity = (ClueMaster.attackTypes) activityIndex;
			crimeRate = Random.Range(1, 6);

			SetCrimeStars(crimeRate);
		}
		
		//SetHTActivityParameters(activity, enemyHPBonus, enemyFPBonus, enemyStrBonus, enemyAgiBonus, enemyIntBonus,
		//	crimeRate, baseFatigueDmg, baseStressDmg, baseNotoriety);
	}


	static void SetCrimeStars(int rate) {
		currentCrimeRate = rate;
		crimeStars = "";

		for (int i = 1; i <= rate; i++) {
			crimeStars += "*";
		}
	}


	//public static void SetHTActivityParameters (ClueMaster.attackTypes thisActivity, int HPBonus, int FPBonus, int strBonus, int agiBonus, int intBonus,
	//	int difficulty, int fatigue, int stress, int notoriety) {
	//	//TODO I don't think I need to pass in all these variables ^, since they don't immediately adjust when declaring the local-variable-versions
	//	//The locals could probably just be set at the start of this method (here), and later assigned (like they are now), without much difficulty
	//	//For now, I just want to keep going, but it's something to keep in mind

	//	switch (thisActivity) {
	//		/*		case "Arson":
	//					break;
	//				case "Bank Robbery":
	//					break;
	//				case "Bomb Threat":
	//					break;
	//				case "Chemical Attack":
	//					break;
	//				case "Kidnapping":
	//					break;
	//				case "Mass Shooting":
	//					break;
	//		*/
	//		default:
	//			if (isEvent) {
	//				//activitySceneToLoad = "SampleEventActivityScene";
	//				//TODO Adjust other "stat bonuses" and variables
	//				HPBonus = 30; FPBonus = 30;
	//				strBonus = 3 * difficulty; agiBonus = 3 * difficulty; intBonus = 3 * difficulty;
	//				notoriety += 20 * difficulty;
	//			}
	//			else {
	//				activitySceneToLoad = "SampleActivityArena";
	//				HPBonus = 20; FPBonus = 20; //Later, formulate these based on the activity's difficulty
	//				strBonus = 2 * difficulty; agiBonus = 2 * difficulty; intBonus = 2 * difficulty;
	//				//fatigue = difficulty; stress = difficulty;
	//				notoriety += 10 * difficulty;
	//			}

	//			break;
	//	}

	//	if (isEvent) {
	//		Debug.Log("An event is happening here! Get ready!");
	//	}


	//	/*		if (thisActivity == "Arson") {
	//				reqStr = 1; reqAgi = 2; reqInt = 3; fatigue = 5 * difficulty; stress = 2 * difficulty;
	//			}
	//			if (thisActivity == "Assault") {
	//				reqStr = 3; reqAgi = 2; reqInt = 1; fatigue = 2 * difficulty; stress = 1 * difficulty;
	//			}
	//			if (thisActivity == "Bank Robbery") {
	//				reqStr = 1; reqAgi = 1; reqInt = 3; fatigue = 3 * difficulty; stress = 3 * difficulty;
	//			}
	//			if (thisActivity == "Burglary") {
	//				reqStr = 1; reqAgi = 2; reqInt = 3; fatigue = 1 * difficulty; stress = 3 * difficulty;
	//			}
	//			if (thisActivity == "Kidnapping") {
	//				reqStr = 1; reqAgi = 1; reqInt = 3; fatigue = 1 * difficulty; stress = 10 * difficulty;
	//			}
	//			if (thisActivity == "Mugging") {
	//				reqStr = 2; reqAgi = 2; reqInt = 1; fatigue =  2 * difficulty; stress = 2 * difficulty;
	//			}
	//			if (thisActivity == "Robbery") {
	//				reqStr = 2; reqAgi = 2; reqInt = 1; fatigue = 3 * difficulty; stress = 1 * difficulty;
	//			}
	//			if (thisActivity == "Runaway Train") {
	//				//Stuff like this might be considered "mass casualties", which may severely damage the character's stress
	//				reqStr = 1; reqAgi = 1; reqInt = 3; fatigue = 5 * difficulty; stress = 5 * difficulty;
	//			}

	//			reqStr += difficulty;
	//			reqAgi += difficulty;
	//			reqInt += difficulty;
	//	*/

	//	//TOMAYBEDO The required stats can be further randomized by Random.Range-ing them between 50% and 150% (or whatever range works)

	//	//TODO Actually, if getting rid of the activity2 and activity3 variables, this \/ may be obsolete
	//	//TODO See if there is a more efficient way to return/apply these values to their proper variables
	//	//Maybe by altering the return-type of the function or whatever. This works for now.
	//	enemyHPBonus = HPBonus;
	//	enemyFPBonus = FPBonus;
	//	enemyStrBonus = strBonus;
	//	enemyAgiBonus = agiBonus;
	//	enemyIntBonus = intBonus;
	//	enemyNotorietyBonus = notoriety;
	//	//baseFatigueDmg = fatigue;
	//	//baseStressDmg = stress;

	//	//Debug.Log("High-Tier parameters set");
	//}


	public static void ResetValues () {
		//isHighTierActivityHere = false;
		activityLoc = ClueMaster.locations.none;
		gangInvolved = ClueMaster.gangs.none;
		activity = ClueMaster.attackTypes.none;
		HTCrimeRateSet = false;
		eventCrimeRateSet = false;

		enemyHPBonus = 0;
		enemyFPBonus = 0;

		enemyStrBonus = 0;
		enemyAgiBonus = 0;
		enemyIntBonus = 0;
		enemyNotBonus = 0;

		baseFatigueDmg = 0;
		baseStressDmg = 0;

		//baseNotoriety = 0; Unnecessary, because it's ALWAYS 0 anyway
	}
}
