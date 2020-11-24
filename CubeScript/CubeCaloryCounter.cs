using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class CubeCaloryCounter : MonoBehaviour
{
    public float calories;
    public int intCal;
    [SerializeField] private float timer;
    [SerializeField] private float appleCalories;
    private Animator anim;
    private float maxSpawnTime;
    private float dayCyclePeriod;

    public float maxCal;
    public float calBurnRate;
    public float hungerCal;
    public int count;
    
    public Text calText;
    public Text countText;

    public bool caloriesSad;
   

    void Start()
    {
        //maxSpawnTime =gameObject.GetComponent<Instantiation>().maxTimeInterval;
        //dayCyclePeriod = gameObject.GetComponent<LightAdjuster>().cyclePeriod;
        //appleCalories = (dayCyclePeriod / maxSpawnTime) * maxCal;
        appleCalories = 750;

        count = 0;
        calories = maxCal;
        SetCountText();
        setCalText();
        timer = 0;
        
        anim = this.GetComponent<Animator>();
        
       
    }

   
    void Update()
    {
        
        
        if (anim.GetBool("isDay") && GameObject.FindGameObjectWithTag("Apple")!=null)
        {
            if (calories>maxCal)
            {
                anim.SetBool("isFetching", false);

                //to be deleted at the end
                GetComponent<Renderer>().material.color = Color.yellow;
            }

            else if (calories<hungerCal && calories>.2f )
            {
                anim.SetBool("isFetching", true);
                caloriesSad = true;

                //to be deleted at the end
                GetComponent<Renderer>().material.color = Color.blue;
            }
            else if (calories<0.2f)
            {
                anim.SetBool("isFetching", true);
                calories = 0;
            }
        }

        else
        {
            anim.SetBool("isFetching", false);

            //to be deleted at the end
            GetComponent<Renderer>().material.color = Color.yellow;
        }

        calories -= calBurnRate * Time.deltaTime;
        
        
        setCalText();
                
        timer +=Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Apple"))
        {
            Debug.Log("trigger activated");
            Destroy(collision.gameObject);
            count++;
            calories+=appleCalories;
            SetCountText();
        }

    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
    }

    public void setCalText()
    {
        intCal = Convert.ToInt32(Mathf.Round(calories)) ;
        calText.text = "Calories: " + intCal.ToString();
    }
}



