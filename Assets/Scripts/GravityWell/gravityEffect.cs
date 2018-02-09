using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravityEffect : MonoBehaviour {

    private float whirlBoost = 1.0f;
    private float gravityModifier = 25f;
    void Start () {
        whirlBoost = 1.0f;
        gravityModifier = 25f;
	}
	
	
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            
            Vector2 playerDirection = other.GetComponent<Rigidbody>().velocity;
            playerDirection.Normalize();

            Vector2 distanceToWell = transform.position - other.transform.position;
            Vector2 directionTowardsWell = distanceToWell.normalized;
            float angle = Vector2.Angle(directionTowardsWell, playerDirection);

            if (angle % 90 < 5f && other.GetComponent<Rigidbody>().velocity.magnitude > 3.0f)
            {
                other.GetComponent<PlayerController>().setWhirl(true);
            }
            else if(other.GetComponent<PlayerController>().getWhirl())
            {
                other.GetComponent<Rigidbody>().AddForce
                (whirlBoost * other.GetComponent<Rigidbody>().velocity.magnitude * gravityModifier / distanceToWell.magnitude * directionTowardsWell, ForceMode.Force);
                whirlBoost += Time.deltaTime / 7;
            }
            else
            {
                other.GetComponent<Rigidbody>().AddForce
                    (whirlBoost * other.GetComponent<Rigidbody>().velocity.magnitude * (gravityModifier / 2) / distanceToWell.magnitude * directionTowardsWell, ForceMode.Force);
            }
            

        }

    }

    private void OnTriggerExit(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            other.GetComponent<PlayerController>().Launch();
            other.GetComponent<PlayerController>().setWhirl(false);
            other.GetComponent<SpawnDespawn>().ForcedDeSpawn();
        }
    }
}
