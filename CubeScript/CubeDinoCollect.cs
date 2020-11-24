using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CubeDinoCollect : MonoBehaviour
{
    [SerializeField] private float timer;
    private GameObject bot;

    //private GameObject friendBot;

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

        bot = GameObject.FindGameObjectsWithTag("Bot")[0];

        //friendBot = GameObject.Find("friendBot");
    }

    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("Apple") != null)
        {
            apple = GameObject.FindGameObjectWithTag("Apple");
        }

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
                    Debug.Log("Just collected near bot");
                    timer -= Time.deltaTime;
                }

                //if (Vector2.Distance(friendBot.transform.position, apple.transform.position) < angryDistance)
                //{
                //    justCollectedNear2 = true;
                //}
            }
        }     


    }






}
