using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuHandler : MonoBehaviour
{
    void Awake() {
    	Cursor.lockState = CursorLockMode.None;
    }
    public void playBtn() {
	if(GameManager.Instance.getTut() == false) {
		LoadManager.Instance.LoadScene(SceneNames.TUTORIAL_SCENE, false);
		Time.timeScale = 1;
	} else {
    		LoadManager.Instance.LoadScene(SceneNames.HUB_SCENE, false);
        	Time.timeScale = 1;
	}
    }
    
    public void quitBtn() {
    	Application.Quit();
    }
}
