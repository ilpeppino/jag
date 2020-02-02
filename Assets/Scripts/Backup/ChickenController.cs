using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenController : MonoBehaviour
{
    // Cached references
    [SerializeField] private Rigidbody _rbBall;
    private Rigidbody _rbChicken;
    private Animator _animator;

    // Parameters
    [SerializeField] private float _moveSpeed = 10f;

    [SerializeField] private float _jumpForce = 50f;
    private bool isGrounded;


    void Start()
    {
        _rbChicken = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();

        isGrounded = true;
    }


    void Update()
    {
        Jump();
        Move();
        
    }

    // TODO create event system for managing collisions
    // TODO create AudioManager

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Floor")
        {
            isGrounded = true;
            Debug.Log("Chicken grounded");
        }

        if (collision.gameObject.name == "Soccer Ball")
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * _jumpForce * 2f);
            Debug.Log("Ball touched");
        }

        
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Floor")
        {
            isGrounded = false;
        }     
        


        Debug.Log("Chicken not grounded");
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            _rbChicken.AddForce(Vector3.up * _jumpForce);
            Debug.Log("Jump");
        }

    }

    private void Move()
    {
        float xInput = Input.GetAxis("Horizontal");

        if (xInput != 0)
        {
            _animator.SetBool("isRunning", true);

            float xPosition = xInput * _moveSpeed * Time.deltaTime;

            Vector3 movement = new Vector3(xPosition, 0f, 0f);
            transform.rotation = Quaternion.LookRotation(movement);
            transform.Translate(movement, Space.World);

        } 
        else
        {
            _animator.SetBool("isRunning", false);
        }

    }
}
