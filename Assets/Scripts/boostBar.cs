using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boostBar : MonoBehaviour {



    private void OnEnable()
    {
        PlayerController.UpdateBoost += boostScale;
    }

    private void OnDisable()
    {
        PlayerController.UpdateBoost -= boostScale;
    }


    private void boostScale(float newScale)
    {
        Vector3 scaleValue = new Vector3(newScale / 100, 1, 1);
        GetComponent<RectTransform>().localScale = scaleValue;
    }
}
