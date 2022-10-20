using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReticleScript : MonoBehaviour
{

    [Tooltip("Camera > CameraUI > Reticle")] 
    [SerializeField] private new Transform camera;
    [SerializeField] private Image reticle;
    [SerializeField] private Color activeColor;
    [SerializeField] private Color inactiveColor;

    [Tooltip("Must be same as: GrabScript")]
    [SerializeField] private float maxReach = 20f;

    private void Start()
    {
        
        reticle.color = new Color(96, 109, 96, 1f);
    }

    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.position, camera.forward, out hit, maxReach) && 
            hit.transform.gameObject.CompareTag("Clutchable"))
        {
            reticle.color = new Color(activeColor.r, activeColor.g, activeColor.b, activeColor.a);
        }
        else
        {
            reticle.color = new Color(inactiveColor.r, inactiveColor.g, inactiveColor.b, inactiveColor.a);
        }
    }
}