using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D_gravityForce : MonoBehaviour {

    public GameObject player;
    public int gravityModifier;

    private float differentialDist;
    private Vector3 distanceToWell;
    private Vector3 directionTowardsWell;

    // Use this for initialization
    void Start () {
    
        distanceToWell = gameObject.transform.position - player.transform.position;

    }


    void LateUpdate () {

        distanceToWell = gameObject.transform.position - player.transform.position;
        directionTowardsWell = distanceToWell.normalized;      
    }

    private void OnTriggerStay(Collider other)
    {
        differentialDist = distanceToWell.magnitude;

        other.GetComponent<Rigidbody>().AddForce(gravityModifier/differentialDist*directionTowardsWell, ForceMode.Force);
    }
}
