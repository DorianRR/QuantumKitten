using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class snitchController : MonoBehaviour {

    private enum State { Rest, Move };
    private State current;
    private float restTimer = 3f;
    private Vector3 targetLocation;
    private float moveSpeed;

	void Start () {
        current = State.Rest;
        restTimer = 3.0f;
        moveSpeed = 10f;
	}
	

	void Update () {

        if (current == State.Rest)
        {
            //do rest things
            restTimer -= Time.deltaTime;
            if(restTimer<=0f)
            {
                restTimer = 3.0f;
                findNewLocation();
                current = State.Move;
            }
            Rest();
        }
        else if(current == State.Move)
        {
            //do move things
            Move();
            if(Vector3.Distance(transform.position,targetLocation) < 0.3f)
            {
                current = State.Rest;
            }
        }
	}

    private void Rest()
    {
        //just chill for now
    
    }

    private void Move()
    {
        Vector3 moveDirection = (targetLocation - transform.position).normalized;
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }
    private void findNewLocation()
    {
        targetLocation = new Vector3(Random.Range(-35, 35),Random.Range(-70, 70),transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger");
        if (other.transform.tag == "Player")
        {
            Debug.Log("you caught the snitch");
            GameObject.Find("Player").GetComponent<ObjectiveIndicator>().objectiveHelp = false;
            GameObject.Find("Player").GetComponent<ObjectiveIndicator>().externalPause = true;
            Destroy(gameObject);
        }
    }
}
