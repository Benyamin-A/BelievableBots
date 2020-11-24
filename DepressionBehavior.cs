using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepressionBehavior : StateMachineBehaviour
{
    public float meetingDistance;
    public float missingTime;
    [SerializeField] private float timer;

    public string friendName;
    private GameObject friend;


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = missingTime;
        friend = GameObject.Find(friendName);
    }

    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer -= Time.deltaTime;
 
        if (Vector2.Distance(animator.transform.position, friend.transform.position) < meetingDistance)
        {
            timer = missingTime;
            animator.SetBool("justMet", true);
        }

        else
        {
            animator.SetBool("justMet", false);
            if (timer<0)
            {
                animator.SetBool("isDepressed", true);
            }
        }


    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    
}
