using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuCatController : MonoBehaviour {

    private A_MenuController Analytics;

    private float rotationDegrees = 0;
    private Vector3 rotationVector;
    
    private float x, y;
    private float speed = 10f;


    // Use this for initialization
    void Start ()
    {
        rotationVector = gameObject.transform.position;
        Analytics = GameObject.Find("Controller").GetComponentInChildren<A_MenuController>();

    }

    void Update()
    {
        speed *= 0.99f;
        gameObject.transform.RotateAround(rotationVector, Vector3.up, x * speed);
        gameObject.transform.RotateAround(rotationVector, Vector3.right, y * speed);

    }

	
	

    void OnMouseDrag()
    {
        speed = 10f;
        x = -Input.GetAxis("Mouse X");
        y = Input.GetAxis("Mouse Y");
    }

    void OnMouseUp()
    {
        Analytics.incrementCatSpins();

    }
}
