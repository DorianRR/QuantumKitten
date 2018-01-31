using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D2_PlayerController : MonoBehaviour {


    public Vector3 initialForce = new Vector3(10,7,0);
    public float gravityModifier;
    public bool startedWhirl = false;
    public bool pullButNotWhirl = false;


    private Vector2 playerDirection;
    private Vector2 distanceToWell;
    private Vector2 directionTowardsWell;
    private Vector2 gWPosition;
    private float whirlBoost = 1.0f;
    
    void Start ()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(initialForce, ForceMode.Impulse);
	}
	
	void Update ()
    {
        if(startedWhirl)
        {
            gameObject.GetComponent<Rigidbody>().AddForce
                (whirlBoost * gameObject.GetComponent<Rigidbody>().velocity.magnitude * gravityModifier/distanceToWell.magnitude*directionTowardsWell, ForceMode.Force);
            //whirlBoost += Time.deltaTime / 9;
        }
        else if (pullButNotWhirl)
        {
            Vector3 temp = (Quaternion.Euler(0, 0, 90) * directionTowardsWell);
            gameObject.GetComponent<Rigidbody>().AddForce(gravityModifier * temp);
        }
        else
        {
            GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity * .9999f;
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
            if (angle % 90 < 5f && gameObject.GetComponent<Rigidbody>().velocity.magnitude > 3.0f)
            {
                pullButNotWhirl = false;
                startedWhirl = true;
                gWPosition = other.transform.position;
            }
            else if(gameObject.GetComponent<Rigidbody>().velocity.magnitude < 3.0f)
            {
                pullButNotWhirl = true;
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        startedWhirl = false;

    }

    public void Launch()
    {
        GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity * 1.15f;
    }


}
