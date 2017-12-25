using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class LevelMap : MonoBehaviour {
    
    private List<BrickItem> bricks = new List<BrickItem>();
	// Use this for initialization
	void Start () {
        TextAsset asset = Resources.Load<TextAsset>("Configs/map1");

        string[] raws = asset.text.Split('\n');
        for(int i = 0; i < raws.Length; i++)
        {
            Debug.Log(raws[i]);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
