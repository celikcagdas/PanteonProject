using UnityEngine;
using System.Collections;

public class HalfDonut : MonoBehaviour
{
    public float moveDistance = 6.75f; 
    public float speed = 2f; 
    public float waitTime = 0f; 

    private float startX; 
    private bool movingForward = true; 

    void Start()
    {
        startX = transform.position.x;
        StartCoroutine(Oscillate());
    }

    IEnumerator Oscillate()
    {
        while (true)
        {
            
            if (movingForward)
            {
                transform.position += Vector3.left  * speed * Time.deltaTime;

                
                if (transform.position.x <= startX - moveDistance)
                {
                    movingForward = false; 
                }
            }
            
            else
            {
                transform.position += Vector3.right  * speed * Time.deltaTime;

                
                if (transform.position.x >= startX)
                {
                    movingForward = true; 
                    yield return new WaitForSeconds(waitTime); 
                }
            }

            yield return null; 
        }
    }
}

