using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : LEngine.UnitySingleton<Character> {
    public Ball ball;
    public Camera mainCamera;
    private Transform cache;
    
	// Use this for initialization
	void Start () {
        cache = transform;

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ball.Play();
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 pos = cache.transform.position;
            Vector3 target = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            pos.x = target.x;
            cache.transform.position = pos;
        }
	}
    //public Vector3 CollisionBrick(GameObject go, Vector3 current)
    //{
    //    if (bricks.ContainsKey(go))
    //    {
    //        Brick brick = bricks[go];
    //        Vector3 brickPos = brick.transform.position;
    //        Vector3 lerp = brickPos - current;
    //        bricks.Remove(go);
    //        GameObject.Destroy(brick.gameObject);
    //        /// left right 
    //        if (Mathf.Abs(lerp.x) > Mathf.Abs(lerp.y))
    //        {
    //            // right 
    //            if (lerp.x > 0)
    //            {
    //                return Vector3.left;
    //            }
    //            else
    //            {
    //                // left
    //                return Vector3.right;
    //            }
    //        }
    //        else
    //        {
    //            // up 
    //            if (lerp.y > 0)
    //            {
    //                return Vector3.down;
    //            }
    //            else
    //            {
    //                // down
    //                return Vector3.up;
    //            }
    //        }
    //    }
    //    return Vector3.zero;
    //}


}
