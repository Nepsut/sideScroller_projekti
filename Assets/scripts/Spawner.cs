using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject[] prefabs; //array of different prefabs
    private Vector3 SpawnPos = new Vector3(25, 0, 0);

    private float StartDelay = 2.0f;
    private float RepeatRate = 1.5f;
    private PlayerController PlayerControllerScript;


    // Start is called before the first frame update
    void Start()
    {
        PlayerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

        InvokeRepeating("SpawnRandomObstacle", StartDelay, RepeatRate);
    }

    void SpawnRandomObstacle()
    {
        //randomly select an index from prefabs array
        int randomIndex = Random.Range(0, prefabs.Length);

        if (PlayerControllerScript.GameOver == false)
        {
            //Instantiate the randomly selected prefab at the spawn position
            Instantiate(prefabs[randomIndex], SpawnPos, prefabs[randomIndex].transform.rotation);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
