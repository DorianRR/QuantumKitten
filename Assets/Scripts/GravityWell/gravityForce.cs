using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravityForce : MonoBehaviour {

    public int gravityModifier;
    private float differentialDist;

    // Use this for initialization
    void Start () {
	}
	
	
	void Update () {
        
	}
    private void OnTriggerStay(Collider other)
    {
        Vector3 forceDirection = gameObject.transform.position - other.transform.position;
        differentialDist = forceDirection.magnitude;
        other.GetComponent<Rigidbody>().AddForce(gravityModifier/differentialDist*forceDirection, ForceMode.Force);
    }
}
