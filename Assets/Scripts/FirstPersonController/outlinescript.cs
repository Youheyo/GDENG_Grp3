using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class outlinescript : MonoBehaviour
{
    [SerializeField] private new Camera camera;
    private RaycastHit hit;

    private GameObject gameobj;


    [SerializeField] private Color activeColor;
    [SerializeField] private Color inactiveColor;




    void Awake()
    {
        //camera = Camera.main;
        //this.transform.GetComponent<Outline>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {


        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 20f))// &&
            //hit.transform.GetComponent<Rigidbody>() &&
        {
            if(hit.transform.gameObject.CompareTag("Clutchable"))
            gameobj = hit.transform.gameObject;

        }

        if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1) && hit.transform != null)
        {
            if (hit.transform.GetComponent<Outline>().enabled)
                this.GetComponent<Outline>().enabled = false;
        }




    }

    private void OnMouseEnter()
    {
        this.GetComponent<Outline>().enabled = true;
        this.GetComponent<Outline>().OutlineWidth = 6.5f;
        this.GetComponent<Outline>().OutlineColor = inactiveColor;
    }

    private void OnMouseExit()
    {

        this.GetComponent<Outline>().enabled = false;


    }

    private void OnMouseOver()
    {

    }


}