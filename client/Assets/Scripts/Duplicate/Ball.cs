using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public bool isMoving = false;
    public Vector3 direction { get; private set; }
    public float speed;
    private Transform cache;
    // Use this for initialization
    void Start () {
        cache = transform;

    }
	
	// Update is called once per frame
	void Update () {
        if (isMoving)
        {
            Vector3 pos = cache.position;
            Vector3 step = direction.normalized * speed *Time.deltaTime;
            Vector3 next = pos + step;
            Vector3 bound = MapManager.Instance.ClampBound(next);
            if(bound != Vector3.zero)
            {
                direction += bound;
                direction += bound;
            }
            pos += step;
            cache.position = pos;
        }
	}
    public void Play()
    {
        isMoving = true;
        direction = Vector3.left + Vector3.up;
        speed = 30;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject != null)
        {
            if(other.gameObject.tag == "Brick")
            {
                Vector3 bound = MapManager.Instance.CollisionBrick(other.gameObject, cache.position);
                if (bound != Vector3.zero)
                {
                    direction += bound;
                    direction += bound;
                }
            }
        }
    }
}
