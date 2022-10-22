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

	[Header("Notes Found")]
	[SerializeField] private int NotesFoundAmt = 0;


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
		EventBroadcaster.Instance.AddObserver(EventNames.Note_Flags.NOTE_PICKED_UP, NotePickUp);
		//EventBroadcaster.Instance.AddObserver(EventNames.Note_Flags.NOTE_COMPLETED, RevealCompPanel);
		EventBroadcaster.Instance.AddObserver(EventNames.Flags.LEVEL_COMPLETED, setFlag);
	}

	// Functions added here should only be done if something needs to be checked every frame
	// Unless for debug purposes, do not add anything else here.
	void Update(){
		if (Input.GetKeyDown(KeyCode.P)) {
			Debug.Log("[DEBUG] - Note Increase");
			EventBroadcaster.Instance.PostEvent(EventNames.Note_Flags.NOTE_PICKED_UP);
			// Why? Just to flex the post events
			// Add Notes = NotePickUp()
			// InstaComplete = RevealCompPanel();
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

		// Resets note counter
		NotesFoundAmt = 0;
	}

	private void NotePickUp() {
		// string name = param.GetStringExtra("lvlName", "MISSINGNO");
		// Debug.Log("[DEBUG] Note gotten from: " + name);
		NotesFoundAmt++;
		if(NotesFoundAmt >= 7) {
			//EventBroadcaster.Instance.AddObserver(EventNames.Note_Flags.NOTE_COMPLETED, RevealCompPanel);
			RevealCompPanel();
		}
		if(LoadManager.Instance.GetSceneName() == "Level3" && NotesFoundAmt >= 1) {
			RevealCompPanel();
		}
		/*
		switch()
		{
			case "Level1":
				Debug.Log("Found note for level 1");
				PlayerDataManager.notesFoundLevel1++;
				if (PlayerDataManager.notesFoundLevel1 == 7) winningCondition();
				break;
			case "Level2":
				PlayerDataManager.notesFoundLevel2++;
				if (PlayerDataManager.notesFoundLevel2 == 7) winningCondition();
				break;
			case "Level3":
				PlayerDataManager.notesFoundLevel3++;
				if (PlayerDataManager.notesFoundLevel3 == 1) winningCondition();
				break;
			default:
				Debug.Log("Level not found, unable to add to note count");
				this.gameObject.SetActive(true);

				break;
		}
		*/
	}

	private void RevealCompPanel() {
		EventBroadcaster.Instance.PostEvent(EventNames.Goal_Notes.SHOW_COMPLETE_PANEL);
	}

	public int NotesFound() {
		return NotesFoundAmt;
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
