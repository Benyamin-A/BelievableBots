using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunHomeBehavior : StateMachineBehaviour
{
    public GameObject retreatPoint;
    private Vector2 retPointVector;

    public float speed;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //retreatPoint = GameObject.Find("retreatPoint");

        retPointVector = retreatPoint.transform.position;

        animator.SetBool("isResting", true);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector2.Distance(animator.transform.position, retPointVector) < .1f)
        {
            animator.SetBool("isHome", true);
        }

        if (retPointVector.x > animator.transform.position.x)
        {
            //face right
            animator.transform.localScale = new Vector2(1, 1);
        }
        else if (retPointVector.x < animator.transform.position.x)
        {
            //face left
            animator.transform.localScale = new Vector2(-1, 1);
        }

        animator.transform.position = Vector2.MoveTowards(animator.transform.position, retPointVector, speed * Time.deltaTime);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }


}
