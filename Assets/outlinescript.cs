using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outlinescript : MonoBehaviour
{
    [SerializeField] private Camera camera;
    private RaycastHit hit;

    private GameObject gameobj;
    // Start is called before the first frame update
    void Awake()
    {
        camera = Camera.main;
        //this.transform.GetComponent<Outline>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {


        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, 3f) &&
            hit.transform.GetComponent<Rigidbody>() &&
            hit.transform.gameObject.CompareTag("Clutchable"))
        {
            gameobj = hit.transform.gameObject;
        }

        if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
        {
//            if (hit.transform.GetComponent<Outline>().enabled) 
//                this.GetComponent<Outline>().enabled = false;
        }




    }

    private void OnMouseEnter()
    {
//        this.GetComponent<Outline>().OutlineWidth = 6.2f;
    }

    private void OnMouseExit()
    {
 //       this.GetComponent<Outline>().enabled = false;
    }

    private void OnMouseOver()
    {
        
    }


}