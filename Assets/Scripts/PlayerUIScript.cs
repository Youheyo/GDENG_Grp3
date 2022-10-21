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
	[SerializeField] private GameObject completePanel;

	private int noteCount = 0;

	void Awake() {
		if(SceneManager.GetActiveScene().name != "MainMenu" ||
		SceneManager.GetActiveScene().name != "HubScene") {
		EventBroadcaster.Instance.AddObserver(EventNames.Goal_Notes.LEVEL_1_COMPLETE, tempWin);
		}
	}

	private void OnDestroy() {
	// [NOTE] If truly using this (playerUI) script to add events 
	// or adding events on another script instead
	// please remember to properly remove observers. If
	// you encounter a bug that your object is destroyed 
	// yet you're absolutely certain that the reference/object 
	// exists then try to consider that the observer might
	// be conflicting itself.
	Debug.Log("[PLAYER EVENT DEBUG] - DESTROYED");
	EventBroadcaster.Instance.RemoveObserver(EventNames.Goal_Notes.LEVEL_1_COMPLETE);
	}

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

	// This is a debug function
	// should load levelComplete instead
	// if there are other functionality to implement
	// either add to levelComplete function 
	// or on the goToHub button, whichever
	// or however winning will be implemented.
	public void tempWin() {
		// There should be a post event here indicating
		// that specific level has been finished or use the 
		// gameManager directly to modify a variable
		// indicating level has been finished
		// so that we dont have to make 3 copies of the same
		// function just to clarify the level is finished
		Parameters param = new Parameters();
		param.PutExtra("levelName", SceneManager.GetActiveScene().name);
		EventBroadcaster.Instance.PostEvent(EventNames.Flags.LEVEL_COMPLETED, param);
		LoadManager.Instance.LoadScene(SceneNames.HUB_SCENE, false);
	}

	public void LevelComplete() {
		if(completePanel.gameObject == null) {
			Debug.Log("Somehow completePanel is null");
			Debug.Log(completePanel);
			Transform panel = transform.Find("LevelCompletePanel");
			Debug.Log("Found: " + panel);
		}
		completePanel.SetActive(!completePanel.activeSelf);
		if (completePanel.activeSelf)
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
		LoadManager.Instance.LoadScene(SceneNames.MAIN_SCENE, false);
	}

	public void GoToHub() {
		LoadManager.Instance.LoadScene(SceneNames.HUB_SCENE, false);
	}

}
