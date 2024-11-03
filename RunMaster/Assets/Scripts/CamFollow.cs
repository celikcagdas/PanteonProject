using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 target_offset;
    void Start()
    {
        //kameranın pozisyonundan hedefimin pozisyonunu çıkarararak hedefimi buluyorum
        target_offset = transform.position - target.position;
    }
    private Vector3 velocity = Vector3.zero;
    // Update is called once per frame
    private void LateUpdate()
    {
        Vector3 targetPosition = target.position + target_offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, 0.3f);
    }
}
