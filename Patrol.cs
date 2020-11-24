using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    
    private float waitTime;
    private float maxWaitTime;
    
    public float minX, maxX, minY, maxY;
    public Transform moveSpot;
    

    private void Start()
    {

        getWaitTime();
        moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        
    }

    private void Update()
    {
        

        
        
        if (waitTime<=0)
        {
            getWaitTime();
            moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
        
    }

    private void getWaitTime()
    {
        maxWaitTime = GetComponent<Instantiation>().timer;
        waitTime = maxWaitTime;
    }
}
