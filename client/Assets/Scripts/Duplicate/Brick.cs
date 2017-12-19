using UnityEngine;

public class Brick
{
    public GameObject gameObject { get; private set; }
    public Transform transform { get; private set; }
    
    private Vector3 position = Vector3.zero;

    public Brick(GameObject go)
    {
        gameObject = go;
        transform = go.transform;
    }

    public Vector3 Position
    {
        get
        {
            return position;
        }
        set
        {
            position = value;
            if (transform != null)
            {
                transform.localPosition = position;
            }
        }
    }
    public Transform Parent
    {
        get
        {
            if (transform != null)
                return transform.parent;
            return null;
        }
        set
        {
            if (transform != null)
                transform.parent = value;
        }
    }
    public string BrickName
    {
        get
        {
            if (gameObject != null)
            {
                return gameObject.name;
            }
            return "";
        }
        set
        {
            if(gameObject != null)
            {
                gameObject.name = value;
            }
        }
    }
}