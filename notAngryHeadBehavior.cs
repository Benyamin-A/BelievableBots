using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class notAngryHeadBehavior : StateMachineBehaviour
{
    private float timer;
    public float angryTime;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = angryTime;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if (timer<=0)
        {
            animator.SetBool("isAngry", false);
        }
        timer -= Time.deltaTime;
    }

   
}
