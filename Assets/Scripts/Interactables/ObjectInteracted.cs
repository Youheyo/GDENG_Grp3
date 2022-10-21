using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectInteracted : MonoBehaviour
{

	[SerializeField] private GameObject affectedObject;
	[SerializeField] private string objName;

	public void onInteract()
	{
		EventBroadcaster.Instance.PostEvent(objName + "_PRESSED");
		Debug.Log(objName + "_PRESSED");
		if(objName == "NOTE")
		{
			this.NotePickUp();
		}
	}

	private void Awake()
	{
		if(objName.Length <= 0) {
			objName = this.name;
		}
		switch(this.objName + "_PRESSED")
		{
			case EventNames.RPG_Level_Interactables.BUTTON_1_PRESSED:
				EventBroadcaster.Instance.AddObserver(EventNames.RPG_Level_Interactables.BUTTON_1_PRESSED, disableAffectedObject);
				break;
			case EventNames.RPG_Level_Interactables.BUTTON_2_PRESSED:
				EventBroadcaster.Instance.AddObserver(EventNames.RPG_Level_Interactables.BUTTON_2_PRESSED, disableAffectedObject);
				break;
			case EventNames.RPG_Level_Interactables.CHEST_1_PRESSED:
				EventBroadcaster.Instance.AddObserver(EventNames.RPG_Level_Interactables.CHEST_1_PRESSED, disableAffectedObject);
				break;
		}
	}

	private void OnDestroy()
	{
	// Either replace with RemoveAllObserver (or whatever that sounded familiar with it
	// or refactor so that observers could be removed properly.
        EventBroadcaster.Instance.RemoveObserver(EventNames.RPG_Level_Interactables.BUTTON_1_PRESSED);
	}
	
	private void disableAffectedObject()
	{
		affectedObject.SetActive(!affectedObject.activeSelf);
	}

	private void NotePickUp()
	{
		Debug.Log(SceneManager.GetActiveScene().name);
		switch(SceneManager.GetActiveScene().name)
		{
			case "Level1":
				Debug.Log("Found note for level 1");
				PlayerDataManager.notesFoundLevel1++;
				this.gameObject.SetActive(false);
				if (PlayerDataManager.notesFoundLevel1 == 7) winningCondition();
				break;
			case "Level2":
				PlayerDataManager.notesFoundLevel2++;
				if (PlayerDataManager.notesFoundLevel2 == 7) winningCondition();
				break;
			case "Level3":
				PlayerDataManager.notesFoundLevel3++;
				if (PlayerDataManager.notesFoundLevel3 == 7) winningCondition();
				break;
			default:
				Debug.Log("Level not found, unable to add to note count");
				break;
		}
	}
	
	private void winningCondition()
	{
		//PlayerDataManager.notesFound++;
		Debug.Log("Should be returning to hub scene");
		LoadManager.Instance.LoadScene(SceneNames.HUB_SCENE, false);
	}
}
