using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectiveUIManager : MonoBehaviour {

	[SerializeField] UIManager UIMan;
	[SerializeField] GameObject computerUI;


	[Header("Location Selections", order = 0)]
	[SerializeField] Image locationImage;
	[SerializeField] Sprite[] locationImages;
	[SerializeField] Text locationText;
	[SerializeField] string[] locationNames;
	static int selectedLocationIndex = 1;
	ClueMaster.locations selectedLocation;
	[SerializeField] Text locationClueText1;
	[SerializeField] Text locationClueText2;
	[SerializeField] Text locationClueText3;

	[Header("Gang Selections", order = 0)]
	[SerializeField] Image gangImage;
	[SerializeField] Sprite[] gangImages;
	[SerializeField] Text gangText;
	[SerializeField] string[] gangNames;
	static int selectedGangIndex = 1;
	ClueMaster.gangs selectedGang;
	[SerializeField] Text gangClueText1;
	[SerializeField] Text gangClueText2;
	[SerializeField] Text gangClueText3;


	[Header("Attack Selections", order = 0)]
	[SerializeField] Image attackImage;
	[SerializeField] Sprite[] attackImages;
	[SerializeField] Text attackText;
	[SerializeField] string[] attackNames;
	static int selectedAttackIndex = 1;
	ClueMaster.attackTypes  selectedAttack;
	[SerializeField] Text attackClueText1;
	[SerializeField] Text attackClueText2;
	[SerializeField] Text attackClueText3;


	void Start () {
		SelectLocation(0);
		SelectGang(0);
		SelectAttack(0);

		DisplayClueTexts();
	}


	void DisplayClueTexts() {
		locationClueText1.text = ClueMaster.knownLocationClues[0];
		locationClueText2.text = ClueMaster.knownLocationClues[1];
		locationClueText3.text = ClueMaster.knownLocationClues[2];

		gangClueText1.text = ClueMaster.knownGangClues[0];
		gangClueText2.text = ClueMaster.knownGangClues[1];
		gangClueText3.text = ClueMaster.knownGangClues[2];

		attackClueText1.text = ClueMaster.knownAttackTypeClues[0];
		attackClueText2.text = ClueMaster.knownAttackTypeClues[1];
		attackClueText3.text = ClueMaster.knownAttackTypeClues[2];
	}


	public void SelectLocation(int direction) {
		selectedLocationIndex += direction;

		if (selectedLocationIndex < 1) {
			selectedLocationIndex = locationImages.Length -1;
		}
		else if (selectedLocationIndex >= locationImages.Length) {
			selectedLocationIndex = 1;
		}

		selectedLocation = (ClueMaster.locations)System.Enum.GetValues(typeof(ClueMaster.locations)).GetValue(selectedLocationIndex);
		print(selectedLocation.ToString());

		locationText.text = locationNames[selectedLocationIndex];
		locationImage.sprite = locationImages[selectedLocationIndex];
	}


	public void SelectGang (int direction) {
		selectedGangIndex += direction;

		if (selectedGangIndex < 1) {
			selectedGangIndex = gangImages.Length - 1;
		}
		else if (selectedGangIndex >= gangImages.Length) {
			selectedGangIndex = 1;
		}

		selectedGang = (ClueMaster.gangs) System.Enum.GetValues(typeof(ClueMaster.gangs)).GetValue(selectedGangIndex);
		print(selectedGang.ToString());

		gangText.text = gangNames[selectedGangIndex];
		gangImage.sprite = gangImages[selectedGangIndex];
	}


	public void SelectAttack (int direction) {
		selectedAttackIndex += direction;

		if (selectedAttackIndex < 1) {
			selectedAttackIndex = attackImages.Length - 1;
		}
		else if (selectedAttackIndex >= attackImages.Length) {
			selectedAttackIndex = 1;
		}

		selectedAttack = (ClueMaster.attackTypes) System.Enum.GetValues(typeof(ClueMaster.attackTypes)).GetValue(selectedAttackIndex);
		print(selectedAttack.ToString());

		attackText.text = attackNames[selectedAttackIndex];
		attackImage.sprite = attackImages[selectedAttackIndex];
	}


	public void ConfirmSelections() {
	///Check if ALL of the selected "detective options" match the current event's parameters, by matching the ClueMaster enums above
		bool allMatches = true;

		if (selectedLocation != ClueMaster.location) {
			//ClueMaster.matchLocation = true;
			allMatches = false;
		}

		if (selectedGang != ClueMaster.gang) {
			//ClueMaster.matchGang = true;
			allMatches = false;
		}

		if (selectedAttack != ClueMaster.attackType) {
			//ClueMaster.matchAttackType = true;
			allMatches = false;
		}

		print("Location match: " + ClueMaster.matchLocation + " | Gang Match: " + ClueMaster.matchGang + " | Attack match: " + ClueMaster.matchAttackType);

		if (allMatches) {
			ClueMaster.UncoverEvent();

			UIMan.OpenUI(computerUI);
			UIMan.CloseUI(gameObject);

			UIMan.DetermineDetectiveUIAccess();
		}
	}
}
