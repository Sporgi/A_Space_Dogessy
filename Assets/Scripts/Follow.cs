using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {


    public GameObject Player;

    public float xPredict;
    public float yPredict;
    public float speed;

    public bool xLock;
    public bool yLock;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 posInitial = transform.position;
        Vector3 posFinal = transform.position;

        if (!xLock)
        {
            posFinal.x = Player.GetComponent<Rigidbody2D>().position.x + Player.GetComponent<Rigidbody2D>().velocity.x * xPredict / 100;
        }

        if (!yLock)
        {
            posFinal.y = Player.GetComponent<Rigidbody2D>().position.y + Player.GetComponent<Rigidbody2D>().velocity.y * yPredict / 100;
        }

        posFinal.z = -1;
        posInitial.z = -1;

        //GetComponent<Transform>().position = posFinal;

        transform.position = Vector3.MoveTowards(posInitial, posFinal, speed / 10);
        

    }
}
