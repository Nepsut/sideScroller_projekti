using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 StartPosition;  //stating the start position

    private float Width = 0.0f;    //Screen bg width

    public float ScreenSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartPosition = transform.position;   //Get the start position from the game object (Screen bg)

        //Get the width of the Screen bg (from box collider added to the bg)
        Width = GetComponent<BoxCollider2D>().size.x; 
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * ScreenSpeed * Time.deltaTime;  //moves game object to left

        //If the obejct has moved more than 2 to the left from the start position
        if (transform.position.x < StartPosition.x - Width / 2.0f)
            transform.position = StartPosition;

    }
}
