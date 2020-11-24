using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class Happy : IState
{
    private readonly CubeBotGatherer _gatherer;

    //private Animator _animator;


    public Happy(CubeBotGatherer gatherer/*,  Animator animator*/)
    {
        _gatherer = gatherer;
        System.Console.WriteLine("Happy Entered");
        //_animator = animator;   
    }

    public void OnEnter()
    {
        //_animator.SetBool("isScared", true);
        System.Console.WriteLine("Happy");
        _gatherer.GetComponent<Renderer>().material.color = Color.yellow;
    }


    public void Tick()
    {
        
    }

    public void OnExit()
    {
        //_gatherer.SetBool("isScared", false);
    }
}