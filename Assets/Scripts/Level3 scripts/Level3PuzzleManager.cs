using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3PuzzleManager : MonoBehaviour
{
	[SerializeField] private GameObject RoomOneCloseDoor;
	[SerializeField] private GameObject RoomOneOpenDoor;
	[SerializeField] private GameObject RoomOneSensor;

	[SerializeField] private GameObject RoomTwoCloseDoor;
	[SerializeField] private GameObject RoomTwoOpenDoor;
	public int RoomTwoObjectiveCount = 0; 
	public int RoomTwoObjectiveReq = 5; 

	private void Awake()
	{
		EventBroadcaster.Instance.AddObserver(EventNames.Goal_Notes.LEVEL_3_ROOM_1_COMPLETE, unlockRoom1);
		EventBroadcaster.Instance.AddObserver(EventNames.Goal_Notes.LEVEL_3_ROOM_2_COMPLETE, unlockRoom2);
	}

	private void unlockRoom1()
	{
		RoomOneCloseDoor.SetActive(false);
		RoomOneOpenDoor.SetActive(true);
	}
	private void unlockRoom2()
	{
		RoomTwoCloseDoor.SetActive(false);
		RoomTwoOpenDoor.SetActive(true);
	}
}
