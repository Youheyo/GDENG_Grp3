using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager sharedInstance = null;
	public static GameManager Instance {
		get {
			if (sharedInstance == null) {
				//Debug.Log("Instance shouldn't be null");
				sharedInstance = new GameManager();
				//Debug.Log("Initiated: " + sharedInstance);
			}

			return sharedInstance;
		}
		set {
			sharedInstance = new GameManager();
		}
	}
	
	// Declare variables here
	[Header("Level Done Flags")]
	[SerializeField] private bool isL1Done = false;
	[SerializeField] private bool isL2Done = false;
	[SerializeField] private bool isL3Done = false;

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
		
		// Declare other stuff here if needed
		// Usually some initiative stuff just
		// in case we did something that persists
		// for sessions.
		EventBroadcaster.Instance.AddObserver(EventNames.Flags.LEVEL_COMPLETED, setFlag);
	}

	// Functions added here should only be done if something needs to be checked every frame
	// Unless for debug purposes, do not add anything else here.
	void Update(){
		if (Input.GetKeyDown(KeyCode.P)) {
			Debug.Log("[DEBUG] - Instant complete");
			EventBroadcaster.Instance.PostEvent(EventNames.Goal_Notes.LEVEL_1_COMPLETE);
		}
	}

	private void setFlag(Parameters param) {
		string name = param.GetStringExtra("levelName", "MISSINGNO");
		Debug.Log("[DEBUG] Retrieved Name from Event: " + name);
		if(name != "MISSINGNO") {
			switch(name) {
				case "Level1":
					isL1Done = true;
					break;
				case "Level2":
					isL2Done = true;
					break;
				case "Level3":
					isL3Done = true;
					break;
				default:
					Debug.Log("[ERROR] - Wrong/Inexistent Scene retrieved for switch statement");
					break;
			}
		}

	}

	public bool getL1() {
		return isL1Done;
	}

	public bool getL2() {
		return isL2Done;
	}

	public bool getL3() {
		return isL3Done;
	}
    
    
}
