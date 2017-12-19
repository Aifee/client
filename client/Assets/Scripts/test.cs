using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour {

    public Transform from;
    public Transform to;
    public Text text;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 lerp = to.position - from.position;
        string dir = "zero";
        /// left right 
        if(Mathf.Abs(lerp.x) > Mathf.Abs(lerp.y))
        {
            // right 
            if(lerp.x > 0)
            {
                dir = "right";
            }else
            {
                dir = "left";
            }
        }
        else
        {
            // up down
            if(lerp.y > 0)
            {
                dir = "up";
            }
            else
            {
                dir = "down";
            }
        }
        float angle = Mathf.Asin(Vector3.Distance(Vector3.zero, Vector3.Cross(from.position.normalized, to.position.normalized))) * Mathf.Rad2Deg;
        text.text = string.Format("dir = {0}", dir);
        //float dot = Vector3.Dot(from.position.normalized, to.position.normalized);
        //text.text = string.Format("{0}", dot);
    }
}
