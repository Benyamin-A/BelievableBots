using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class Sad : IState
{
    private readonly CubeBotGatherer _gatherer;

    public bool isSad;
    //private Animator _animator;
    private GameObject bot;
    private float calories;

    public float sadCalories;
    public float timeB4SadFromHunger;

    public Sad(CubeBotGatherer gatherer/*,  Animator animator*/)
    {
        _gatherer = gatherer;
        //isSad = false;
        //_animator = animator;   
    }

    public void OnEnter()
    {
        //_animator.SetBool("isScared", true);
        
        System.Console.WriteLine("Sad Entered");

        _gatherer.GetComponent<Renderer>().material.color = Color.blue;
        

        //bot = GameObject.Find("Primitive man bot");
    }

    public void Tick()
    {
        //calories = bot.GetComponent<CaloryCounter>().intCal;
        //if (calories <= sadCalories)
        //{
        //    isSad = true;
        //}

        //else
        //{
        //    isSad = false;
        //}

    }

    public void OnExit()
    {
        //_gatherer.SetBool("isScared", false);
    }
}