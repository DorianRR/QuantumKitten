using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D_PlayerController : MonoBehaviour {


    public Vector3 initialForce = new Vector3(10,7,0);
    public float gravityModifier;
    public bool startedWhirl = false;
    public Vector2 direction;


    private Vector2 playerDirection;
    private Vector2 distanceToWell;
    private Vector2 directionTowardsWell;
    private Vector2 gWPosition;
    
    void Start () {
        gameObject.GetComponent<Rigidbody>().AddForce(initialForce, ForceMode.Impulse);
	}
	
	void LateUpdate ()
    {
        
        
        if(startedWhirl)
        {
            float angle = Vector2.Angle(directionTowardsWell, playerDirection);

            //angle = angle - Time.deltaTime;
            direction = Quaternion.Euler(0, 0, -1) * direction;
            transform.position = direction + gWPosition;
            //transform.position = Vector2.Lerp(transform.position, direction + gWPosition, 0.25f * Time.deltaTime);
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "GravityWell")
        {

            playerDirection = new Vector2(GetComponent<Rigidbody>().velocity.x, GetComponent<Rigidbody>().velocity.y);
            playerDirection.Normalize();

            distanceToWell = other.transform.position - transform.position;
            directionTowardsWell = distanceToWell.normalized;
            float angle = Vector2.Angle(directionTowardsWell, playerDirection);
            if (angle % 90 < 5f)
            {
                Debug.Log("Perp");
                startedWhirl = true;
                gWPosition = other.transform.position;
            }

        }
        //other.GetComponent<Rigidbody>().AddForce(gravityModifier/differentialDist*forceDirection, ForceMode.Force);
    }

    public void Launch()
    { 
}

   
    
}
