using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCommaderBehavior : MonoBehaviour
{
    private Animator anim;
    private NavMeshAgent agent;
    public List<GameObject> enemies;
    private GameObject target;
    public EenemySoldierBehavior soldier;
    public bool HasGun;
    //private GameObject searchGunScript;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (!HasGun)
        //{
        //    HasGun = GetComponent<LookForGun>().LookForAGun();
        //}
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
}
