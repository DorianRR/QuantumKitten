using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportEffect : MonoBehaviour {

    private GameObject[] exitHoles;
	void Start () {
        exitHoles = GameObject.FindGameObjectsWithTag("ExitHole");
	}
	

	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            int holeNumber = Random.Range(0, exitHoles.Length);
            Vector3 newDirection = calculateTrajectory(exitHoles[holeNumber].transform.position);      
            collision.transform.position = exitHoles[holeNumber].transform.position;
            collision.transform.GetComponent<Rigidbody>().AddForce(newDirection * 10, ForceMode.Impulse);
            collision.transform.GetComponent<PlayerController>().enableInput();
        }
    }

    private Vector3 calculateTrajectory(Vector3 fromPosition)
    {
        bool foundVector = true;
        Vector3 newDirection = new Vector3();
        while (foundVector)
        {
            foundVector = false;
            newDirection = Random.onUnitSphere.normalized;
            newDirection.z = 0;
            if (!Physics.Raycast(fromPosition, newDirection, 5))
            {
                foundVector = true;
            }
      
        }
        return newDirection;
    }
}
