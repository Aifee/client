using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour {

    public Camera mainCamera;
    public GameObject cube;
    public Transform Root;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    [ContextMenu("Execute")]
    public void Execute()
    {
        createMap();
    }


    private void createMap()
    {
        for(int i = 0; i < 30; i++)
        {
            for(int j = 0; j < 45; j++)
            {
                GameObject go = GameObject.Instantiate(cube);
                go.name = string.Format("Index_{0}_{1}", i, j);
                go.transform.parent = Root;
                
                Vector3 pos = new Vector3((j - 22) * 1.25f, i * 1.25f,0);
                go.transform.position = pos;
            }
        }
    }
}
