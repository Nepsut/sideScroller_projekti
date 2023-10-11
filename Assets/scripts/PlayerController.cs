using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb = null;  //stating to get rigidbody
    public float JumpForce = 11f; //stating to get adjustable JumpForce
    private bool IsOnGround = true; //Tracking if the player is on ground, if its public the change can be seen in the editor
    public bool GameOver;  //Nice place to start the GameOver system

    private Animator PlayerAnim;
    public ParticleSystem ExplosionParticle;
    public ParticleSystem DirtParticle;

    public AudioClip JumpSound;
    public AudioClip CrashSound;
    private AudioSource PlayerAudio;
    public BGMusic BackgroundMusic;

    private GameManager GameManagerScript;


    private void OnCollisionEnter(Collision collision) //old version - detects 'some' collision and turns IsOnGround = true
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsOnGround = true;  //The other collider has to be the ground
            DirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");
            GameOver = true;
            PlayerAnim.SetBool("Death_b", true);
            PlayerAnim.SetInteger("DeathType_int", 1);
            ExplosionParticle.Play();
            DirtParticle.Stop();
            PlayerAudio.PlayOneShot(CrashSound, 0.5f);
            BackgroundMusic.StopMusic();
            GameManagerScript.GameOver();
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        //Physics.gravity *= 2.0f; //douples the gravitational force, didn't work with restart (got doubled every time)
        Physics.gravity = new Vector3(0, -20f, 0);
        rb = GetComponent <Rigidbody>(); //calling to get it from the start
        PlayerAnim = GetComponent<Animator>(); //calling
        PlayerAudio = GetComponent<AudioSource>();

        GameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();


    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && IsOnGround && !GameOver) //defining 'space' button, adding IsOnGround
        {
            rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse); //Adds an impulse force upwards
            // We are not on ground anymore
            IsOnGround = false; //changes IsOnGround to false, jumps only once, needs to set ground to turn into true again
            PlayerAnim.SetTrigger("Jump_trig");
            DirtParticle.Stop();
            PlayerAudio.PlayOneShot(JumpSound, 0.5f);

        }


    }
}
