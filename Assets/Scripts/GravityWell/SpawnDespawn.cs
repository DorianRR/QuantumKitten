using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDespawn : MonoBehaviour
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
            Debug.Log("Pressed left click");
            touchRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(touchRay, out touchHit);
            Debug.Log(touchHit.transform);
            spawnedWell = Instantiate(GravityWell, touchHit.point, Quaternion.identity);

        }
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("mouse up");
            Destroy(spawnedWell);
        }
    }
}