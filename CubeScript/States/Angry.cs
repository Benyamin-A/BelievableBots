using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class Angry : IState
{
    private readonly CubeBotGatherer _gatherer;

    //public bool isAngry;
    public float timeStuck;
    //private Animator _animator;

    public OrangeDinoBoo orangeDino;

    public Angry(CubeBotGatherer gatherer/*,  Animator animator*/)
    {
        _gatherer = gatherer;
        //isAngry = false;   
        //_animator = animator;   
    }

    public void OnEnter()
    {
        //_animator.SetBool("isScared", true);
        
        System.Console.WriteLine("Angry Entered");
        _gatherer.GetComponent<Renderer>().material.color = Color.red;

        //orangeDino = GameObject.FindObjectOfType<OrangeDinoBoo>();
        timeStuck = 0;
    }

    public void Tick()
    {

        timeStuck += Time.deltaTime;
    }

    public void OnExit()
    {
        //_gatherer.SetBool("isScared", false);
    }
}