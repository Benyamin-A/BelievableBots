using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collect : MonoBehaviour
{

    public int count;
    public Text countText;
    private void Start()
    {
        count = 0;
        SetCountText();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Apple"))
        {
            Debug.Log("trigger activated");
            Destroy(collision.gameObject);
            count++;
            SetCountText();
        }
        
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
    }
}
