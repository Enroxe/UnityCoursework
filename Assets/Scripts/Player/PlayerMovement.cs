using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IMoveAble
{
    [SerializeField] GameObject playerObj;
    [SerializeField] float jumpForce;
    [SerializeField] float moveSpeed;
    private Rigidbody2D rb;
    private bool isMoving = false;
    
    public bool IsMoving { get { return isMoving; } }
    private bool isGrounded = false;

    public float MoveSpeed
    {
        get { return moveSpeed; }
        set
        {
            moveSpeed = value;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    public void Start()
    {
        if (playerObj == null)
        {
            playerObj = gameObject;
        }

        rb = playerObj.GetComponent<Rigidbody2D>();
    }

    public void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        
        if (horizontal != 0)
        {
            playerObj.transform.position = playerObj.transform.position
                                           + new Vector3(horizontal * moveSpeed * Time.deltaTime, 0);

            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
        
        RotateToDirection(horizontal);
        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    private void RotateToDirection(float direction)
    {
        if (direction > 0)
        {
            Vector3 rotate = transform.eulerAngles;
            rotate.y = 180;
            transform.rotation = Quaternion.Euler(rotate);
        }
        else if(direction < 0){
            Vector3 rotate = transform.eulerAngles;
            rotate.y = 0;
            transform.rotation = Quaternion.Euler(rotate);
        }
    }
    
    public void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}
