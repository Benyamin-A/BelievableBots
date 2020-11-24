using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Instantiation : MonoBehaviour
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject prefab;

    public float maxTimeInterval,minTimeInterval;
    public float timer;
    public float initDelayB4Spawn=2;

    private float timeToNextSpawn;
    private Animator anim;
    private Vector2 spawnPos;

    void Start()
    {
        timer = Time.time + initDelayB4Spawn;
        spawnPos = this.transform.position;
        anim = GameObject.FindObjectOfType<Animator>();
    }


    void Update()
    {
        spawnPos = this.transform.position;

        if (GameObject.Find("apple(Clone)")==null && anim.GetBool("isDay"))
        {
            if (timer <= 0)
            {
                this.spawnPos = GetComponent<Patrol>().moveSpot.position;
                Instantiate(prefab, spawnPos, Quaternion.identity);
                getTimer();
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }


    }

    private void getTimer()
    {
        timeToNextSpawn = UnityEngine.Random.Range(minTimeInterval, maxTimeInterval);
        timer = timeToNextSpawn;
    }
}
