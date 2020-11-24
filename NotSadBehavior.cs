using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotSadBehavior : StateMachineBehaviour
{
    private float hungerCalories;
    private int calories;
    GameObject bot;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bot = GameObject.Find("Primitive man bot");
        hungerCalories = bot.GetComponent<CaloryCounter>().hungerCal;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        calories = bot.GetComponent<CaloryCounter>().intCal;
        if (calories > hungerCalories) 
        {
            Debug.Log("calories more");
            animator.SetBool("isSad", false);
        }
    }


}
