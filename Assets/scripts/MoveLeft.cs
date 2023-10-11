using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.AI;

public class MoveLeft : MonoBehaviour
{
    public float Speed = 5.0f;
    private PlayerController PlayerControllerScript;
    private GameManager GameManagerScript;
    bool HasScored = false; //needed for the score to not get higher and higher constantly

    // Start is called before the first frame update
    void Start()
    {
        PlayerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        GameManagerScript = GameObject.Find("GameManager").GetComponent <GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerControllerScript.GameOver == false)
        {
            transform.position += Vector3.left * Speed * Time.deltaTime;
        }
       
        if (transform.position.x <= 0 && !HasScored)
        {
            GameManagerScript.UpdateScore(1);
            HasScored = true;
        }

    }
}
