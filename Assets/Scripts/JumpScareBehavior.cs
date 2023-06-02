using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.AI;

public class JumpScareBehavior : StateMachineBehaviour
{
    float timer;
    public EnemyAI jumpscare;

    Transform player;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if (jumpscare == true)
        {
            animator.transform.LookAt(player);
            animator.SetBool("JumpScare", true);
        }
    }


    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
