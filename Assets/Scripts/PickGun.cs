using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickGun : MonoBehaviour
{
    public GameObject gunInStandby;
    public GameObject Enemy1gunInHand;
    public GameObject Enemy2gunInHand;
    public GameObject Team2gunInHand;
    public GameObject PlayergunInHand;

    private void OnMouseDown()
    {
        gunInStandby.SetActive(false);
        PlayergunInHand.SetActive(true);
    }

    private void OnTriggerEnter(Collider other) // player or other character's collider
    {
        switch (other.name)
        {
            case "Enemy1":
                gunInStandby.SetActive(false);
                Enemy1gunInHand.SetActive(true);
                break;
            case "Enemy2":
                gunInStandby.SetActive(false);
                Enemy2gunInHand.SetActive(true);
                break;
            case "Team2":
                gunInStandby.SetActive(false);
                Team2gunInHand.SetActive(true);
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
}
