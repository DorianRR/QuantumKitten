using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveIndicator : MonoBehaviour {

	public GameObject objective;
	public GameObject indicator;
	public bool externalPause;

	private Vector3 objDirection;
	public bool objectiveHelp = true;
	private GameObject privateInd;
	private Vector3 playerDirection;

	void Start () 
	{
		objDirection = objective.transform.position - transform.position;
		objDirection.Normalize();
		privateInd = Instantiate(indicator);
		
	}
	
	void LateUpdate () 
	{
		if(objectiveHelp)
		{			
			objDirection = objective.transform.position - transform.position;
			objDirection.Normalize();
			
		}
		
		if(!externalPause)
		{
			privateInd.transform.position = transform.position + (objDirection * Mathf.Clamp(gameObject.GetComponent<Rigidbody>().velocity.magnitude/2, 10, 30));
			privateInd.SetActive(true);

		}
		else
		{
			privateInd.SetActive(false);
		}



		
	}


}
