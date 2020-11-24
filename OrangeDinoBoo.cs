using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeDinoBoo : MonoBehaviour
{
    [SerializeField] private float timer;
    private CubeBotGatherer bot;

    //private GameObject friendBot;

    public float waitTime;
    public bool booNear1;
    //public bool booNear2;
    public float booDistance;

    private void Start()
    {
        timer = waitTime;
        bot = GameObject.FindObjectOfType<CubeBotGatherer>();
        //friendBot = GameObject.Find("friendBot");

    }

    private void Update()
    {
        if (Vector2.Distance(bot.transform.position, this.transform.position) < booDistance)
        {
            booNear1 = true;
            Debug.Log("booNear1 true");
            bot.GetComponent<Renderer>().material.color = Color.magenta;
            timer = waitTime;

        }

        else
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                booNear1 = false;
                Debug.Log("booNear1 false");
                bot.GetComponent<Renderer>().material.color = Color.yellow;
            }
        }







        //if (Vector2.Distance(friendBot.transform.position, friendBot.transform.position) < booDistance)
        //{
        //    booNear2 = true;
        //} 
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Bot"))
    //    {
                
    //    }
    //}

}
