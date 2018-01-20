using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;
    public float cameraSpeed;

    private Vector3 offset;
    private Vector2 dimensions;
    
   

	// Use this for initialization
	void Start () {

        offset = transform.position - player.transform.position;

        dimensions = CalculateScreenSizeInWorldCoords();
        Debug.Log(offset);
        
	}
	
	// Update is called once per frame
	void LateUpdate () {
        //transform.position = player.transform.position + offset;
        Vector3 preTarget;
        Vector3 velocity = new Vector3(0, 0, 0);

        preTarget = player.GetComponent<Rigidbody>().velocity * cameraSpeed;
        preTarget.z = -21.79f;
        transform.position = Vector3.SmoothDamp(transform.position, preTarget, ref velocity, 0.3f);


        if (Mathf.Abs(transform.position.x - player.transform.position.x) > dimensions.x/5)
        {
            Vector3 target = (player.transform.position + offset);
            //Vector3 velocity = new Vector3(0,0,0);
            transform.position = Vector3.SmoothDamp(transform.position, target, ref velocity, 0.3f);

        }

    }

    Vector2 CalculateScreenSizeInWorldCoords(){

        Vector3 v1 = new Vector3 (0, 0, Camera.main.nearClipPlane);
        Vector3 v2 = new Vector3(1, 0, Camera.main.nearClipPlane);
        Vector3 v3 = new Vector3(1, 1, Camera.main.nearClipPlane);

        v1 = Camera.main.ViewportToWorldPoint(v1);
        v2 = Camera.main.ViewportToWorldPoint(v2);
        v3 = Camera.main.ViewportToWorldPoint(v3);

        float width = (v2.x - v1.x);
        float height = (v3.y - v2.y);
         Vector2 dimensions = new Vector2(width, height);
 
        return dimensions;
    }

void LerpCamera()
    {

    }
}
