using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
	[SerializeField] TMP_Text TitleText;
	[SerializeField] GameObject panel;
	[SerializeField] Sprite newSprite;

	private void Awake()
	{
		if (GameManager.Instance.getL3())
		{
			panel.GetComponent<Image>().sprite = newSprite;
			TitleText.text = "I finished my deadline and now I chill";
		}
	}
}
