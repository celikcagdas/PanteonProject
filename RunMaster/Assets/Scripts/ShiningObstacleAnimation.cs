using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class ShiningObstacleAnimation : MonoBehaviour
{
    public float speed = 1.5f;
    public float strength = 9f;
    private float randomOffset;
    public ParticleSystem collisionEffect; 
    public UnityEngine.Color collisionColor = UnityEngine.Color.red; 
    private Material particleMaterial; 

    private UnityEngine.Color originalColor; 

    void SetParticleColor(UnityEngine.Color color, Collider other)
    {
        if (collisionEffect != null)
        {
            var main = collisionEffect.main;
            main.startColor = new UnityEngine.Color(255,0,0);
            collisionEffect.Play(); 
        }
    }
    void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player") && collisionEffect != null)
        {
            
            var main = collisionEffect.main;
            main.startColor = UnityEngine.Color.red;

            
            collisionEffect.Play();
        }
    }

    private void Start()
    {
        
        randomOffset = Random.Range(-2.5f, 2.5f);
    }

    private void Update()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Sin(Time.time * speed + randomOffset) * strength;
        transform.position = pos;
    }
}
