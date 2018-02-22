using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wormHole : MonoBehaviour {

	
	void Start () {
		
	}
	

	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            other.GetComponent<SpawnDespawn>().ForcedDeSpawn();
            other.GetComponent<Rigidbody>().velocity = Vector3.zero;
            other.GetComponent<PlayerController>().disableInput();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            Vector3 forceDirection = transform.position - other.transform.position;
            other.GetComponent<Rigidbody>().AddForce(forceDirection * 2, ForceMode.Force);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.transform.tag == "Player")
        {

        }
    }
}
