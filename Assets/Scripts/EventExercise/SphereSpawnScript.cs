using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class SphereSpawnScript : MonoBehaviour
{

    [SerializeField] GameObject SpawnPointSphere;
    [SerializeField] List<GameObject> SphereList;
    // Start is called before the first frame update
    private void Start()
    {
        SpawnPointSphere.SetActive(false);
    }
    void Awake()
    {
        EventBroadcaster.Instance.AddObserver(EventNames.Event_Exercise.BALL_SPAWN, SpawnSphere);
        EventBroadcaster.Instance.AddObserver(EventNames.Event_Exercise.CLEAR_ALL, ClearAll);
    }

    // Update is called once per frame

    void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver(EventNames.Event_Exercise.BALL_SPAWN);
    }

    private void SpawnSphere(Parameters param)
    {
        Debug.Log("Spawning Sphere");
        int SphereSpawnAmt = param.GetIntExtra("ballCount", 1);

        for (int i = 0; i < SphereSpawnAmt; i++)
        {
            GameObject obj = Instantiate(this.SpawnPointSphere, this.SpawnPointSphere.transform.position, Quaternion.identity);
            SphereList.Add(obj);
            obj.SetActive(true);
        }
    }

    private void ClearAll()
    {
        for(int i = 0; i < SphereList.Count; i++)
        {
            Destroy(this.SphereList[i]);
        }
    }
}
