using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    public float rotationSpeed = 50f; 
    public float pushForce = 5f;      

    private void Start()
    {
       
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    private void FixedUpdate()
    {
        
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }

    private void OnCollisionStay(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>();

            if (playerRb != null && !playerRb.isKinematic)
            {
                Vector3 centerOffset = collision.transform.position - transform.position;
                Vector3 tangentialVelocity = Vector3.Cross(Vector3.forward, centerOffset).normalized * pushForce;

                
                tangentialVelocity.y = 0;
                playerRb.velocity = tangentialVelocity;
            }
        }
    }
}




















