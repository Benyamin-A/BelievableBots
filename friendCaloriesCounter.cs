using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class friendCaloriesCounter : MonoBehaviour
{
    public float calories;

    public int intCal;

    [SerializeField] private float timer;
    private Animator anim;

    public float appleCal;
    public float maxCal;
    public float calBurnRate;
    public float hungerCal;
    public int count;





    void Start()
    {
        count = 0;
        calories = maxCal;
        timer = 0;

        anim = this.GetComponent<Animator>();


    }


    void Update()
    {

        //check if lerp is needed


        if (anim.GetBool("isDay") && GameObject.FindGameObjectWithTag("Apple") != null)
        {
            if (calories > maxCal)
            {
                anim.SetBool("isFetching", false);
            }

            else if (calories < hungerCal && calories > .2f)
            {
                anim.SetBool("isFetching", true);
            }
            else if (calories < 0.2f)
            {
                anim.SetBool("isFetching", true);
                calories = 0;
            }
        }

        else
        {
            anim.SetBool("isFetching", false);
        }

        calories -= calBurnRate * Time.deltaTime;


        timer += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Apple"))
        {
            Debug.Log("trigger activated");
            Destroy(collision.gameObject);
            count++;
            calories+=appleCal;
            
        }

    }


}
