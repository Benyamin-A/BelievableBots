using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class angryHeadBehavior : StateMachineBehaviour
{
    private GameObject dino;


    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        dino = GameObject.FindGameObjectWithTag("Dinosaur");
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (dino.GetComponent<DinoCollect>().justCollectedNear1)
        {
            animator.SetBool("isAngry", true);
        }
    }

   
}
