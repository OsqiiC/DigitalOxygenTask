using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float gravity = -4f;
    [SerializeField] private float speed = 5;
    [SerializeField] private float jumpForce = 2.4f;
    [SerializeField] private float yVelocity;

    [SerializeField] private LayerMask groundMask;
    [SerializeField] private Vector2 floorCheckSize;
    [SerializeField] private Vector2 floorCheckOffset;

    private bool isGrounded;
    private Vector2 movementDirection;
    private Rigidbody2D _rigidbody;
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();   
    }

    
    void Update()
    {
        UpdateMovementDirection();
        Jump();
    }

    private void FixedUpdate()
    {
        // Checking ground
        isGrounded = (Physics2D.OverlapBox((Vector2)transform.position + floorCheckOffset, floorCheckSize, 0f, groundMask) != null);

        Run();
    }


    private void Run()
    {   
        // Changing face direction of sprites
        if (movementDirection.x > 0) transform.rotation = Quaternion.Euler(new Vector2(0,180));
        else if (movementDirection.x < 0) transform.rotation = Quaternion.Euler(new Vector2(0, 0));      
        
        // Moving player via rigidbody and setting run animation
        _rigidbody.MovePosition((Vector2)transform.position + movementDirection * speed * Time.fixedDeltaTime);
        _animator.SetFloat("Speed", Mathf.Abs(movementDirection.x));
    }

    private void Jump()
    {
        // Adding Vertical velocity to perform jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {           
            yVelocity = jumpForce;
        }
    }

    private void UpdateMovementDirection()
    {
        // Reseting velocity then player on ground or not and setting fall animation
        if (isGrounded && yVelocity < 0)
        {
            yVelocity = -0.01f;
            _animator.SetFloat("Jump", 0);
        }
        else 
        {
            yVelocity += gravity * Time.deltaTime;
            _animator.SetFloat("Jump", 1); 
        }

        movementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), yVelocity);
    }

    private void OnDrawGizmos()
    {
        // Shows groundCheck size in editor
        Gizmos.DrawWireCube((Vector2)transform.position + floorCheckOffset, floorCheckSize);
    }
}
