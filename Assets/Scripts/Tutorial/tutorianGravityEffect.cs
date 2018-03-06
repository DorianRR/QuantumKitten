using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorianGravityEffect : MonoBehaviour
{

    private float whirlBoost = 1.0f;
    private float gravityModifier = 25f;
    void Start()
    {
        whirlBoost = 1.0f;
        gravityModifier = 25f;
    }


    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            realGravity(other);
        }
    }



    private void realGravity(Collider player)
    {
        Rigidbody playerRB = player.GetComponent<Rigidbody>();
        //PlayerController playerPC = player.GetComponent<PlayerController>();

        Vector3 playerDirection = playerRB.velocity.normalized;
        Vector3 distanceToWell = transform.position - player.transform.position;
        Vector3 directionToWell = distanceToWell.normalized;
        //float angle = Vector3.Angle(directionToWell, playerDirection);
        playerRB.AddForce(playerRB.velocity.magnitude * gravityModifier / distanceToWell.magnitude * directionToWell, ForceMode.Force);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            other.GetComponent<PlayerController>().Launch();
            other.GetComponent<SpawnDespawn>().ForcedDeSpawn();
            //other.GetComponent<PlayerController>().setWhirl(false);

        }
    }

    
}