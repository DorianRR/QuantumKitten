using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D2_SpawnDespawn : MonoBehaviour
{

    public GameObject GravityWell;
    Ray touchRay;
    RaycastHit touchHit;

    private GameObject spawnedWell;
    private GameObject MainCamera;

    private void Start()
    {
        MainCamera = GameObject.Find("Main Camera");
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(touchRay, out touchHit);
            spawnedWell = Instantiate(GravityWell, touchHit.point, Quaternion.identity);

            MainCamera.GetComponent<D_Camera>().CenterOnSpawnedGW(touchHit.point);


        }
        if (Input.GetMouseButtonUp(0))

        {
            gameObject.GetComponent<D2_PlayerController>().startedWhirl = false;
            gameObject.GetComponent<D2_PlayerController>().pullButNotWhirl = false;


            Destroy(spawnedWell);
            gameObject.GetComponent<D2_PlayerController>().Launch();
            MainCamera.GetComponent<D_Camera>().reCenter();

        }
    }
}