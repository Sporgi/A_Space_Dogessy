using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMovement : MonoBehaviour {

    public float xChange;
    public float yChange;
    public float speed;

    Vector3 closed;
    Vector3 open;
    public bool doorOpen;


    // Use this for initialization
    void Start () {
        closed = GetComponentInParent<Transform>().position;
        closed.z = 0;
        open = new Vector3(closed.x + xChange, closed.y + yChange, closed.z);
    }
	
	// Update is called once per frame
	void Update () {
        if (doorOpen == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, open, speed/10);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, closed, speed/10);
        }

        
    }
}
