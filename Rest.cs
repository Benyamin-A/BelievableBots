using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rest : StateMachineBehaviour
{
    
    [SerializeField] private Vector2 retreatPoint;
    public GameObject retreatObj;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //retreatObj = GameObject.Find("retreatPoint");
        retreatPoint = retreatObj.transform.position;       
        

        //flip direction
        if (retreatPoint.x > animator.transform.position.x)
        {
            //face right
            animator.transform.localScale = new Vector2(1, 1);
        }
        else if (retreatPoint.x <= animator.transform.position.x)
        {
            //face left
            animator.transform.localScale = new Vector2(-1, 1);
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        //end rest here:
        if (animator.GetBool("isDay")) 
        {
            animator.SetBool("isResting", false);
            animator.SetBool("isHome", false);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }


}
