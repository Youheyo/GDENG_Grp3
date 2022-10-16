using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCube : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
    	Debug.Log(collision.collider.name);
        if(collision.collider.name == "Player") {
            LoadManager.Instance.LoadScene(SceneNames.MAIN_SCENE, false);
            Debug.Log("Player collide");
        }
    }
}
