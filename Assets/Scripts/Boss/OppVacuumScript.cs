using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OppVacuumScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("oppvac");
            Vector3 forceDirection = other.transform.position - transform.position;
            other.GetComponent<Rigidbody>().AddForce(forceDirection * 15, ForceMode.Force);
        }
    }
}
