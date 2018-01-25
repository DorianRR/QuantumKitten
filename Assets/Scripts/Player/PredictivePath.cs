using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PredictivePath :  MonoBehaviour {


    public GameObject player;
    private LineRenderer lineRenderer;
    private GameObject gravityWell;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        

        if (Input.GetMouseButtonDown(0))
        {
            Vector3[] linePos = PredictLine();

            lineRenderer.SetPositions(linePos);
        }

        //if (Input.GetMouseButtonUp(0))
        //{
        //    //Destroy(spawnedWell);
        //}





    }

    Vector3[] PredictLine()
    {

        lineRenderer = gameObject.GetComponent<LineRenderer>();
        gravityWell = GameObject.Find("GravWell");

        Vector3 playerVel = player.GetComponent<Rigidbody>().velocity;

        //Vector3 gravityWellPosition = gravityWell.GetComponent<Rigidbody>().transform.position;

        Vector3[] linePos = new Vector3[100];
        Vector3 dynamicPos = Vector3.zero;

        for (int i = 0; i < 100; i++)
        {

            Vector3 forceDirection = gameObject.transform.position - player.GetComponent<Rigidbody>().transform.position;
            float differentialDist = forceDirection.magnitude;
            Debug.Log("poop");

            linePos[i] = (playerVel * Time.deltaTime) + player.GetComponent<Rigidbody>().transform.position +
                (0.5f * (30f / differentialDist * forceDirection) * Time.deltaTime * Time.deltaTime);

        }
        Debug.Log(linePos);
        return linePos;

    }

    void ClearLine()
    {

    }

}
