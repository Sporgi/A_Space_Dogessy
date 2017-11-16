using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float horizontalSpeed;
    public float jumpStrength;
    public bool frozen;

    float moveHorizontal;
    float xVelocity;
    public bool jump;
    float yVelocity;


	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
    
       
        //Calculating x movement
        moveHorizontal = Input.GetAxis("Horizontal");
        xVelocity = moveHorizontal * horizontalSpeed;

        //Calculating y movement
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && !jump)
        {
            yVelocity = jumpStrength;

        }
        else
        {
            yVelocity = GetComponent<Rigidbody2D>().velocity.y;
        }

        if (yVelocity < -jumpStrength)
        {
            yVelocity = -jumpStrength;
        }

        //Putting it together
        Vector2 velocity = new Vector2(xVelocity, yVelocity);

        //Shoving it into the actual velocity
        GetComponent<Rigidbody2D>().velocity = velocity;    

    }
	
}
