using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Camera))]

public class BlackHoleEffect : MonoBehaviour
{


    //public settings
    public Shader shader;
    public Transform blackHole;
    public Texture2D blackHoleTexture;
    public float ratio; // aspect ratio of the screen
    public float blackHoleSize = 0.1f; //size of black hole in scene
    public float gravFieldSize = 1.0f;  //how large of an area the distortion of the gravitational field will be moving outward from the center of the gameobject.

    //private settings
    Camera cam;
    Material _material;  //will be procedurally generated

    Material material
    {
        get
        {
            if (_material == null)
            {
                _material = new Material(shader);
                _material.hideFlags = HideFlags.HideAndDontSave;
            }
            return _material;
        }
    }

    private void Update()
    {
        Shader.SetGlobalFloat("_GravFieldSize", gravFieldSize);
        Shader.SetGlobalTexture ("_BlackHoleTexture", blackHoleTexture);

    }

    void OnEnable()
    {
        cam = GetComponent<Camera>();
        ratio = 1f / cam.aspect;
    }


    void OnDisable()
    {
        if (_material)
        {
            DestroyImmediate(_material);
        }
    
    }

    Vector3 wtsp;
    Vector2 pos;

    void OnRenderImage(RenderTexture source, RenderTexture destination)
        //processing happens here
    {
        if(shader && material && blackHole)
        {
            wtsp = cam.WorldToScreenPoint(blackHole.position);

            //is the black hole in front of the camera
            if (wtsp.z > 0) 
            {
                pos = new Vector2(wtsp.x / cam.pixelWidth, (wtsp.y / cam.pixelHeight));
                //apply shader parameters
                _material.SetVector("_Position", pos);
                _material.SetFloat("_Ratio", ratio);
                _material.SetFloat("_Rad", blackHoleSize);
                _material.SetFloat("_Distance", Vector3.Distance(blackHole.position, transform.position));

                //apply the shader to the image
                Graphics.Blit(source, destination, material);
            }

        }
    }

}

