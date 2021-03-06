﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSpawn : MonoBehaviour
{

    public GameObject GravityWell;
    Ray touchRay;
    RaycastHit touchHit;
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
            onSpawn = false;
            touchRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(touchRay, out touchHit);
            spawnedWell = Instantiate(GravityWell, touchHit.point, Quaternion.identity);

            MainCamera.GetComponent<CameraController>().CenterOnSpawnedGW(touchHit.point);


        }
        else if (Input.GetMouseButtonDown(0) && !onSpawn)
        {

            onSpawn = true;
            //gameObject.GetComponent<PlayerController>().setWhirl(false);
            gameObject.GetComponent<PlayerController>().Launch();


            Destroy(spawnedWell);
            MainCamera.GetComponent<CameraController>().setCenteredOnGW(false);

        }

        if(spawnedWell)
        {
            float distance = (spawnedWell.transform.position - transform.position).magnitude;
            //float distance= 10f;
            if (distance < 5f)
            {

                onSpawn = true;
                //gameObject.GetComponent<PlayerController>().setWhirl(false);


                Destroy(spawnedWell);
                MainCamera.GetComponent<CameraController>().setCenteredOnGW(false);

                //MainCamera.GetComponent<CameraController>().reCenter();


            }
        }
    }

    public void ButtonSpawn()
    {
        //touchRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Physics.Raycast(touchRay, out touchHit);
        spawnedWell = Instantiate(GravityWell, new Vector3(-55, 0, 0), Quaternion.identity);

    }

    public void ForcedDeSpawn()
        {
            onSpawn = true;
            //gameObject.GetComponent<PlayerController>().setWhirl(false);
            gameObject.GetComponent<PlayerController>().Launch();


            Destroy(spawnedWell);
            MainCamera.GetComponent<CameraController>().setCenteredOnGW(false);

            //MainCamera.GetComponent<CameraController>().reCenter();
        }


    }