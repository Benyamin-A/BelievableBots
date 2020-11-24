using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoTrigger : MonoBehaviour
{
    public bool PredatorInRange;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Fire") || other.CompareTag("Predator"))
        {
            PredatorInRange = true;
            Debug.Log("Collision with dino");
        }
    }
}
