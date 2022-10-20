using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraUIScript : MonoBehaviour
{
    private RaycastHit hit;

    private GameObject grabbedObject;

    [Tooltip("(Camera)")]
    [SerializeField] private new Transform camera;

    [Tooltip("Must be same as: ReticleScript")]
    [SerializeField] private float maxReach = 20f;
    
    [Space(10)]
    [Header("Action Panels")]
    [SerializeField] private GameObject grabPanel;
    [SerializeField] private GameObject throwPanel;
    [SerializeField] private GameObject pushPanel;
    [SerializeField] private GameObject interactPanel;

    // Update is called once per frame
    void Update()
    {
        //Looked
        if (Physics.Raycast(camera.position, camera.forward, out hit, maxReach) &&
            hit.transform.GetComponent<Rigidbody>() &&
            hit.transform.gameObject.CompareTag("Clutchable"))
        {
            grabbedObject = hit.transform.gameObject;
        }
        //Away
        else if (Input.GetMouseButtonUp(0))
        {
            grabbedObject = null;
        }

        //if looking at object
        if (grabbedObject != null)
        {
            grabPanel.SetActive(true);            
            throwPanel.SetActive(false);
            pushPanel.SetActive(true);
            interactPanel.SetActive(false);
        }
        //if not looking at object
        if (grabbedObject == null)
        {
            grabPanel.SetActive(false);
            throwPanel.SetActive(false);
            pushPanel.SetActive(false);
            interactPanel.SetActive(false);
        }

        //if grabbing the object
        if (grabbedObject != null && Input.GetMouseButton(0))
        {
            grabPanel.SetActive(false);
            throwPanel.SetActive(true);
            pushPanel.SetActive(false);
            interactPanel.SetActive(false);
        }



    }
}
