using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

    [SerializeField] private Image mouseImage;
    [SerializeField] private Sprite onGrabSprite;
    [SerializeField] private Sprite onReleaseSprite;
    [SerializeField] private TextMeshProUGUI grabText;

    [SerializeField] private Color grabbedColor;
    [SerializeField] private Color releasedColor;

    void Start()
    {
        grabbedColor = Color.yellow;
        releasedColor = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(camera.transform.rotation.y);
        
        if (Input.GetMouseButtonDown(0) && 
            Physics.Raycast(transform.position, transform.forward, out hit, maxDistance) &&
            hit.transform.GetComponent <Rigidbody>() && 
            hit.transform.gameObject.CompareTag("Clutchable"))
        {
            grabbedObject = hit.transform.gameObject;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            grabbedObject.GetComponent<Outline>().enabled = false;
            grabbedObject = null;
        }

        //Grab Object
        if (grabbedObject)
        {
            //grabbedObject.GetComponent<Outline>().OutlineColor = Color.blue;
            mouseImage.sprite = onGrabSprite;
            grabText.text = "Throw";
            if(grabbedObject.GetComponent<Outline>().OutlineColor != Color.yellow)
                grabbedObject.GetComponent<Outline>().OutlineColor = Color.yellow;
            grabbedObject.GetComponent<Rigidbody>().velocity = (20 / grabbedObject.GetComponent<Rigidbody>().mass) * (grabPos.position - grabbedObject.transform.position);
            grabbedObject.GetComponent<Rigidbody>().freezeRotation = true;
        }
        else
        {
            if (grabbedObject.GetComponent<Outline>().OutlineColor == Color.yellow)
                grabbedObject.GetComponent<Outline>().OutlineColor = Color.white;
            mouseImage.sprite = onReleaseSprite;
            grabText.text = "Pick-Up";
            grabbedObject.GetComponent<Outline>().enabled = false;
            //grabbedObject.GetComponent<Rigidbody>().freezeRotation = false;
            //grabbedObject.GetComponent<Outline>().enabled = false;
        }

        //Throw Grabbed Object
        if (grabbedObject && Input.GetMouseButtonDown(1))
        {
            grabbedObject.GetComponent<Rigidbody>().AddForce(camera.forward * 600);
            grabbedObject.GetComponent<Rigidbody>().freezeRotation = false;
            grabbedObject.GetComponent<Outline>().enabled = false;
            grabbedObject = null;
            grabText.gameObject.SetActive(false);
            mouseImage.gameObject.SetActive(false);
            


        }

        //Push Object
        if (!grabbedObject && Input.GetMouseButtonDown(1) 
                           && Physics.Raycast(transform.position, transform.forward, out hit, maxDistance) 
                           && hit.transform.GetComponent<Rigidbody>() &&
                           hit.transform.gameObject.CompareTag("Clutchable"))
        {
            hit.transform.GetComponent<Rigidbody>().AddForce(camera.forward * 600);
            grabbedObject.GetComponent<Outline>().enabled = false;
        }
    }



}
