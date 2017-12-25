using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LEngine;

public class MapManager :  UnitySingleton<MapManager>
{
    public Camera MainCamera;
    public int ReferenceResolutionX = 720;
    public Transform BricksRoot;
    private Dictionary<GameObject, Brick> bricks = new Dictionary<GameObject, Brick>();
    private Vector2 Horizontal;
    
    // Use this for initialization
    void Start () {
        float aspect = (float)Screen.width / (float)Screen.height;
        MainCamera.orthographicSize = 56f / aspect / 2;
        Horizontal = new Vector2(-56f / 2f, 56f / 2f);
        InitBricks();
    }
	
	// Update is called once per frame
	void Update () {

	}


    private void InitBricks()
    {
        List<List<int>> level = ResourceManager.Instance.GetLevel(1);
        
        for(int i = 0; i < level.Count; i++)
        {
            for(int j = 0; j < level[i].Count; j++)
            {
                BrickColor bc = (BrickColor)System.Enum.Parse(typeof(BrickColor), level[i][j].ToString());
                if(bc != BrickColor.None)
                {
                    Brick brick = BrickFactory(bc, i, j);
                    bricks.Add(brick.gameObject, brick);
                }
            }
        }
    }

    private Brick BrickFactory(BrickColor bc,int raw,int rank)
    {
        GameObject go = ResourceManager.Instance.GetBrick(bc);
        Brick brick = new Brick(GameObject.Instantiate(go));
        brick.Parent = BricksRoot;
        float posX = (rank - 22) * 1.25f;
        float posY = -raw * 1.25f;
        brick.Position = new Vector3(posX, posY, 0);
        brick.BrickName = string.Format("Brick_{0}_{1}", raw, rank);
        return brick;
    }

    public Vector3 ClampBound(Vector3 pos)
    {
        if(pos.x - 0.5f <= Horizontal.x)
        {
            return Vector3.right;
        }
        if(pos.x + 0.5f >= Horizontal.y)
        {
            return Vector3.left;
        }
        if(pos.y + 0.5f >= 40)
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
