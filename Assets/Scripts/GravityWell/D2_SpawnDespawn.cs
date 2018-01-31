﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D2_SpawnDespawn : MonoBehaviour
{

    public GameObject GravityWell;
    Ray touchRay;
    RaycastHit touchHit;

    private GameObject spawnedWell;
    private GameObject MainCamera;
    private bool onSpawn = true;

    private void Start()
    {
        MainCamera = GameObject.Find("Main Camera");
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && gameObject.GetComponent<D2_PlayerController>().canSpawn && onSpawn)
        {
            onSpawn = false;
            touchRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(touchRay, out touchHit);
            spawnedWell = Instantiate(GravityWell, touchHit.point, Quaternion.identity);

            MainCamera.GetComponent<D_Camera>().CenterOnSpawnedGW(touchHit.point);


        }
        //if (Input.GetMouseButtonUp(0))
        else if (Input.GetMouseButtonDown(0) && !onSpawn)
        {
            onSpawn = true;
            gameObject.GetComponent<D2_PlayerController>().startedWhirl = false;


            Destroy(spawnedWell);
            gameObject.GetComponent<D2_PlayerController>().Launch();
            MainCamera.GetComponent<D_Camera>().reCenter();

        }
    }
}