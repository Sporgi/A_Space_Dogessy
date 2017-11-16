using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    Vector2 pos;
    

    // Use this for initialization
    void Start()
    {
        GetComponentInParent<DoorMovement>().doorOpen = false;
        pos = transform.position;
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {

            GetComponentInParent<DoorMovement>().doorOpen = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            GetComponentInParent<DoorMovement>().doorOpen = false;
        }
    }

    void Update()
    {
        transform.position = pos;
    }

}
