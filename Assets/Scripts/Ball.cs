using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float pushForce = 20f;

    private Rigidbody rb;
    
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Capsule")
        {
            Debug.Log(collision.gameObject.name + " touched the ball");
            Vector3 offset = transform.position - collision.gameObject.transform.position;
            rb.AddForce(offset * pushForce * Time.deltaTime, ForceMode.Impulse);
        }
    }
}
