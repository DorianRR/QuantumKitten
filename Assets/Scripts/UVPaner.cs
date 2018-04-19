using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UVPaner : MonoBehaviour {

    public float speed = 1;

    Renderer rend;

    Color MatColor;

    Color tempColor;

    // Use this for initialization
    void Start () {

        rend = GetComponent<Renderer>();

        MatColor = rend.material.color;

        tempColor = rend.material.color;

	}
	
	// Update is called once per frame
	void Update () {

        rend.material.SetTextureOffset("_MainTex",new Vector2(Time.time * speed, 0));

        //rend.material.SetTextureOffset("_DetailMask", new Vector2(Time.time * speed, 0));

        //rend.material.SetTextureOffset("_DetailAlbedoMap", new Vector2(Time.time * speed, 0));

        tempColor = Color.Lerp(new Color (MatColor.r, MatColor.g, MatColor.b, 0f), new Color(MatColor.r, MatColor.g, MatColor.b, .5f), Mathf.PingPong(Time.time, .75f) * 2);

        rend.material.color = tempColor;
    }
}
