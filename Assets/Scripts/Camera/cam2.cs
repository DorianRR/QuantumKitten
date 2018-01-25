using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComplexCamera : MonoBehaviour
{

    public GameObject player;
    public float cameraSpeed;

    private Vector3 offset;
    private Vector2 dimensions;
    private Vector3 BottomLeft; 
    

    void Start()
    {
        
        //This takes the initial positions of the camera and player and finds the offset which we use later.
        offset = transform.position - player.transform.position;

        //This gives us the dimensions of the camera's field of view in Unity units as a vector2. Something like 60,20
        CalculateScreenSizeInWorldCoords();

        Vector3 v1 = new Vector3(0, 0, Camera.main.nearClipPlane);
        BottomLeft = Camera.main.ViewportToWorldPoint(v1);
    }

    void LateUpdate()
    {
        //These lines reset the BottomLeft variable as the camera moves, which should be important for detecting if the player is off the playfield.
        Vector3 v1 = new Vector3(0, 0, Camera.main.nearClipPlane);
        BottomLeft = Camera.main.ViewportToWorldPoint(v1);

        //This is statement detects if the player is within a range of the screen edge and calls smoothCamera to move the camera accordingly.
        if (Mathf.Abs(transform.position.x - player.transform.position.x) > dimensions.x / 5 || Mathf.Abs(transform.position.y - player.transform.position.y) > dimensions.y / 5 && CheckPlayerBounds())
        {
            SmoothCamera();
        }
        else
        {
            this.GetComponent<Rigidbody>().velocity = this.GetComponent<Rigidbody>().velocity * .99f ;
            if (!CheckPlayerBounds())
            {
                Debug.Log("offscreen");
                transform.position = player.transform.position + offset;
            }
        }
    }

    void CalculateScreenSizeInWorldCoords()
    {
        /*
         * The following lines get the coordinated for the near clipping plane, 
         * and then use viewport to world point to get the world coordinates of
         * three of those corners which are used to find the dimensions of the play field.
         */
        Vector3 v1 = new Vector3(0, 0, Camera.main.nearClipPlane);
        Vector3 v2 = new Vector3(1, 0, Camera.main.nearClipPlane);
        Vector3 v3 = new Vector3(1, 1, Camera.main.nearClipPlane);

        v1 = Camera.main.ViewportToWorldPoint(v1);
        v2 = Camera.main.ViewportToWorldPoint(v2);
        v3 = Camera.main.ViewportToWorldPoint(v3);

        dimensions = new Vector2((v2.x - v1.x), (v3.y - v2.y));
    }

    void SmoothCamera()
    {
        this.GetComponent<Rigidbody>().velocity = player.GetComponent<Rigidbody>().velocity * 2.0f;
    }

    bool CheckPlayerBounds()
    {
        if (player.transform.position.x >= BottomLeft.x + dimensions.x)
        {
            Debug.Log("Broken3");
            return false;
        }
        if (player.transform.position.x <= BottomLeft.x)
        {
            Debug.Log("Broken4");
            return false;
        }
        if (player.transform.position.y > BottomLeft.y + dimensions.y)
        {
            Debug.Log("Broken3");
            return false;
        }
        if (player.transform.position.y < BottomLeft.y)
        {
            Debug.Log("Broken4");
            return false;
        }
        return true;
    }
        
}