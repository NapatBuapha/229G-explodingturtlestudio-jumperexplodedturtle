using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("[Move] setting")]
    //horizontal movement
    [SerializeField] private float speed = 5;
    [SerializeField] private float horiInput;
    private Rigidbody2D rb;
    private bool canMove;

    [Header("[Jump] setting")]

    [SerializeField] private float jumpValue = 0.0f;

    public PhysicsMaterial2D bounceMat , normalMat;
    [SerializeField] private float jumpChargeRate = 0.1f;
    [SerializeField] private float maxJumpValue = 20.0f;
    public bool isTouchGround;
    [SerializeField] private float checkingDistance = 0.1f;
    [SerializeField] private Vector2 turtleVelocity;
    [SerializeField] Transform jumpTarget;
    private float playerfacing;

    //Object refference
    [SerializeField] private Transform groundCheckRef;
    private RaycastHit2D hit;
    private bool isCharging;
    [SerializeField] SpriteRenderer spriteRenderer;

    
    void Start()
    {
        playerfacing = 1;
        isCharging = false;
        canMove = true;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if(canMove)
        horiInput = Input.GetAxisRaw("Horizontal");

        if(horiInput == -1)
        {
            spriteRenderer.flipX = false;
            playerfacing = -1;
        }
        else if (horiInput == 1)
        {
            spriteRenderer.flipX = true;
            playerfacing = 1;
        }

        if(Input.GetKey(KeyCode.Space) && isTouchGround)
        {
            isCharging = true;
            rb.velocity = Vector2.zero;
            canMove = false;
            if(jumpValue <= maxJumpValue)
            {
                jumpTarget.position = new Vector2 (jumpTarget.position.x + jumpChargeRate * Time.deltaTime * playerfacing * 1.5f  ,jumpTarget.position.y);
                jumpValue += jumpChargeRate * Time.deltaTime; 
            }
        }

        if(Input.GetKeyUp(KeyCode.Space) && isCharging)
        {
            isCharging = false;
            jump();
        }

        if(jumpValue > 0)
        {
            rb.sharedMaterial = bounceMat;
        }
        else
        {
            rb.sharedMaterial = normalMat;
        }


        

        //GroundCheck

        hit = Physics2D.Raycast(groundCheckRef.position,-Vector2.up,checkingDistance);
        
        if(hit.collider.CompareTag("Floor"))
        {
            rb.sharedMaterial = normalMat;
            isTouchGround = true;


        }
        else
        {
            isTouchGround = false;
        }


    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Floor"))
        {
            jumpTarget.position = transform.position;
            ResetJump();
        }        
    }

    void ResetJump()
    {
        canMove = true;
        jumpValue = 0;
    }

    void jump ()
    {
        turtleVelocity = CalculateProjectileVelocity(transform.position, jumpTarget.position ,1f);
        rb.AddForce(new Vector2 (turtleVelocity.x , turtleVelocity.y * jumpValue) ,ForceMode2D.Impulse);
    }

    void FixedUpdate()
    {
        if(canMove)
        rb.velocity = new Vector2(horiInput*speed,rb.velocity.y);
    }

    Vector2 CalculateProjectileVelocity(Vector2 origin, Vector2 target, float time)
    {
        Vector2 distance = target - origin;

        float velocityX = distance.x / time;
        float velocityY = distance.y / time + 0.5f * Mathf.Abs(Physics2D.gravity.y) * time;

        return new Vector2(velocityX, velocityY);

    }///CalculateProjectileVelocity
}
