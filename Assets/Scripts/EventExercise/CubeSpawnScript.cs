using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class CubeSpawnScript : MonoBehaviour
{

    [SerializeField] GameObject SpawnPointCube;
    [SerializeField] List<GameObject> CubeList;
    // Start is called before the first frame update
    private void Start()
    {
        SpawnPointCube.SetActive(false);
    }
    void Awake()
    {
        EventBroadcaster.Instance.AddObserver(EventNames.Event_Exercise.CUBE_SPAWN, SpawnCube);
        EventBroadcaster.Instance.AddObserver(EventNames.Event_Exercise.CLEAR_ALL, ClearAll);
    }

    // Update is called once per frame

    void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver(EventNames.Event_Exercise.CUBE_SPAWN);
    }

    private void SpawnCube(Parameters param)
    {
        Debug.Log("Spawning Cube");
        int cubeSpawnAmt = param.GetIntExtra("cubeCount", 1);

        for (int i = 0; i < cubeSpawnAmt; i++)
        {
            GameObject obj = Instantiate(this.SpawnPointCube, this.SpawnPointCube.transform.position, Quaternion.identity);
            CubeList.Add(obj);
            obj.SetActive(true);
        }
    }

    private void ClearAll()
    {
        for(int i = 0; i < CubeList.Count; i++)
        {
            Destroy(this.CubeList[i]);
        }
    }
}
