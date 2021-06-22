using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = System.Random;

public class LookForGun : MonoBehaviour
{
    public bool HasGun { get; set; }
    public List<GameObject> gunList;
    private Animator anim;
    private NavMeshAgent agent;
    private GameObject puckGun;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!HasGun)
        {
            LookForAGun();
        }
    }

    public bool LookForAGun()
    {

        return GoToRandomPlace();
    }

    private bool GoToRandomPlace()
    {

        Random r = new Random();
        int index = r.Next(0, gunList.Count);
        agent.SetDestination(gunList[index].transform.position);
        if(agent.remainingDistance - 1 <= agent.stoppingDistance)
           return TryTakeGun();
        else
        {
            return false;
        }

    }

    private bool TryTakeGun()
    {
        
        return false;
    }
}
