using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
public class ScalePlaneWithScreenSize : MonoBehaviour
{

    [SerializeField]
    private VideoClip VC = null;

    [SerializeField]
    private GameObject EndingPanel = null;

    private void Awake()
    {
        StartCoroutine(DeleteCoroutine());
        //float height = Camera.main.orthographicSize;
        //float width = height * Screen.width / Screen.height;
        //transform.localScale =  new Vector3(width, 0.1f, height);
        transform.localScale = new Vector3(Camera.main.orthographicSize / 1.25f * (Screen.width / Screen.height), 0.1f, Camera.main.orthographicSize / 1.25f);
    }
    
    IEnumerator DeleteCoroutine()
    {
        yield return new WaitForSeconds((float)VC.length);
        EndingPanel.SetActive(true);
        Destroy(gameObject);
    }
  
}
