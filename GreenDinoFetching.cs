using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenDinoFetching : MonoBehaviour
{
    private Transform applePos;
    public float speed;

    
    // Update is called once per frame
    void Update()
    {
        findApple();
        if (GameObject.FindGameObjectWithTag("Apple") != null)
        {
            if (applePos.position.x < transform.position.x)
            {
                //face right
                transform.localScale = new Vector2(0.61464f, 0.61464f);
            }
            else if (applePos.position.x > transform.position.x)
            {
                //face left
                transform.localScale = new Vector2(-0.61464f, 0.61464f);
            }

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
