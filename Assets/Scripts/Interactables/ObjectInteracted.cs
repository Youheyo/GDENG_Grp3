using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteracted : MonoBehaviour
{

	[SerializeField] private GameObject affectedObject;

	public void onInteract()
	{
		EventBroadcaster.Instance.PostEvent(this.name + "_PRESSED");
	}

	private void Awake()
	{
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
		}
	}

	private void OnDestroy()
	{
        EventBroadcaster.Instance.RemoveObserver(EventNames.RPG_Level_Interactables.BUTTON_1_PRESSED);
	}
	
	private void disableAffectedObject()
	{
		affectedObject.SetActive(!affectedObject.activeSelf);
	}
}
