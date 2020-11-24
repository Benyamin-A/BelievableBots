using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeFetchBehavior : MonoBehaviour
{
    private Transform applePos;
    public float speed;



    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    public void Update()
    {
        findApple();
        if (GameObject.FindGameObjectWithTag("Apple") != null)
        {
            //if (applePos.position.x > transform.position.x)
            //{
            //    //face right
            //    transform.localScale = new Vector2(1, 1);
            //}
            //else if (applePos.position.x < transform.position.x)
            //{
            //    //face left
            //    transform.localScale = new Vector2(-1, 1);
            //}

            transform.position = Vector2.MoveTowards(transform.position, applePos.position, speed * Time.deltaTime);

        }
 
    }


    public void findApple()
    {
        if (GameObject.FindGameObjectWithTag("Apple") != null)
        {
            applePos = GameObject.FindGameObjectWithTag("Apple").transform;
        }
    }


}
