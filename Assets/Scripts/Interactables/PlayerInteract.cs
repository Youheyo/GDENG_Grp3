using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{
	private GameObject raycastedObj;
	[SerializeField] private int rayLength = 10;
	[SerializeField] private LayerMask layerMaskInteract;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
		Vector3 fwd = transform.TransformDirection(Vector3.forward);

		if(Physics.Raycast(transform.position, fwd, out hit, rayLength, layerMaskInteract))
		{
			//if (hit.collider.CompareTag("Interactable"))
			//{
				raycastedObj = hit.collider.gameObject;

				if (Input.GetKeyDown(KeyCode.E))
				{
					Debug.Log("Interacted with " + raycastedObj.name);
					//raycastedObj.SetActive(false);
					raycastedObj.GetComponent<ObjectInteracted>().onInteract();
				}
			//}
		}
    }

	void OnDrawGizmosSelected()
	{
		// Draws a 5 unit long red line in front of the object
		Gizmos.color = Color.red;
		Vector3 direction = transform.TransformDirection(Vector3.forward) * rayLength;
		Gizmos.DrawRay(transform.position, direction);
	}
}
