using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCube : MonoBehaviour
{
    public enum LevelSelect {
    	MainMenu,
    	Level1,
	Level2,
	Level3
    }
    public LevelSelect lvlSel;
    private string sceneName;
    void OnCollisionEnter(Collision collision)
    {
    	Debug.Log(collision.collider.name);
        if(collision.collider.name == "Player") {
            evalScene(this.lvlSel);
            LoadManager.Instance.LoadScene(sceneName, false);
            Debug.Log("Player collide");
        }
    }
    
    private void evalScene(LevelSelect level) {
    	switch(level) {
    		case LevelSelect.MainMenu:
    			sceneName = SceneNames.MAIN_SCENE;
    			break;
    		case LevelSelect.Level1:
    			sceneName = SceneNames.LEVEL_ONE;
    			break;
		case LevelSelect.Level2:
			sceneName = SceneNames.LEVEL_TWO;
			break;
		case LevelSelect.Level3:
			sceneName = SceneNames.LEVEL_THREE;
			break;
    		default:
    			Debug.Log("[ERROR]");
    			break;
    	}
    }
}
