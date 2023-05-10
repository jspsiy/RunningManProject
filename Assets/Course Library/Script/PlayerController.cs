using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public BoxCollider bc;
    public Animator  animator;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public float jumpAmount = 10;
    public AudioSource soundSource;
    public AudioClip[] jumpSound;
    public AudioClip[] crashSound;
    public bool grounded;
    public bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        bc = GetComponent<BoxCollider>();
        animator = GetComponent<Animator>();
        soundSource = GetComponent<AudioSource>();
        grounded = true;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("Up key was pressed");
            if (grounded == true)
            {
                int x = Random.Range(0, jumpSound.Length);
                soundSource.PlayOneShot(jumpSound[x],1.0f);
                dirtParticle.Stop();
                animator.SetFloat("Speed_f", 0);
                rb.AddForce(Vector3.up * jumpAmount, ForceMode.Impulse);
                grounded = false;
                animator.SetTrigger("Jump_trig");
            }
            if (gameOver)
            {

            }
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name.Contains("Ground"))
        {
            dirtParticle.Play();
            animator.SetFloat("Speed_f", 5);
            Debug.Log("OnGround");
            grounded = true;
        }
        else
        {
            Debug.Log("GAME OVER");
            int x = Random.Range(0, crashSound.Length);
            soundSource.PlayOneShot(crashSound[x],1.0f);
            gameOver = true;
            animator.SetBool("Death_b", true);
            animator.SetInteger("DeathType_int", 1);
            dirtParticle.Stop();
            explosionParticle.Play();

        }
    }
}
