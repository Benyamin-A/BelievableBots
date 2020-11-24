using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class Scared :  IState
{
    private readonly CubeBotGatherer _gatherer;
    public float timeStuck;
    public OrangeDinoBoo dino;
    public bool isScared;

    public int speed;


    //private Animator _animator;
    [SerializeField] private Vector2 retreatPoint=new Vector2(-15,-6);

    public Scared(CubeBotGatherer gatherer/*,  Animator animator*/)
    {
        isScared = false;
        _gatherer = gatherer;
        //_animator = animator;   
    }

    public void OnEnter()
    {
        //_animator.SetBool("isScared", true);
        speed = 10;
        System.Console.WriteLine("Scared Entered");
        _gatherer.GetComponent<Renderer>().material.color = Color.magenta;
        dino= GameObject.FindObjectOfType<OrangeDinoBoo>();
        timeStuck = 0;

}


    public void Tick()
    {
        //if (isScared == true)
        //{
            if (Vector2.Distance(_gatherer.transform.position, retreatPoint) > 0.2f)
            {
                _gatherer.transform.position = Vector2.MoveTowards(_gatherer.transform.position, retreatPoint, Time.deltaTime * speed);
            }

        //}
        timeStuck += Time.deltaTime;
    }

    public void OnExit()
    {
        //_gatherer.SetBool("isScared", false);
    }
}