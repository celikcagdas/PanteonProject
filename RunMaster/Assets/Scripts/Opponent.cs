using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Opponent : MonoBehaviour
{
    public NavMeshAgent OpponentCharacter;
    public GameObject Target;
    Vector3 OpponentStartPos;
    void Start()
    {
        OpponentCharacter = GetComponent<NavMeshAgent>();
    }

   
    void Update()
    {
        OpponentCharacter.SetDestination(Target.transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("obstacle"))
        {
            transform.position = OpponentStartPos;
        }

    }
}
