using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShooting : MonoBehaviour
{
    public GameObject GunInHand;
    public GameObject aCamera;
    [SerializeField] public GameObject target;
    private LineRenderer lr;
    public GameObject MuzzleEnd;
    private AudioSource sound;
    public ParticleSystem MuzzleFlash;
    public GameObject Enemy1;
    public GameObject Enemy2;
    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        sound = GunInHand.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsPlaying(Enemy1.GetComponent<Animator>(), "mixamoDie"))
        {
            Enemy1.SetActive(false);
        }
        if (IsPlaying(Enemy2.GetComponent<Animator>(), "mixamoDie"))
        {
            Enemy2.SetActive(false);
        }


        if (Input.GetButtonDown("TouchBtn") && GunInHand.activeSelf)
        {
            RaycastHit hit;
            if (Physics.Raycast(aCamera.transform.position, aCamera.transform.forward, out hit))
            {
                target.transform.position = hit.point;
                StartCoroutine(ShowShot());

                if (hit.transform.gameObject.GetComponent<Collider>().Equals(Enemy1.gameObject.GetComponent<Collider>()))
                {
                    Animator a = Enemy1.GetComponent<Animator>();
                    a.SetBool("IsDying", true);

                }
                if (hit.transform.gameObject.GetComponent<Collider>().Equals(Enemy2.gameObject.GetComponent<Collider>()))
                {
                    Animator a = Enemy2.GetComponent<Animator>();
                    a.SetBool("IsDying", true);
                }
            }
        }
    }
    public IEnumerator ShowShot()
    {
        lr.SetPosition(0, MuzzleEnd.transform.position);
        lr.SetPosition(1, target.transform.position);
        lr.enabled = true;
        target.SetActive(true);
        MuzzleFlash.Play();
        sound.Play();
        yield return new WaitForSeconds(0.1f);
        lr.enabled = false;
        target.SetActive(false);
    }
    bool IsPlaying(Animator anim, string stateName)
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName(stateName) &&
                anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
            return true;
        else
            return false;
    }
}
