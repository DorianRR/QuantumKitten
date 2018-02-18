using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldSpawn : MonoBehaviour
{

    public GameObject GravityWell;
    Ray touchRay;
    Ray setRay;
    RaycastHit touchHit;
    //RaycastHit setRay;
    //public float cooldown = 2f;

    private GameObject spawnedWell;
    private GameObject MainCamera;
    private bool onSpawn = true;

    private void Start()
    {
        MainCamera = GameObject.Find("Main Camera");
    }
    
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && gameObject.GetComponent<PlayerController>().canSpawn && onSpawn)
        {
            Debug.Log("make.");

            gameObject.GetComponent<ObjectiveIndicator>().externalPause = true;
            onSpawn = false;
            touchRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(touchRay, out touchHit);
            spawnedWell = Instantiate(GravityWell, touchHit.point, Quaternion.identity);

            MainCamera.GetComponent<CameraController>().CenterOnSpawnedGW(touchHit.point);
            


        }


        else if (Input.GetMouseButtonUp(0) && !onSpawn)
        {
            Debug.Log("destroy.");
            gameObject.GetComponent<ObjectiveIndicator>().externalPause = false;

            onSpawn = true;
            gameObject.GetComponent<PlayerController>().setWhirl(false);
            gameObject.GetComponent<PlayerController>().Launch();


            Destroy(spawnedWell);
            MainCamera.GetComponent<CameraController>().setCenteredOnGW(false);

        }

        if(spawnedWell)
        {
            setRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(setRay, out touchHit);
            spawnedWell.transform.position = Vector3.Lerp(spawnedWell.transform.position, touchHit.point, Time.deltaTime* 5);
           
        }
    }


    public void ForcedDeSpawn()
    {
        onSpawn = true;
        gameObject.GetComponent<PlayerController>().setWhirl(false);
        gameObject.GetComponent<PlayerController>().Launch();


        Destroy(spawnedWell);
        MainCamera.GetComponent<CameraController>().setCenteredOnGW(false);

        //MainCamera.GetComponent<CameraController>().reCenter();
    }


}