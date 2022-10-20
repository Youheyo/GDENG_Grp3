using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager sharedInstance = null;
	public static GameManager Instance {
		get {
			if (sharedInstance == null) {
				Debug.Log("Instance shouldn't be null");
				sharedInstance = new GameManager();
				Debug.Log("Initiated: " + sharedInstance);
			}

			return sharedInstance;
		}
		set {
			sharedInstance = new GameManager();
		}
	}
    public GameManager checkInstance() {
	return GameManager.Instance;
    } 
    
    private void Awake() {
	if(GameManager.Instance != null) {
		Debug.Log("Game Manager Detected! Deleting new copy");
		Destroy(gameObject);
		return;
	}
	
	sharedInstance = this;
    	DontDestroyOnLoad(gameObject);
    }
    
}
