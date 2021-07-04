using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForc = 10f;
    [SerializeField]
    private float jumpForc =11f;

    private float movementX;

    private Rigidbody2D myBody;
    private Animator anim;
    private string WALK_ANIMATION = "Walk";
    private SpriteRenderer sr;
    private bool isGrounded = true;
    private string GROUND_TAG = "Ground";
    private string ENEMY_TAG = "Enemy";

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
        PlayerJump();
    }

    /*void FixedUpdate()
    {
        PlayerJump();
    }*/

    void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX , 0f , 0f) * (moveForc * Time.deltaTime);
        
    }

    void AnimatePlayer()
    {
        if (movementX > 0)
        {
           anim.SetBool(WALK_ANIMATION , true);
           sr.flipX = false;
        }else if (movementX < 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
        }
        else
        {
            anim.SetBool(WALK_ANIMATION, false);
        }
    }

    void PlayerJump()
    {
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            myBody.AddForce(new Vector2(0f , jumpForc) , ForceMode2D.Impulse);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = true;
            
        }

        if (collision.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(ENEMY_TAG))
            Destroy(gameObject);
    }
}