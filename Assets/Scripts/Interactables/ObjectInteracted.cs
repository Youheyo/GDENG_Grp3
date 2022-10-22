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
		if(objName == "NOTE")
		{
			EventBroadcaster.Instance.PostEvent(EventNames.Note_Flags.NOTE_PICKED_UP);
			this.NotePickUp();
		}
	}

	void Awake()
	{
		if(objName.Length <= 0) {
			objName = this.name;
		}
		/*
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
		*/

		// Debug, should be removed later 
		//EventBroadcaster.Instance.AddObserver(EventNames.Goal_Notes.LEVEL_1_COMPLETE, winningCondition);
	}

	private void OnDestroy()
	{
	// Either replace with RemoveAllObserver (or whatever that sounded familiar with it
	// or refactor so that observers could be removed properly.
	//EventBroadcaster.Instance.RemoveAllObservers();
	}
	
	private void disableAffectedObject()
	{
		affectedObject.SetActive(!affectedObject.activeSelf);
	}

	private void NotePickUp()
	{
		this.gameObject.SetActive(false);
	}
}
