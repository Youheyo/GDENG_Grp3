using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubHandler : MonoBehaviour
{
	[Header("Toggable Structures")]

	[Header("endIsland")]
	[SerializeField] private GameObject endIsland;
	[SerializeField] private GameObject wallObst;

	[Header("Level3")]
	[SerializeField] private GameObject lvl3Gate; //Replace with a group similar to EndIsland if there's any other ideas.

	void Awake() {
		Debug.Log("Value: " + GameManager.Instance.getL3());
		UnlockEnd();
		Unlocklvl3();
	}

	private void UnlockEnd() {
		if(GameManager.Instance.getL3() == true) {
			wallObst.SetActive(false);
			endIsland.SetActive(true);
		}
	}

	private void Unlocklvl3() {
		if(GameManager.Instance.getL1() == true && GameManager.Instance.getL2() == true) {
			lvl3Gate.SetActive(true);
		}
	}
}
