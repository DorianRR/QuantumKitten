using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicGravController : MonoBehaviour {


    public Vector3 initialForce = new Vector3(10,7,0);
    public float gravityModifier;
    public bool startedWhirl = false;
    public bool canSpawn = true;
    public GameObject stoppedUI;
    public float ImpulsePower = 20;

    private Vector2 playerDirection;
    private Vector2 distanceToWell;
    private Vector2 directionTowardsWell;
    private float whirlBoost = 1.0f;
    
    void Start ()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(initialForce, ForceMode.Impulse);
        stoppedUI.SetActive(false);
	}
	
	void Update ()
    {
        if(GetComponent<Rigidbody>().velocity.magnitude > 5)
        {
            stoppedUI.SetActive(false);
            canSpawn = true;

        }
        else
        {
            if(GetComponent<Rigidbody>().velocity.magnitude < 5)
            {
                canSpawn = false;
                stoppedUI.SetActive(true);
            }
        }
    }

    private void OnCollisionEnter(Collision coll)
    {
        //This controls the bounce when you hit something. Don't get lost in the mess.
        gameObject.GetComponent<Rigidbody>().AddForce(-(gameObject.GetComponent<Rigidbody>().velocity) * 1.5f, ForceMode.Impulse);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "GravityWell")
        {
            playerDirection = new Vector2(GetComponent<Rigidbody>().velocity.x, GetComponent<Rigidbody>().velocity.y);
            playerDirection.Normalize();

            distanceToWell = other.transform.position - transform.position;
            directionTowardsWell = distanceToWell.normalized;

         
            gameObject.GetComponent<Rigidbody>().AddForce
                (gameObject.GetComponent<Rigidbody>().velocity.magnitude*(gravityModifier)/distanceToWell.magnitude*directionTowardsWell, ForceMode.Force);
            
            
        }
    }

    private void OnTriggerExit()
    {
        gameObject.GetComponent<D4_SpawnBasic>().ForcedDeSpawn();

    }

    private void OnTriggerExit(Collider other)
    {
        startedWhirl = false;

    }

    public void Launch()
    {
        GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity * 1.15f;
    }

    public void ImpulseUp()
    {
        canSpawn = true;
        gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0,ImpulsePower,0), ForceMode.Impulse);
        stoppedUI.SetActive(false);

    }

    public void ImpulseRight()
    {
        canSpawn = true;
        gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(ImpulsePower,0,0), ForceMode.Impulse);
        stoppedUI.SetActive(false);

    }

    public void ImpulseDown()
    {
        canSpawn = true;
        gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0,-ImpulsePower,0), ForceMode.Impulse);
        stoppedUI.SetActive(false);

    }

    public void ImpulseLeft()
    {
        canSpawn = true;
        gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(-ImpulsePower,0,0), ForceMode.Impulse);
        stoppedUI.SetActive(false);

    }


}
