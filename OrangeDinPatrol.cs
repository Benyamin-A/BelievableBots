using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeDinPatrol : MonoBehaviour
{
    private float waitTime;

    public float publicWaitTime;
    public float minX, maxX, minY, maxY;
    public float speed;
    public Transform moveSpot;

    void Start()
    {
        waitTime = publicWaitTime;
        moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
    }

    
    private void Update()
    {
        if (moveSpot.position.x > transform.position.x)
        {
            //face right
            transform.localScale = new Vector2(0.143656f, 0.143656f);
        }
        else if (moveSpot.position.x < transform.position.x)
        {
            //face left
            transform.localScale = new Vector2(-0.143656f, 0.143656f);
        }

        transform.position = Vector2.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);


        if (waitTime<=0)
        {
            waitTime = publicWaitTime;
            moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
        
    }


}
