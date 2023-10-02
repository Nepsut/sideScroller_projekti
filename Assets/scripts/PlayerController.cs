using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb = null;  //stating to get rigidbody
    public float JumpForce = 11f; //stating to get adjustable JumpForce
    private bool IsOnGround = true; //Tracking if the player is on ground, if its public the change can be seen in the editor

    private void OnCollisionEnter(Collision collision) //detects 'some' collision and turns IsOnGround = true
    {
        //The other collider has to be the ground
        IsOnGround = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= 2.0f;  //Fine place to mess around with gravity, douples the gravitational force
        rb = GetComponent <Rigidbody>(); //calling to get it from the start


    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && IsOnGround) //defining 'space' button, adding IsOnGround
        {
            rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse); //Adds an impulse force upwards
            // We are not on ground anymore
            IsOnGround = false; //changes IsOnGround to false, jumps only once, needs to set ground to turn into true again

        }


    }
}
