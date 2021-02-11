using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : StateMachineBehaviour
{
    GameObject player;
    Animator playerAnimator;
    float distance;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerAnimator = player.GetComponent<Animator>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        distance = Vector3.Distance(animator.transform.position, player.transform.position);

            if (playerAnimator.GetInteger("health") <= 0)
        {
            animator.SetBool("isChasing", false);
        }


        if (distance > animator.GetFloat("discoverDistance"))
        {
            //Do idle state
            animator.SetBool("isChasing", false);
        }
        
        else if (distance > animator.GetFloat("attackDistance"))
        {
            animator.transform.position += animator.transform.forward * animator.GetFloat("speed") * Time.deltaTime;
        }

        else if (distance < animator.GetFloat("attackDistance"))
        {
            animator.SetBool("isAttacking", true);
        }
        





    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
