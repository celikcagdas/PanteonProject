using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowPlayer : MonoBehaviour
{
    public Transform target;
    public Vector3 target_offset;
    void Start()
    {
        //kameranýn pozisyonundan hedefimin pozisyonunu çýkarararak hedefimi buluyorum
        target_offset = transform.position - target.position;
    }
    private Vector3 velocity = Vector3.zero;
    
    private void LateUpdate()
    {
        Vector3 targetPosition = target.position + target_offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, 0.3f);
    }
}
