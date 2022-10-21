using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IdenticalObjectDetection : MonoBehaviour
{

	[SerializeField] private List<GameObject> ObjectList;
	[SerializeField] private GameObject reqObject = null;
	[SerializeField] private int reqObjectCount = 0;
	private void OnTriggerEnter(Collider collision)
	{
		Debug.Log(collision.gameObject.name + " entered!");
		this.ObjectList.Add(collision.gameObject);
		//if (collision.name.Contains(reqObject.name))
		checkObjective();
	}

	private void OnTriggerExit(Collider collision)
	{
		this.ObjectList.Remove(collision.gameObject);
	}

	private void checkObjective()
	{
		Debug.Log("Checking puzzle Reqs");
		if(ObjectList.Count == reqObjectCount)
		{
			Debug.Log("ROOM 1 puzzle COMPLETED");
			EventBroadcaster.Instance.PostEvent(EventNames.Goal_Notes.LEVEL_3_ROOM_1_COMPLETE);
		}
	}
}
