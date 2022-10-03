using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.UI;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TakeTextBoxInt : MonoBehaviour
{
    //Use LEGACY INPUTFIELD
    [SerializeField] InputField inputfield;
     string stringvalue;
     int integervalue;    
    

    public void onButtonPress()
    {
        stringvalue = inputfield.text;
            int.TryParse(stringvalue, out integervalue);
        Debug.Log(integervalue);
    }
}
