using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FetchBehavior : StateMachineBehaviour
{
    private Transform applePos;
    public float speed;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        findApple();
        if (GameObject.FindGameObjectWithTag("Apple") != null)
        {
            if (applePos.position.x > animator.transform.position.x)
            {
                //face right
                animator.transform.localScale = new Vector2(1, 1);
            }
            else if (applePos.position.x < animator.transform.position.x)
            {
                //face left
                animator.transform.localScale = new Vector2(-1, 1);
            }

            animator.transform.position = Vector2.MoveTowards(animator.transform.position, applePos.position, speed * Time.deltaTime);

        }
 
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }

    public void findApple()
    {
        if (GameObject.FindGameObjectWithTag("Apple") != null)
        {
            applePos = GameObject.FindGameObjectWithTag("Apple").transform;
        }
    }


}
