using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player;
    public float cameraSpeed;

    private Vector3 offset;
    private Vector2 dimensions;
    private Vector3 BottomLeft;



    // Use this for initialization
    void Start()
    {

        offset = transform.position - player.transform.position;
        dimensions = CalculateScreenSizeInWorldCoords();

    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 v1 = new Vector3(0, 0, Camera.main.nearClipPlane);
        BottomLeft = Camera.main.ViewportToWorldPoint(v1);
        //Debug.Log(BottomLeft);


        if (Mathf.Abs(transform.position.x - player.transform.position.x) > dimensions.x / 5 || Mathf.Abs(transform.position.y - player.transform.position.y) > dimensions.y / 5)
        {
            //SmoothCamera();
        }
        else
        {
            if (CheckPlayerBounds())
            {
                this.GetComponent<Rigidbody>().velocity = this.GetComponent<Rigidbody>().velocity * .99f;
            }
            else
            {
                transform.position = player.transform.position + offset;
            }

        }

    }

    Vector2 CalculateScreenSizeInWorldCoords()
    {

        Vector3 v1 = new Vector3(0, 0, Camera.main.nearClipPlane);
        Vector3 v2 = new Vector3(1, 0, Camera.main.nearClipPlane);
        Vector3 v3 = new Vector3(1, 1, Camera.main.nearClipPlane);

        BottomLeft = Camera.main.ViewportToWorldPoint(v1);
        v2 = Camera.main.ViewportToWorldPoint(v2);
        v3 = Camera.main.ViewportToWorldPoint(v3);

        float width = (v2.x - BottomLeft.x);
        float height = (v3.y - v2.y);
        Vector2 dimensions = new Vector2(width, height);

        return dimensions;
    }

    void SmoothCamera()
    {
        //Vector3 preTarget;
        //Vector3 velocity = new Vector3(0, 0, 0);

        //preTarget = player.GetComponent<Rigidbody>().velocity * cameraSpeed;
        //preTarget.z = -21.79f;
        //transform.position = Vector3.SmoothDamp(transform.position, preTarget, ref velocity, 0.30f, Mathf.Infinity, Time.deltaTime);
        this.GetComponent<Rigidbody>().velocity = player.GetComponent<Rigidbody>().velocity * 2.0f;
    }

    bool CheckPlayerBounds()
    {
        if (player.transform.position.x > BottomLeft.x + dimensions.x)
        {
            Debug.Log("Broken1");
            return false;
        }
        if (player.transform.position.x < BottomLeft.x)
        {
            Debug.Log("Broken2");

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


1 CommentCol