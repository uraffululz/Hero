using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArenaSceneUIManager : MonoBehaviour {

	//[SerializeField] ArenaSceneManager arenaSceneMan;
 
	[Header("Activity Start UI")]
	[SerializeField] GameObject activityStartBG;
	public Text startActivityText;
	public Text startGangText;
	public Text startDifficultyText;

	[Header("Activity Completion UI")]
	[SerializeField] GameObject completionDisplay;
	public Text completionText;
	public Text notorietyText;
	public Text eventResults;
	public Text clueText;



	void Start() {
        //OpenActivityStartUI();
    }

   

    void Update() {
        
    }


	public void OpenActivityStartUI(){//string activity, string gang) {
		activityStartBG.SetActive(true);
		//startActivityText.text = "Activity: " + activity;
		//startGangText.text = "Gang: " + gang;
		startDifficultyText.text = "Difficulty: " + CrimeManager.crimeStars;

	}


	public void CloseActivityStartUI() {
		activityStartBG.SetActive(false);
	}


	public void OpenCompletionDisplay() {
		///Display "activity completion" UI menu
		completionDisplay.SetActive(true);
		///completionDisplay.GetComponent<Animator>().SetBool("compActivated", true);


	}


}
