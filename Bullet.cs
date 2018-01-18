using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
    void OnCollisionEnter2D (Collision2D col)
    {
        if (this.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }
    
	// Update is called once per frame
	void Update () {
		
	}
}
