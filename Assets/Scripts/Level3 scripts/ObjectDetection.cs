using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectDetection : MonoBehaviour
{

	[SerializeField] private List<GameObject> ObjectList;
	[SerializeField] private GameObject reqObject = null;
	[SerializeField] private bool hasObject;
	Level3PuzzleManager level;
	private void OnTriggerEnter(Collider collision)
	{
		Debug.Log(collision.gameObject.name + " entered!");
		this.ObjectList.Add(collision.gameObject);
		if (!hasObject)
		{
			level.RoomTwoObjectiveCount++;
			hasObject = true;
		}
		checkObjective();
	}

	private void OnTriggerExit(Collider collision)
	{
		this.ObjectList.Remove(collision.gameObject);
		if(ObjectList.Count == 0)
		{
			hasObject = false;
			level.RoomTwoObjectiveCount--;
		}
	}

	void checkObjective()
	{
		if(ObjectList.Count > 0 && level.RoomTwoObjectiveReq == level.RoomTwoObjectiveCount)
		{
			EventBroadcaster.Instance.PostEvent(EventNames.Goal_Notes.LEVEL_3_ROOM_2_COMPLETE);
		}
	}
}
