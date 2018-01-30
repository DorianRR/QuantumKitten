using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D_PlayerController : MonoBehaviour {


    public Vector3 initialForce = new Vector3(10,7,0);

    private Vector2 playerDirection;
    private Vector2 distanceToWell;
    private Vector2 directionTowardsWell;
    
    void Start () {
        gameObject.GetComponent<Rigidbody>().AddForce(initialForce, ForceMode.Impulse);
	}
	
	void Update ()
    {
        

    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "GravityWell")
        {
            playerDirection = new Vector2(GetComponent<Rigidbody>().velocity.x, GetComponent<Rigidbody>().velocity.y);
            playerDirection.Normalize();

            distanceToWell = other.transform.position - transform.position;
            directionTowardsWell = distanceToWell.normalized;
            float angle = Vector3.Angle(directionTowardsWell, playerDirection);

            if (angle % 90 < 5f)
            {
                Debug.Log("Perp");
            }

        }

        //other.GetComponent<Rigidbody>().AddForce(gravityModifier/differentialDist*forceDirection, ForceMode.Force);
    }
}
