using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkingBehavior : StateMachineBehaviour
{
    NavMeshAgent agent;
    Transform player;
    float attackRange = 2;
    
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        agent.speed = 2;

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(player.transform.position);
        float distance = Vector3.Distance(animator.transform.position, player.position);

        if (distance < attackRange)
            animator.SetBool("JumpScare", true);
    }


    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
        agent.speed = 0;
    }
}
