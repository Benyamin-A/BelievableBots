using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class LightAdjuster : MonoBehaviour
{
    public Light light;
    public float lightChangeRate;
    public float cyclePeriod;

    private float timer;
    private Animator[] anim;

    //public static float nightIntensity;
    void Start()
    {
        light = GetComponent<Light>();
        timer = 0;
        anim = GameObject.FindObjectsOfType<Animator>();
    }

    
    void Update()
    {
        timer += Time.deltaTime;

        if (timer>cyclePeriod && timer<2*cyclePeriod)
        {
            //nightIntensity = .2f;

            //end of the day
            light.intensity = Mathf.Lerp(light.intensity,.1f,lightChangeRate * Time.deltaTime);

            if (light.intensity < .5f)
            {
                foreach(Animator i in anim)
                {
                    i.SetBool("isDay", false);
                }
            }
        }

        else if (timer>2*cyclePeriod)
        {
            //end of the night
            //nightIntensity = light.intensity;
            //light.intensity = Mathf.Lerp(nightIntensity,1f,lightChangeRate*Time.deltaTime);
            light.intensity = 1f;
            foreach(Animator i in anim)
                {
                    i.SetBool("isDay", true);
                }
            timer = 0;
        }


        
    }
}
