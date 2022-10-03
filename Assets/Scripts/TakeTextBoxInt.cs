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
    [SerializeField] TMP_InputField inputfield;
     string stringvalue;
     int integervalue;    
    

    public void onCubeButtonPress()
    {
        stringvalue = inputfield.text;
            int.TryParse(stringvalue, out integervalue);
        Debug.Log(integervalue);

        Parameters param = new Parameters();
        param.PutExtra("cubeCount", integervalue);

        EventBroadcaster.Instance.PostEvent(EventNames.Event_Exercise.CUBE_SPAWN, param);
    }

    public void onBallButtonPress()
    {
        stringvalue = inputfield.text;
        int.TryParse(stringvalue, out integervalue);
        Debug.Log(integervalue);

        Parameters param = new Parameters();
        param.PutExtra("ballCount", integervalue);

        EventBroadcaster.Instance.PostEvent(EventNames.Event_Exercise.BALL_SPAWN, param);
    }

    public void onClearButtonPress()
    {
        EventBroadcaster.Instance.PostEvent(EventNames.Event_Exercise.CLEAR_ALL);
    }
}
