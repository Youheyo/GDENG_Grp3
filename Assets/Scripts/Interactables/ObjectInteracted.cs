using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteracted : MonoBehaviour
{

	[SerializeField] private GameObject affectedObject;
	[SerializeField] private string objName;

	public void onInteract()
	{
		EventBroadcaster.Instance.PostEvent(objName + "_PRESSED");
		Debug.Log(objName + "_PRESSED");
	}

	private void Awake()
	{
		if(objName.Length <= 0) {
			objName = this.name;
		}
		switch(this.name + "_PRESSED")
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
			case EventNames.Goal_Notes.LEVEL_1_PRESSED:
				EventBroadcaster.Instance.AddObserver(EventNames.Goal_Notes.LEVEL_1_PRESSED, winningCondition);
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
	
	private void winningCondition()
	{
		//PlayerDataManager.notesFound++;
		Debug.Log("Should be returning to hub scene");
		LoadManager.Instance.LoadScene(SceneNames.HUB_SCENE, false);
	}
}
