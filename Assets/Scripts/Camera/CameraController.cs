using System.Collections;
using System.Collections.Generic;
using UnityEngine.Timeline;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player;
    public float lerpRatio;

    private bool centeredOnGW = false;
    private Vector3 offset;
    private Vector3 GWPosition;
      

    void Start()
    {
        transform.position = (player.GetComponent<Rigidbody>().transform.position);
        transform.position = new Vector3(transform.position.x, transform.position.y, -22f);


        Debug.Log(transform.position);

        offset = player.GetComponent<Rigidbody>().transform.position - transform.position;

    }

    void LateUpdate()
    {
        //Debug.Log(offset);
        transform.position = (player.GetComponent<Rigidbody>().transform.position + offset);
        //transform.position = new Vector3(Mathf.Clamp(transform.position.x, -58f, 58f), Mathf.Clamp(transform.position.y, -30f, 30f), -22);

        //if (centeredOnGW)
        //{
        //    GWPosition.z = -22f;

        //    transform.position = Vector3.Lerp(transform.position, GWPosition, lerpRatio/2 * Time.deltaTime);+
        float temp = ((Mathf.Abs(player.GetComponent<Rigidbody>().velocity.magnitude) - 10f) / (25f - 10f)) * 20f;
        temp = Mathf.Clamp(temp, 10f, 25f);
        gameObject.GetComponent<Camera>().orthographicSize = 
            Mathf.Lerp(gameObject.GetComponent<Camera>().orthographicSize, temp, lerpRatio/5 * Time.deltaTime);
        float tempOrthSize = gameObject.GetComponent<Camera>().orthographicSize;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, (((tempOrthSize-10))*2f)-70, (-(tempOrthSize - 10) * 2f) + 70), Mathf.Clamp(transform.position.y, ((tempOrthSize-10)-34), (35 - (tempOrthSize - 10))), -22);
        
    }

    public void CenterOnSpawnedGW(Vector3 location)
    {
        centeredOnGW = true;
        GWPosition = location;
    }

    public bool getCenteredOnGW()
    {
        return centeredOnGW;
    }

    public void setCenteredOnGW(bool set)
    {
        centeredOnGW = set;
    }

}