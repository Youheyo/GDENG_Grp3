using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabScript : MonoBehaviour
{
   
    private RaycastHit hit;
    private GameObject grabbedObject;
    [Tooltip("Camera > GrabPos")]
    [SerializeField] Transform grabPos;

    [SerializeField] float followSpeed;

    [SerializeField] private Transform camera;
    [Tooltip("Player Prefab")]
    [SerializeField] private Transform player;

    [Tooltip("Must be same as: ReticleScript")]
    [SerializeField] private float maxDistance = 20f;
    // Update is called once per frame
    void Update()
    {
        Debug.Log(camera.transform.rotation.y);
        if (Input.GetMouseButtonDown(0) && Physics.Raycast(transform.position, transform.forward, out hit, maxDistance) &&
            hit.transform.GetComponent <Rigidbody>())
        {
            grabbedObject = hit.transform.gameObject;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            grabbedObject = null;
        }

        if (grabbedObject)
        {
            grabbedObject.GetComponent<Rigidbody>().velocity = 20 * (grabPos.position - grabbedObject.transform.position);
        }

        if (grabbedObject && Input.GetMouseButtonDown(1))
        {
            grabbedObject.GetComponent<Rigidbody>().AddForce(camera.forward * 600);
            grabbedObject = null;
        }
    }
}
