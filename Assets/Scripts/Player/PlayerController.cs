using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    public Vector3 initialForce = new Vector3(10,7,0);
    public bool startedWhirl = false;
    public bool canSpawn = true;
    public float ImpulsePower = 20;

    private Vector3 playerDirection;
    private bool canBounce = true;

    private float bounceCD = 0.1f;

    void Start ()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(initialForce, ForceMode.Impulse);
	}
	
	void Update ()
    {
        if(!canBounce)
        {
            bounceCD -= Time.deltaTime;
            if(bounceCD<=0f)
            {
                canBounce = true;
                bounceCD = 0.1f;
            }
        }

        //GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity * .9999f;
            
        if(GetComponent<Rigidbody>().velocity.magnitude > 50)
        {
            GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity * 0.75f;
        }

		//Cat facing direction of movement
		playerDirection = GetComponent<Rigidbody>().velocity.normalized;
        gameObject.GetComponentInChildren<Rigidbody>().transform.rotation = Quaternion.LookRotation(playerDirection) ; //transform.rotation =  Quaternion.LookRotation(playerDirection);
        
      

    }

    private void OnCollisionEnter(Collision coll)
    {
        if(coll.transform.tag == "Bounce" && canBounce)
        {
            canBounce = false;
            Vector3 collisionPoint = coll.contacts[0].point;
            Vector3 reverseCollisionVector = -coll.contacts[0].normal;
            Vector3 collisionNormal = new Vector3();
            collisionPoint -= reverseCollisionVector;
            RaycastHit hitInfo;
            if(coll.collider.Raycast(new Ray(collisionPoint,reverseCollisionVector),out hitInfo, 4))
            {
                collisionNormal = hitInfo.normal;
            }
            Vector3 newVelocity = Vector3.Reflect(GetComponent<Rigidbody>().velocity, collisionNormal);
            GetComponent<Rigidbody>().velocity = newVelocity * 0.8f;
        }


        
    }

    private void OnTriggerExit(Collider other)
    {
        
    }

    public void setWhirl(bool status)
    {
        startedWhirl = status;
    }

    public bool getWhirl()
    {
        return startedWhirl;
    }

    public void disableInput()
    {
        //Debug.Log("player input disabled");
        canSpawn = false;
    }

    public void enableInput()
    {
        //Debug.Log("player input enabled");
        canSpawn = true;
    }

    public void Launch()
    {

        gameObject.GetComponent<Rigidbody>().AddForce(gameObject.GetComponent<Rigidbody>().velocity.normalized * 2, ForceMode.Impulse);

    }
}
