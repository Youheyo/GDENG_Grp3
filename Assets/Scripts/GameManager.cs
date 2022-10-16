using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager sharedInstance = null;
	public static GameManager Instance {
		get {
			if (sharedInstance == null) {
				sharedInstance = new GameManager ();
			}

			return sharedInstance;
		}
	}
    
    private void Awake() {
    	DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void playBtn() {
    	LoadManager.Instance.LoadScene(SceneNames.HUB_SCENE, false);
    }
    
    public void quitBtn() {
    	LoadManager.Instance.LoadScene(SceneNames.MAIN_SCENE, false);
    }
}
