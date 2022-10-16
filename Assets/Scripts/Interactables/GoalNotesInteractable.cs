using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalNotesInteractable : MonoBehaviour
{

	public void onInteract()
	{
		EventBroadcaster.Instance.PostEvent("LEVEL_1_PRESSED");
	}

	private void Awake()
	{
		EventBroadcaster.Instance.AddObserver(EventNames.Goal_Notes.LEVEL_1_PRESSED, winningCondition);
	}

	private void OnDestroy()
	{
        EventBroadcaster.Instance.RemoveObserver(EventNames.Goal_Notes.LEVEL_1_PRESSED);
	}
	
	private void winningCondition()
	{
		LoadManager.Instance.LoadScene(SceneNames.HUB_SCENE, false);
	}
}
