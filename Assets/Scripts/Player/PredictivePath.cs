using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PredictivePath :  MonoBehaviour {


    private LineRenderer lineRenderer;
    private GameObject gravityWell;
    //private Vector3[] linePos;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        

      //  if (Input.GetMouseButtonDown(0))
       // {
            Vector3[] linePos = PredictLine();

            lineRenderer.SetPositions(linePos);

       //}



    }

    Vector3[] PredictLine()
    {

        lineRenderer = gameObject.GetComponent<LineRenderer>();
        //lineRenderer.startWidth = 5;
        //lineRenderer.endWidth = 5;
        lineRenderer.positionCount = 10;
        gravityWell = GameObject.Find("GravWell");

        Vector3 playerVel = gameObject.GetComponent<Rigidbody>().velocity;

        //Vector3 gravityWellPosition = gravityWell.GetComponent<Rigidbody>().transform.position;

        Vector3[] linePos = new Vector3[10];
        Vector3 dynamicPos = Vector3.zero;
        Vector3 tempVec = new Vector3(5, 5, 0);

        for (int i = 9; i > 0; i--)
        {

            Vector3 forceDirection = gameObject.transform.position - gameObject.GetComponent<Rigidbody>().transform.position;
            float differentialDist = forceDirection.magnitude;

            linePos[9-i] = (playerVel * Time.deltaTime) + gameObject.GetComponent<Rigidbody>().transform.position;
            //linePos[1] = gameObject.GetComponent<Rigidbody>().transform.position + tempVec;
            //+ (0.5f * (30f / differentialDist * forceDirection) * Time.deltaTime * Time.deltaTime)
        }
        return linePos;

    }

    void ClearLine()
    {

    }

}
