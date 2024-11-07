using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingStick : MonoBehaviour
{
    public float rotationSpeed = 100f; 
    public float pushForce = 2f;       

    

    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>();

            if (playerRb != null && !playerRb.isKinematic)
            {
                
                Vector3 pushDirection = collision.transform.position - transform.position;
                pushDirection.y = 0; 
                pushDirection.Normalize();

                playerRb.AddForce(pushDirection * pushForce, ForceMode.Impulse);
            }
            else
            {
                
                Vector3 pushDirection = collision.transform.position - transform.position;
                pushDirection.y = 0;
                pushDirection.Normalize();

                collision.transform.position += pushDirection * (pushForce * Time.deltaTime);
            }
        }
    }
}



