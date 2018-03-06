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

    //deprecated
    //private void whirlGravity(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {

    //        Vector2 playerDirection = other.GetComponent<Rigidbody>().velocity;
    //        playerDirection.Normalize();

    //        Vector2 distanceToWell = transform.position - other.transform.position;
    //        Vector2 directionTowardsWell = distanceToWell.normalized;
    //        float angle = Vector2.Angle(directionTowardsWell, playerDirection);

    //        if (angle % 90 < 2f && other.GetComponent<Rigidbody>().velocity.magnitude > 3.0f)
    //        {
    //            other.GetComponent<PlayerController>().setWhirl(true);
    //        }
    //        else if (other.GetComponent<PlayerController>().getWhirl())
    //        {
    //            other.GetComponent<Rigidbody>().AddForce
    //            (whirlBoost * other.GetComponent<Rigidbody>().velocity.magnitude * gravityModifier / distanceToWell.magnitude * directionTowardsWell, ForceMode.Force);
    //            whirlBoost += Time.deltaTime / 5;
    //        }
    //        else
    //        {
    //            other.GetComponent<Rigidbody>().AddForce
    //                (whirlBoost * other.GetComponent<Rigidbody>().velocity.magnitude * (gravityModifier / 2) / distanceToWell.magnitude * directionTowardsWell, ForceMode.Force);
    //        }


    //    }
    //}
}