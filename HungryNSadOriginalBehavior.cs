using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungryNSadOriginalBehavior : StateMachineBehaviour
{
    private GameObject bot;
    private float calories;

    public float sadCalories;
    public float timeB4SadFromHunger;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bot = GameObject.Find("Primitive man bot");

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        calories = bot.GetComponent<CaloryCounter>().intCal;
        if (calories <= sadCalories)
        {

            animator.SetBool("isSad", true);

        }

        else
        {
            animator.SetBool("isSad", false);
        }

    }

}