using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D_gravityForce : MonoBehaviour {

    public GameObject player;
    public int gravityModifier;
    //private float differentialDist;

    private Vector3 playerDirection;
    private Vector3 distanceToWell;
    private Vector3 directionTowardsWell;

    // Use this for initialization
    void Start () {
        playerDirection = (player.GetComponent<Rigidbody>().velocity);
        playerDirection.Normalize();
	}
	
	
	void LateUpdate () {

        Vector3 distanceToWell = gameObject.transform.position - player.transform.position;
        directionTowardsWell = distanceToWell.normalized;
        float angle = Vector3.Angle(directionTowardsWell, playerDirection);
        Debug.Log("Hi");
        if(angle == 90)
        {
            Debug.Log("Perp");
        }


    }

    private void OnTriggerStay(Collider other)
    {


        //other.GetComponent<Rigidbody>().AddForce(gravityModifier/differentialDist*forceDirection, ForceMode.Force);
    }
}
