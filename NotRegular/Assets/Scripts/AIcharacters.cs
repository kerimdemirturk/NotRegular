using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIcharacters : MonoBehaviour
{
    public Animator aýCharacterAnimator;
    private int bulletCount = 0;

    public Transform[] destinationPoints;
    private int destinationPoint;
    private NavMeshAgent agent;
    private bool isDead=false;

    void Start()
    {
        aýCharacterAnimator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
    }


    void Update()
    {
        if(!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            destinationMovement();
        }
       
    }

    //agents patrolling between destinations.
    void destinationMovement()
    {
        if(destinationPoints.Length == 0)
        {
            return;
        }
        agent.destination = destinationPoints[destinationPoint].transform.position;
        destinationPoint = (destinationPoint + 1) % destinationPoints.Length;
    }


    //when AI get bullet start to run and try escape
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "bullet")
        {
            bulletCount += 1;
            Debug.Log("bullet" + bulletCount);
            float transformY = transform.position.y;

            if (bulletCount == 1)
            {
                aýCharacterAnimator.SetBool("run", true);
            }
            if(bulletCount >= 3)
            {
                aýCharacterAnimator.SetBool("die", true);
                Debug.Log("bullet" + bulletCount);
                isDead = true;
                transformY = -0.835f;
                agent.speed = 0;
            }
            if(isDead == true)
            {

            }
            
        }
    }
    
}
