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
    public GameObject MuzzleEnd;
    public ParticleSystem MuzzleFlash;
    public GameObject mySelf;
    private GameObject target;
    private LookForGun lookForGun;
    private LineRenderer lr;
    public bool HasGun { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        lookForGun = gameObject.GetComponent<LookForGun>();
        lr = GetComponent<LineRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!lookForGun.HasGun)
        {
            lookForGun.enabled = true;
            lookForGun.Invoke("Start", time: 0.0f);
        }
        else
        {
            lookForGun.enabled = false;

        }
        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i].activeSelf)
            {
                target = enemies[i];
                break;
            }
        }
        if (commander.activeSelf)
        {
            agent.SetDestination(commander.transform.position);
        }
        else
        {

            agent.SetDestination(target.transform.position);
        }
        RaycastHit hit;
        var rayDirection = mySelf.transform.position - transform.position;

        Physics.Raycast(mySelf.transform.position, rayDirection, out hit);
        {
            StartCoroutine(ShowShot(hit));

            //if (hit.transform.gameObject.GetComponent<Collider>().Equals(target.gameObject.GetComponent<Collider>()))
            //{
            //    Animator a = target.GetComponent<Animator>();
            //    a.SetBool("IsDying", true);

            //}

        }

    }

    public IEnumerator ShowShot(RaycastHit hitPoint)
    {
        lr.SetPosition(0, MuzzleEnd.transform.position);
        lr.SetPosition(1, Vector3.Scale(MuzzleEnd.transform.position, new Vector3(MuzzleEnd.transform.position.x * -2.5f, 
                1, MuzzleEnd.transform.position.z *  -2.5f)));
        lr.enabled = true;
        MuzzleFlash.Play();
        yield return new WaitForSeconds(0.1f);
        lr.enabled = false;
    }
}
