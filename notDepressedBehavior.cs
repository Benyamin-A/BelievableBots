using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notDepressedBehavior : StateMachineBehaviour
{

    public float meetingDistance;
    

    public string friendName;
    private GameObject friend;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        friend = GameObject.Find(friendName);
    }
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector2.Distance(animator.transform.position, friend.transform.position) < meetingDistance)
        {
            animator.SetBool("justMet", true);
            animator.SetBool("isDepressed", false);

        }
    }

    
}
