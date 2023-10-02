using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject prefabs;
    private Vector3 SpawnPos = new Vector3(25, 0, 0);

    private float StartDelay = 2.0f;
    private float RepeatRate = 1.5f;



    // Start is called before the first frame update
    void Start()
    {

        InvokeRepeating("SpawnObstacle", StartDelay, RepeatRate);
    }

    void SpawnObstacle()
    {
        Instantiate(prefabs, SpawnPos, prefabs.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
