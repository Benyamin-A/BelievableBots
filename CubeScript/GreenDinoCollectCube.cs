using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GreenDinoCollectCube : MonoBehaviour
{
    [SerializeField] private float timer;
    private GameObject bot;
    private GameObject friendBot;
    //private Transform botTrans;
    private GameObject apple;
    //private Transform appleTrans;

    public float waitTime;
    public bool justCollectedNear1;
    public bool justCollectedNear2;
    public float angryDistance;

    private void Start()
    {
        timer = waitTime;

        bot = GameObject.Find("Primitive man bot");

        friendBot = GameObject.Find("friendBot");
    }

    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("Apple") != null)
        {
            apple = GameObject.FindGameObjectWithTag("Apple");
        }

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            justCollectedNear1 = false;
            justCollectedNear2 = false;
            timer = waitTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.CompareTag("Apple"))
        {
            Destroy(collision.gameObject);

            if (GameObject.FindGameObjectWithTag("Apple")!=null)
            {

                if (Vector2.Distance(bot.transform.position,apple.transform.position)<angryDistance)
                {
                    justCollectedNear1 = true;
                }

                if (Vector2.Distance(friendBot.transform.position, apple.transform.position) < angryDistance)
                {
                    justCollectedNear2 = true;
                }
            }
        }     


    }






}
