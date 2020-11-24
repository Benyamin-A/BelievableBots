using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class Depressed : IState
{
    private readonly CubeBotGatherer _gatherer;

    public bool isDepreesed;

    public Depressed(CubeBotGatherer gatherer/*,  Animator animator*/)
    {
        _gatherer = gatherer;

        isDepreesed = false;
        //_animator = animator;   
    }

    public void OnEnter()
    {
        //_animator.SetBool("isScared", true);
        
        System.Console.WriteLine("Depressed Entered");
        _gatherer.GetComponent<Renderer>().material.color = Color.gray;
    }

    public void Tick()
    {
        


    }

    public void OnExit()
    {
        //_gatherer.SetBool("isScared", false);
    }
}