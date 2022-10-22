using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IdenticalObjectDetection : MonoBehaviour
{

	[SerializeField] private List<GameObject> ObjectList;
	[SerializeField] private string reqObjectName = "Crate_Long";
	[SerializeField] private int reqObjectCount = 0;
	[SerializeField] private int correctObjectCount = 0;
	private void OnTriggerEnter(Collider collision)
	{
		Debug.Log(collision.gameObject.name + " entered!");
		this.ObjectList.Add(collision.gameObject);
		if (collision.name.Contains(reqObjectName))
		{
			correctObjectCount++;
			checkObjective();
		}
	}

	private void OnTriggerExit(Collider collision)
	{
		if (collision.name.Contains(reqObjectName)) correctObjectCount--;
		this.ObjectList.Remove(collision.gameObject);
	}

	private void checkObjective()
	{
		Debug.Log("Checking puzzle Reqs");
		if(correctObjectCount == reqObjectCount && this.ObjectList.Count == reqObjectCount)
		{
			Debug.Log("ROOM 1 puzzle COMPLETED");
			EventBroadcaster.Instance.PostEvent(EventNames.Goal_Notes.LEVEL_3_ROOM_1_COMPLETE);
		}
	}
}
