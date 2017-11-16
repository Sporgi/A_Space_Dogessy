using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	
	void OnTriggerStay2D (Collider2D col) {
        if (col.tag == "Surface")
        {
            gameObject.GetComponentInParent<Movement>().jump = false;
        }
	}

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Surface")
        {
            gameObject.GetComponentInParent<Movement>().jump = true;
        }
    }
}
