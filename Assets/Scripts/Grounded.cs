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
            GetComponent<BoxCollider2D>().size = new Vector2(0.8f, 1.8f);
        }
	}

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Surface")
        {
            gameObject.GetComponentInParent<Movement>().jump = true;
            GetComponent<BoxCollider2D>().size = new Vector2(0.8f, 1.8f);

        }
    }
}
