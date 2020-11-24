using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunScaredByLight : MonoBehaviour
{
    public Light light;
    Animator anim;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (light.intensity<.3f)
        {
            anim.SetBool("isScared", true);
        }
    }
}
