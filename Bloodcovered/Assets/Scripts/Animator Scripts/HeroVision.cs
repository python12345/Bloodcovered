using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroVision : StateMachineBehaviour
{
    private GameObject bloodyScreen1;
    private GameObject bloodyScreen2;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (bloodyScreen1 == null && bloodyScreen2 == null)
        {
            bloodyScreen1 = animator.gameObject.GetComponent<PlayerVision>().bloodyScreen1;
            bloodyScreen2 = animator.gameObject.GetComponent<PlayerVision>().bloodyScreen2;
        }


        if (animator.GetInteger("Hit") == 1)
        {
            bloodyScreen1.gameObject.SetActive(true);
        }

        if (animator.GetInteger("Hit") == 2)
        {
            bloodyScreen1.gameObject.SetActive(false);
            bloodyScreen2.gameObject.SetActive(true);
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

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
