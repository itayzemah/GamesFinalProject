using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EenemySoldierBehavior : MonoBehaviour
{
    private Animator anim;
    private NavMeshAgent agent;
    public GameObject commander;
    public List<GameObject> enemies;
    private GameObject target;

    public bool HasGun { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        if (commander.activeSelf)
        {
            agent.SetDestination(commander.transform.position);
        }
        else
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].activeSelf)
                {
                    target = enemies[i];
                    break;
                }
            }
            agent.SetDestination(target.transform.position);
        }
        /*
        if(Input.GetKey("x"))
        {
            anim.SetBool("IsWalking", true);
        }
        else
        {
            if (Input.GetKey("z"))
                anim.SetBool("IsDying", true);
            else
                 anim.SetBool("IsWalking", false);
        }
        */
    }
}
