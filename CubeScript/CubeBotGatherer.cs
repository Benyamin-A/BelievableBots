using System;
using UnityEngine;
using UnityEngine.AI;


public class CubeBotGatherer : MonoBehaviour
{
    //public event Action<int> OnGatheredChanged;
    private OrangeDinoBoo orangeDino;
    private CubeDinoCollect greenDino;
    private CubeCaloryCounter calCounter;
    public float calories;
    public float hungerCal;

    private StateMachine _stateMachine;

    private void Awake()
    {

        //For scared condition
        orangeDino = GameObject.FindObjectOfType<OrangeDinoBoo>();

        //For angry condition
        greenDino = GameObject.FindObjectOfType<CubeDinoCollect>();

        //For sad condition
        calCounter = GameObject.FindObjectOfType<CubeCaloryCounter>();

        //friend bot not written yet


        _stateMachine = new StateMachine();

        
        //here the Emotion States are declared and instantiated:
        var scared = new Scared(this/*,  animator*/);
        var happy = new Happy(this);
        var sad = new Sad(this);
        var angry = new Angry(this);

        //var depressed = new Depressed(this);

        //here ALL the transitions are added(declared) to _transition
        At(happy, sad, calCounter.calories>hungerCal);
        At(sad, happy, calCounter.calories<hungerCal);

   



        At(angry, happy, orangeDino.booNear1);
        At(happy, angry, angry.timeStuck > 1f);

        _stateMachine.AddAnyTransition(scared, orangeDino.booNear1);
        At(happy, scared, scared.timeStuck>3f);




        //Set the starting ( happy) state 
        _stateMachine.SetState(happy);


        void At(IState to, IState from, bool condition) => _stateMachine.AddTransition(to, from, condition);

    }

    private void Update()
    {
        calories = calCounter.calories;
        _stateMachine.Tick();
    }


}