using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float runningSpeed = 10f;
    public float xSpeed = 15f;
    public float limitx = 12f;
    float touchXDelta;
    float newX = 0;

    private Animator playerAnim;

    

    void Update()
    {
        SwipeCheck();
    }

    void SwipeCheck()
    {
        
        

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            touchXDelta = Input.GetTouch(0).deltaPosition.x / Screen.width;
        }
        else if (Input.GetMouseButton(0))
        {
            touchXDelta = Input.GetAxis("Mouse X");
        }
        else
        {
            touchXDelta = 0;
        }

        newX += xSpeed * touchXDelta * Time.deltaTime;
        newX = Mathf.Clamp(newX, -limitx, limitx);


        Vector3 newPosition = new Vector3(newX, transform.position.y, transform.position.z + runningSpeed * Time.deltaTime);
        transform.position = newPosition;
    }
}


        





















