using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D col;
    private SpriteRenderer Sprite;
    private Animator anim;

    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
   [SerializeField] private float MoveSpeed = 7f;
   [SerializeField] private float JumpForce = 14f;


    private enum MovementState {idle, running ,falling, jumping }
    [SerializeField] private AudioSource JumpSoundEffect;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        Sprite = GetComponent<SpriteRenderer>();  
        anim = GetComponent<Animator>();    
    }

    
    private void Update()
    {
         dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * MoveSpeed, rb.velocity.y);
       

        if (Input.GetButtonDown("Jump") &&isGrounded())
        {
            JumpSoundEffect.Play();
          rb.velocity = new Vector2(rb.velocity.x, JumpForce);    
        }

        UpdateAnimationUpd();
       
    }

    private void UpdateAnimationUpd()
    {
        MovementState state;
        if (dirX > 0f)
        {
            state = MovementState.running;
            Sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            Sprite.flipX = true;

        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;

        }
        else if(rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }
        anim.SetInteger("state", (int)state);
    }

    private bool isGrounded()
    {
        return Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
