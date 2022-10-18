using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ReticleScript : MonoBehaviour
{

    [Tooltip("Camera > CameraUI > Reticle")]
    [SerializeField] private Image reticle;
    [Tooltip("Camera > CameraUI > ThrowUI > MouseSprite")]
    [SerializeField] private Image mouseSprite;
    [SerializeField] private GameObject pushPanel;

    [SerializeField] private TextMeshProUGUI grabText;
    

    [SerializeField] private Color activeColor;
    [SerializeField] private Color inactiveColor;
    [SerializeField] private Color releasedColor;

    [Tooltip("Must be same as: GrabScript")]
    [SerializeField] private float maxDistance = 20f;

    private void Start()
    {
        grabText.gameObject.SetActive(false);
        mouseSprite.gameObject.SetActive(false);
        pushPanel.gameObject.SetActive(false);
        reticle.color = new Color(96, 109, 96, 1f);
        releasedColor = Color.white;
    }

    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance) && hit.transform.gameObject.CompareTag("Clutchable"))
        {

            if(!hit.transform.gameObject.GetComponent<Outline>())
                hit.transform.gameObject.AddComponent<Outline>();
            else if (hit.transform.gameObject.GetComponent<Outline>().OutlineColor != releasedColor && !Input.GetMouseButton(0))
                hit.transform.gameObject.GetComponent<Outline>().OutlineColor = releasedColor;


                if (!hit.transform.gameObject.GetComponent<outlinescript>())
                hit.transform.gameObject.AddComponent<outlinescript>();

            if(!hit.transform.gameObject.GetComponent<Outline>().enabled)
                hit.transform.gameObject.GetComponent<Outline>().enabled = true;
            

            grabText.gameObject.SetActive(true);
            mouseSprite.gameObject.SetActive(true);
            pushPanel.gameObject.SetActive(true);
            if (Input.GetMouseButton(0))
            {
                pushPanel.gameObject.SetActive(false);
            }

            reticle.color = new Color(activeColor.r, activeColor.g, activeColor.b, activeColor.a);

   
        }
        else
        {
            hit.transform.gameObject.GetComponent<Outline>().enabled = false;
            grabText.gameObject.SetActive(false);
            mouseSprite.gameObject.SetActive(false);
            pushPanel.gameObject.SetActive(false);
            reticle.color = new Color(inactiveColor.r, inactiveColor.g, inactiveColor.b, inactiveColor.a);
        }
    }
}