using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravityForce : MonoBehaviour {

    public int gravityModifier;
    // Use this for initialization
	void Start () {
	}
	
	
	void Update () {
        
	}
    private void OnTriggerStay(Collider other)
    {
        Vector3 forceDirection = gameObject.transform.position - other.transform.position;
        Debug.Log(forceDirection);
        other.GetComponent<Rigidbody>().AddForce(gravityModifier*forceDirection, ForceMode.Force);
    }
}
