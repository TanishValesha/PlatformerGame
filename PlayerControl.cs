using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    //public variable
    public float moveSpeed = 10f;
    public Rigidbody2D rb;
    public SpriteRenderer playerSprite;
    public Animator animator;
    public float jumpForce = 10f;
    public bool isGrounded;
    public GameObject player;
    public GameObject respawnPoint;
    public PlayerControl playerScript;
    public GameObject knifePrefab;
    public GameObject knifeSpawnpoint;
    public float animationOffTimer;
    public float slideForce = 3f;
    public float posX;
    public float posY;
    public AudioSource _audio;
    public AudioClip jumpSound;
    public AudioClip slideSound;
    
    //private variable
    private float moveInput;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _audio = GetComponent<AudioSource>();
        
        transform.position = new Vector3(posX, posY);
    }
    
    void Update()
    {
        Movement();
        Jump();
        Flip();
        Slide();
        Constrain();
        ScreenDie();
        RelodeScene();
        if (moveInput == 0f)
        {
            Shoot();
        }
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        animator.SetBool("isJumping", false);
        isGrounded = true;

        if (other.collider.CompareTag("Enemy"))
        {
            animator.SetBool("Dead", true);
            playerScript.enabled = false;
        }
        
    }

    void OnCollisionExit2D(Collision2D other)
    {
        isGrounded = false;
    }

    void Movement()
    {
        moveInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * moveInput * moveSpeed * Time.deltaTime);
        
        animator.SetFloat("Speed", Mathf.Abs(moveInput));// Mathf.Abs ensures that the value be true(very imp always include)
        
    }

    void Flip()
    {
        if (moveInput > 0f)
        {
            playerSprite.flipX = false;
        }
        
        if (moveInput < 0f)
        {
            playerSprite.flipX = true;
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            _audio.PlayOneShot(jumpSound);
            rb.AddForce(new Vector2(0f, jumpForce * 4f));
            animator.SetBool("isJumping", true);
        }
    }

    void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _audio.PlayOneShot(jumpSound);
            Instantiate(knifePrefab, knifeSpawnpoint.transform.position, Quaternion.identity);
            animator.SetBool("isShooting", true);
            
            // Invoke is a method used to set a value of something after a 'x' amount of time
            Invoke("SetShootAnimationOFF",animationOffTimer);
        }
    }

    void SetShootAnimationOFF()
    {
        animator.SetBool("isShooting", false);
    }

    void Slide()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _audio.PlayOneShot(slideSound);//Sound
            if (playerSprite.flipX == false)
            {
                rb.velocity = new Vector2(slideForce, rb.velocity.y);
                animator.SetBool("Sliding", true);
            }

            if (playerSprite.flipX == true)
            {
                rb.velocity = new Vector2(-slideForce, rb.velocity.y);
                animator.SetBool("Sliding", true);
            }
            
            Invoke("SetSlideAnimationOFF", animationOffTimer);
        }
    }
    
    void SetSlideAnimationOFF()
    {
        animator.SetBool("Sliding", false);
    }

    void Constrain()
    {
        if (transform.position.x < -17f)
        {
            transform.position = new Vector2(-17f, transform.position.y);
        }
    }

    void ScreenDie()
    {
        if (transform.position.y < -5.7f)
        {
            transform.position = respawnPoint.transform.position;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void RelodeScene()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    
}
