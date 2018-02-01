using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveIndicator : MonoBehaviour {

	public GameObject objective;
	public GameObject indicator;
	public bool externalPause;

	private Vector3 objDirection;
	private bool objectiveHelp = true;
	private GameObject privateInd;

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
			
			StartCoroutine(ShrinkAndGrow());
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


	IEnumerator ShrinkAndGrow()
	{
		objectiveHelp = false;
		for(int i = 0; i < 50; i++)
		{
			privateInd.transform.localScale += new Vector3(0.02f, 0.02f, 0.02f);
			yield return new WaitForSeconds(0.01f);
		}
		for(int i = 0; i < 50; i++)
		{
			privateInd.transform.localScale -= new Vector3(0.02f, 0.02f, 0.02f);
			yield return new WaitForSeconds(0.01f);
		}
		objectiveHelp = true;

	}
}
