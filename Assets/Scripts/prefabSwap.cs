using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class prefabSwap : MonoBehaviour
{

    public GameObject newPrefab;
    public GameObject[] oldPrefabs;
    public string searchTag;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void swapObjects()
    {
        bool swapSelf = false;
        for (int i = 0; i < oldPrefabs.Length; i++)
        {
            if (oldPrefabs[i] == gameObject)
            {
                swapSelf = true;
            }
            else
            {
                swapPrefabs(oldPrefabs[i]);
            }
        }
        if (swapSelf)
        {
            swapPrefabs(gameObject);
        }
    }

    private void swapPrefabs(GameObject oldGameObject)
    {
        Quaternion rotation = oldGameObject.transform.rotation;
        Vector3 position = oldGameObject.transform.position;

        GameObject newObject = Instantiate(newPrefab, position, rotation);

        if(oldGameObject.transform.parent !=null)
        {
            newObject.transform.SetParent(oldGameObject.transform.parent);
        }
        DestroyImmediate(oldGameObject);
    }

    
}
[CustomEditor(typeof(prefabSwap))]

public class EditorPrefabSwap : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        prefabSwap PrefabSwap = (prefabSwap)target;

        PrefabSwap.swapObjects();
        base.OnInspectorGUI();
    }
}
