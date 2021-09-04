using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectiveUIManager : MonoBehaviour {

	[Header("Location Selections", order = 0)]
	[SerializeField] Image locationImage;
	[SerializeField] Sprite[] locationImages;
	[SerializeField] Text locationText;
	[SerializeField] string[] locationNames;
	int currentSelectedLocation = 0;
	ClueMaster.locations selectedLocation;
	[SerializeField] Text locationClueText1;
	[SerializeField] Text locationClueText2;
	[SerializeField] Text locationClueText3;

	[Header("Gang Selections", order = 0)]
	[SerializeField] Image gangImage;
	[SerializeField] Sprite[] gangImages;
	[SerializeField] Text gangText;
	[SerializeField] string[] gangNames;
	int currentSelectedGang = 0;
	ClueMaster.gangs selectedGang;
	[SerializeField] Text gangClueText1;
	[SerializeField] Text gangClueText2;
	[SerializeField] Text gangClueText3;


	[Header("Attack Selections", order = 0)]
	[SerializeField] Image attackImage;
	[SerializeField] Sprite[] attackImages;
	[SerializeField] Text attackText;
	[SerializeField] string[] attackNames;
	int currentSelectedAttack = 0;
	ClueMaster.attackTypes  selectedAttack;
	[SerializeField] Text attackClueText1;
	[SerializeField] Text attackClueText2;
	[SerializeField] Text attackClueText3;


	void Start () {
		SelectLocation(0);
		SelectGang(0);
		SelectAttack(0);
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
		currentSelectedLocation += direction;

		if (currentSelectedLocation < 0) {
			currentSelectedLocation = locationImages.Length -1;
		}
		else if (currentSelectedLocation >= locationImages.Length) {
			currentSelectedLocation = 0;
		}

		print(currentSelectedLocation);

		locationText.text = locationNames[currentSelectedLocation];
		locationImage.sprite = locationImages[currentSelectedLocation];

///TOALSODO Pass in the correct location enum from the ClueMaster
		///selectedLocation = ClueMaster.locations.none;
	}


	public void SelectGang (int direction) {
		currentSelectedGang += direction;

		if (currentSelectedGang < 0) {
			currentSelectedGang = gangImages.Length - 1;
		}
		else if (currentSelectedGang >= gangImages.Length) {
			currentSelectedGang = 0;
		}

		print(currentSelectedGang);

		gangText.text = gangNames[currentSelectedGang];
		gangImage.sprite = gangImages[currentSelectedGang];
///TOALSODO Pass in the correct gang enum from the ClueMaster

	}


	public void SelectAttack (int direction) {
		currentSelectedAttack += direction;

		if (currentSelectedAttack < 0) {
			currentSelectedAttack = attackImages.Length - 1;
		}
		else if (currentSelectedAttack >= attackImages.Length) {
			currentSelectedAttack = 0;
		}

		print(currentSelectedAttack);

		attackText.text = attackNames[currentSelectedAttack];
		attackImage.sprite = attackImages[currentSelectedAttack];
///TOALSODO Pass in the correct attack enum from the ClueMaster

	}


	public void ConfirmSelections() {
//TODO Check if ALL of the selected "detective options" match the current event's parameters, by matching the ClueMaster enums above
		ClueMaster.matchLocation = true;
		ClueMaster.matchGang = true;
		ClueMaster.matchAttackType = true;
	}
}
