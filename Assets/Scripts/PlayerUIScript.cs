using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerUIScript : MonoBehaviour
{
	[SerializeField] private TMP_Text noteCountText;
	[SerializeField] private GameObject menuPanel;
	[SerializeField] private Button resumeButton;
	[SerializeField] private Button quitButton;

	private int noteCount = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
		switch (SceneManager.GetActiveScene().name)
		{
			case "Level1":
				noteCount = PlayerDataManager.notesFoundLevel1;
				break;
			case "Level2":
				noteCount = PlayerDataManager.notesFoundLevel2;
				break;
			case "Level3":
				noteCount = PlayerDataManager.notesFoundLevel3;
				break;
			
		}
		noteCountText.text = "Notes found: " + noteCount.ToString();
		if (Input.GetButtonDown("Cancel"))
		//if(Input.GetKeyDown(KeyCode.Q))
		{
			pauseScreen();
		}
    }

	public void pauseScreen()
	{
		menuPanel.SetActive(!menuPanel.activeSelf);
		if (menuPanel.activeSelf)
		{
			Time.timeScale = 0.0f;
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}
		else
		{
			Time.timeScale = 1.0f;
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;

		}
	}

	public void resumeGame()
	{
		Time.timeScale = 1.0f;
		menuPanel.SetActive(false);
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.None;

	}

	public void GoToMainMenu()
	{
		SceneManager.LoadScene(0);
	}

}
