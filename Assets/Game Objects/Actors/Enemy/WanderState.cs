using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderState : StateMachineBehaviour
{

    [SerializeField]
    List<GameObject> wayPoints;
    GameObject currentWayPoint;

    float distance;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        wayPoints = GameObject.FindGameObjectWithTag("WayPoints").GetComponent<WayPoints>().wayPoints;
        currentWayPoint = GameObject.FindGameObjectWithTag("WayPoints").GetComponent<WayPoints>().currentWayPoint;
        animator.GetComponent<SpriteRotator>().lookPoint = currentWayPoint.transform;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        distance = Vector3.Distance(animator.transform.position, currentWayPoint.transform.position);
        animator.transform.position = Vector3.MoveTowards(animator.transform.position, currentWayPoint.transform.position, Time.deltaTime * animator.GetFloat("speed"));

        if (distance < 2)
        {
            currentWayPoint = wayPoints[Random.Range(0, 4)];
            animator.GetComponent<SpriteRotator>().lookPoint = currentWayPoint.transform;
            
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

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
