using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawnScript : MonoBehaviour
{

    [SerializeField] GameObject SpawnPointCube;
    // Start is called before the first frame update
    void Awake()
    {
        EventBroadcaster.Instance.AddObserver(EventNames.Event_Exercise.CUBE_SPAWN, SpawnCube);
    }

    // Update is called once per frame

    void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver(EventNames.Event_Exercise.CUBE_SPAWN);
    }

    private void SpawnCube(Parameters param)
    {
        int cubeSpawnAmt = param.GetIntExtra("cube", 1);

        for (int i = 0; i < cubeSpawnAmt; i++)
        {
            GameObject obj = Instantiate(SpawnPointCube, this.SpawnPointCube.transform);
        }
    }
}
