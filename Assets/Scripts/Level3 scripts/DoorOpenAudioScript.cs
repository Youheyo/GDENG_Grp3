using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenAudioScript : MonoBehaviour
{

	[SerializeField] AudioSource OpenSound;

	private void OnEnable()
	{
		this.OpenSound.Play();
	}
}
