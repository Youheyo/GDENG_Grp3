using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubHandler : MonoBehaviour
{
	[Header("Toggable Structures")]

	[Header("endIsland")]
	[SerializeField] private GameObject endIsland;
	[SerializeField] private GameObject wallObst;

	void Awake() {
		Debug.Log("Value: " + GameManager.Instance.getL3());
		unlockEnd();
	}

	private void unlockEnd() {
		if(GameManager.Instance.getL3() == true) {
			wallObst.SetActive(false);
			endIsland.SetActive(true);
		}
	}
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
