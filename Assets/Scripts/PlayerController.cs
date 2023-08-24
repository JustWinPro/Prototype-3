using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    private Animator playerAnimator;
    private AudioSource playerAudio;
    [Space]
    public ParticleSystem explosion;
    public ParticleSystem dirt;
    [Space]
    public AudioClip jumpSFX;
    public AudioClip crashSFX;
    [Space]
    public float jumpForce = 10;
    public float gravityModifier = 1;
    [Space]
    public bool isOnGround = true;
    public bool isGameOver;
    [Space]
    private bool jump_SPACEBAR;
    private bool jump_WKEY;
    private bool jump_UPARROW;

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }
    void Update()
    {
        //KEY BINDINGS:
        jump_SPACEBAR = Input.GetKeyDown(KeyCode.Space);
        jump_WKEY = Input.GetKeyDown(KeyCode.W);
        jump_UPARROW = Input.GetKeyDown(KeyCode.UpArrow);

        if ((jump_SPACEBAR || jump_WKEY || jump_UPARROW) && isOnGround && !isGameOver)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnimator.SetTrigger("Jump_trig");
            isOnGround = false;
            dirt.Stop();
            playerAudio.PlayOneShot(jumpSFX, 0.5f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirt.Play();
        }

        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            //Sets the player animation to death after triggering the collision
            playerAnimator.SetBool("Death_b", true);
            playerAnimator.SetInteger("DeathType_int", 1);

            //Returns "Game Over!" in the debug logs of Unity.
            Debug.Log("Game Over!");

            isGameOver = true;

            //Particle Effects:
            explosion.Play();
            dirt.Stop();

            //Sound Effects:
            playerAudio.PlayOneShot(crashSFX, 0.8f);
        }
    }
}
