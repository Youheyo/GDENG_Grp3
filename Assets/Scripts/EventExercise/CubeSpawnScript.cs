using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawnScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        EventBroadcaster.Instance.AddObserver(EventNames.SPAWN_OBJECT, )
    }

    // Update is called once per frame

    void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver(EventNames.SPAWN_OBJECT);
    }

    private void SpawnCube(Parameters param)
    {

    }
}
