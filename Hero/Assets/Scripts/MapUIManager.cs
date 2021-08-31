using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapUIManager : MonoBehaviour {

	[SerializeField] MapSceneManager mapSceneMan;
	[SerializeField] MapMovement mapMover;

	[SerializeField] GameObject activityBG;
	[SerializeField] Text gangText;
	[SerializeField] Text activityText;
	[SerializeField] Text DifficultyText;

	[SerializeField] Image policeAlertBG;
	public Text policeAlertText;
	Color bgOnColor = new Color(1, 1, 1, .2f);
	Color bgOffColor = new Color(1, 1, 1, 0f);


	void Awake() {
        
    }


    void Update() {
        
    }


	public void OpenUI(GameObject UItoOpen) {
		UItoOpen.SetActive(true);
	}


	public void CloseUI(GameObject UItoClose) {
		UItoClose.SetActive(false);

		mapMover.canChangeNodes = true;
	}


	public void OpenActivityUI(Color textColor) {
		gangText.text = CrimeManager.gangInvolved.ToString();
		activityText.text = CrimeManager.activity.ToString();
		DifficultyText.text = CrimeManager.crimeStars;

		DifficultyText.color = textColor;

		OpenUI(activityBG);
	}
}
