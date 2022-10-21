using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightScript : MonoBehaviour
{
    private bool flashlightState;
    [SerializeField] private GameObject flashlightObject;
    private bool onCooldown;
    [SerializeField] private AudioSource flashlightOn;
    [SerializeField] private AudioSource flashlightOff;

    // Start is called before the first frame update
    void Start()
    {
        this.flashlightState = false;
        this.onCooldown = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && this.onCooldown == false)
        {
            this.onCooldown = true;
            flashlightState = !flashlightState;
            Debug.Log(flashlightState);
            flashlightObject.SetActive(flashlightState);

            if (flashlightState == false)
                flashlightOff.Play();

            StartCoroutine(FlashlightCooldown());

            if (flashlightState == true)
                flashlightOn.Play();
        }
    }

    IEnumerator FlashlightCooldown()
    {
        yield return new WaitForSeconds(1f);
        this.onCooldown = false;
    }
}