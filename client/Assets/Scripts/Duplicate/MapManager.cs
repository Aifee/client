using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LEngine;

public class MapManager :  UnitySingleton<MapManager>
{
    public Camera MainCamera;
    public int ReferenceResolutionX = 720;
    public Transform BricksRoot;
    public GameObject BrickItem;
    private Dictionary<GameObject, Brick> bricks = new Dictionary<GameObject, Brick>();
    

    // Use this for initialization
    void Start () {
        float aspect = (float)Screen.width / (float)Screen.height;
        MainCamera.orthographicSize = 50f / aspect / 2;
        InitBricks();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void InitBricks()
    {
        for(int i = 0; i < 17; i++)
        {
            for(int j = 0; j < 5; j++)
            {
                Brick brick = new Brick(GameObject.Instantiate(BrickItem));
                brick.Parent = BricksRoot;
                float posX = (i - 8) * 2.5f;
                float posY = j * -2.5f;
                brick.Position = new Vector3(posX, posY, 0);
                brick.BrickName = string.Format("Brick_{0}_{1}", i, j);
                bricks.Add(brick.gameObject, brick);
            }
        }
    }

    public Vector3 ClampBound(Vector3 pos)
    {
        if(pos.x <= -25)
        {
            return Vector3.right;
        }
        if(pos.x >= 25)
        {
            return Vector3.left;
        }
        if(pos.y <= -36)
        {
            return Vector3.up;
        }
        if(pos.y >= 36)
        {
            return Vector3.down;
        }
        return Vector3.zero;
    }

    public Vector3 CollisionBrick(GameObject go, Vector3 current)
    {
        if (bricks.ContainsKey(go))
        {
            Brick brick = bricks[go];
            Vector3 brickPos = brick.transform.position;
            Vector3 lerp = brickPos - current;
            bricks.Remove(go);
            GameObject.Destroy(brick.gameObject);
            /// left right 
            if (Mathf.Abs(lerp.x) > Mathf.Abs(lerp.y))
            {
                // right 
                if (lerp.x > 0)
                {
                    return Vector3.left;
                }
                else
                {
                    // left
                    return Vector3.right;
                }
            }
            else
            {
                // up 
                if (lerp.y > 0)
                {
                    return Vector3.down;
                }
                else
                {
                    // down
                    return Vector3.up;
                }
            }
        }
        return Vector3.zero;
    }
}
