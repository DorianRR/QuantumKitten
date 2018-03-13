using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glow : MonoBehaviour {

    private Color temp = Color.gray;
    private Renderer rend;

	// Use this for initialization
	void Start () {

        rend = this.GetComponent<MeshRenderer>();

	}
	
	// Update is called once per frame
	void Update () {

        temp.a = Mathf.PingPong(Time.time * .15f, .23f) + .1f;

        rend.material.color = temp;

	}
}
