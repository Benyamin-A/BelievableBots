using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotSadFriendBehavior : StateMachineBehaviour
{
    private float hungerCalories;
    private float calories;
    GameObject bot;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bot = GameObject.Find("friendBot");
        hungerCalories = bot.GetComponent<friendCaloriesCounter>().hungerCal;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        calories = bot.GetComponent<friendCaloriesCounter>().calories;
        if (calories > hungerCalories)
        {
            Debug.Log("calories more");
            animator.SetBool("isSad", false);
        }
    }


}
