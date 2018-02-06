﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    public Vector3 initialForce = new Vector3(10,7,0);
    public float gravityModifier;
    public bool startedWhirl = false;
    public bool canSpawn = true;
    public float ImpulsePower = 20;

    private Vector2 playerDirection;
    private Vector2 distanceToWell;
    private Vector2 directionTowardsWell;
    private float whirlBoost = 1.0f;
    
    void Start ()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(initialForce, ForceMode.Impulse);
	}
	
	void Update ()
    {
        if(GetComponent<Rigidbody>().velocity.magnitude > 5)
        {
            canSpawn = true;

        }
        if(startedWhirl)
        {
            gameObject.GetComponent<Rigidbody>().AddForce
                (whirlBoost * gameObject.GetComponent<Rigidbody>().velocity.magnitude * gravityModifier/distanceToWell.magnitude*directionTowardsWell, ForceMode.Force);
            whirlBoost += Time.deltaTime / 7;
        }
        else
        {
            GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity * .9999f;
            
        }
        if(GetComponent<Rigidbody>().velocity.magnitude > 50)
        {
            GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity * 0.75f;
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
            float angle = Vector2.Angle(directionTowardsWell, playerDirection);

            if (angle % 90 < 5f && gameObject.GetComponent<Rigidbody>().velocity.magnitude > 3.0f || startedWhirl)
            {
                startedWhirl = true;
            }
            else
            {
                gameObject.GetComponent<Rigidbody>().AddForce
                    (whirlBoost * gameObject.GetComponent<Rigidbody>().velocity.magnitude*(gravityModifier/2)/distanceToWell.magnitude*directionTowardsWell, ForceMode.Force);
            }
            
        }
    }

    private void OnTriggerExit()
    {
        gameObject.GetComponent<SpawnDespawn>().ForcedDeSpawn();

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
