using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossTest : MonoBehaviour
{


    private float rotationDegrees = 0;
    private Vector3 rotationVector;

    private float x, y;
    private float speed = 10f;


    // Use this for initialization
    void Start()
    {
        rotationVector = gameObject.transform.position;

    }

    void Update()
    {
        speed *= 0.99f;
        //gameObject.transform.RotateAround(rotationVector, Vector3.up, x * speed);
        //gameObject.transform.RotateAround(rotationVector, Vector3.right, y * speed);



        if(Input.GetKey(KeyCode.Space))
        {
            Debug.Log("hit drag");

            speed = 10f;
            x = -Input.GetAxis("Mouse X");
            y = Input.GetAxis("Mouse Y");
            //transform.position = transform.position + Vector3.up;
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up*(speed /10), ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.down * (speed / 10), ForceMode.Impulse);

        }
    }




    void OnMouseDrag()
    {
        
    }

   
}
