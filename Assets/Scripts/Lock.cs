using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour {

    public bool xlock;
    public bool ylock;
    public float speed;

    public GameObject Camera;
    public GameObject Player;

    // Use this for initialization
    void Start() {

    }

    void OnTriggerEnter2D(Collider2D col)
    {

    }

    // Update is called once per frame
    void OnTriggerStay2D () {

        Vector3 glideTo = transform.position;

        if (xlock)
        {
            Camera.GetComponent<Follow>().xLock = true;
        } else
        {
            glideTo.x = Player.GetComponent<Transform>().position.x;
            Camera.GetComponent<Follow>().xLock = false;
        }

        if (ylock)
        {
            Camera.GetComponent<Follow>().yLock = true;
        } else
        {
            glideTo.y = Player.GetComponent<Transform>().position.y;
            Camera.GetComponent<Follow>().yLock = false;
        }

        Camera.GetComponent<Transform>().position = Vector3.MoveTowards(Camera.GetComponent<Transform>().position, glideTo, speed / 10);        
    }
}
