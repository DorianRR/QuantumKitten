using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D_SpawnDespawn : MonoBehaviour
{

    public GameObject GravityWell;
    Ray touchRay;
    RaycastHit touchHit;
    private GameObject spawnedWell;




    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(touchRay, out touchHit);
            spawnedWell = Instantiate(GravityWell, touchHit.point, Quaternion.identity);


        }
        if (Input.GetMouseButtonUp(0))
        {
            Destroy(spawnedWell);
        }
    }
}