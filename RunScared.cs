using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunScared : StateMachineBehaviour
{
    public int speed;
    private float scaredTimer=waitTime;
    public static float waitTime;

    //public float waitTimeRate;

    [SerializeField] private Vector2 retreatPoint;
    public GameObject retreatObj;
   

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //retreatPoint = new Vector2(-24, -11);
        //retreatObj = GameObject.Find("retreatPoint");
        retreatPoint = retreatObj.transform.position;
    }

   
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       //flip direction
        if (retreatPoint.x > animator.transform.position.x)
        {
            //face right
            animator.transform.localScale = new Vector2(1, 1);
        }
        else if (retreatPoint.x < animator.transform.position.x)
        {
            //face left
            animator.transform.localScale = new Vector2(-1, 1);
        }

        //move to retreat point
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, retreatPoint, Time.deltaTime*speed);

        //wait in the retreat point
        if (Vector2.Distance(animator.transform.position, retreatPoint) < 0.2f)
        {
            if (waitTime <= 0)
            {

                animator.transform.position = retreatPoint;
                
                scaredTimer = waitTime;
                animator.SetBool("isScared", false);
            }
            else
            {
                //scaredTimer -= waitTimeRate*Time.deltaTime;

                scaredTimer -= Time.deltaTime;
            }
        }
    }

   
   override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {
       
   }


}
