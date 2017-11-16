using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    bool aggro;
    bool turnt;
    public float horizontalSpeed;
    public float jumpStrength;
    public bool frozen;
    float distToPlayer;
    public Transform player;
    Vector2 lastSeenPosition;

    public float moveHorizontal;
    float xVelocity;
    float yVelocity;


    // Use this for initialization
    void Start()
    {
        moveHorizontal = 1f;
        turnt = false;
        distToPlayer = -1f;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            if (!aggro)
            {
                aggro = true;
            }
            distToPlayer = gameObject.GetComponent<Collider2D>().Distance(col).distance;
            player = col.transform;
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Flag" && !turnt && !aggro) //Find the flag to turn and make sure character is not in the process of turning
        {
            moveHorizontal *= -1; //Turn around
            turnt = true; //Is turning
        }
        if (col.tag == "Player")
        {
            distToPlayer = gameObject.GetComponent<Collider2D>().Distance(col).distance;
            player = col.transform;
        }
    }


    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Flag" && turnt)
        {
            turnt = false; //No longer turning
            gameObject.GetComponentInChildren<Collider2D>().offset = new Vector2(gameObject.GetComponentInChildren<Collider2D>().offset.x * -1f, 0);
        }
        if (col.tag == "Player" && aggro)
        {
            aggro = false;
            lastSeenPosition = player.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (aggro)
        {
            if ((GetComponent<Transform>().position.x > player.position.x && moveHorizontal > 0) || (GetComponent<Transform>().position.x < player.position.x && moveHorizontal < 0))
            {
                moveHorizontal *= -1f;
            }
            if (distToPlayer <= 3f && distToPlayer > 0f)
            {
                moveHorizontal = 0f;
            }
            else
            {
                moveHorizontal = -1f * (float)(GetComponent<Transform>().position.x - player.position.x) / Mathf.Abs((float)GetComponent<Transform>().position.x - player.position.x);
            }
        }
        else
        {
            //Calculating x movement
            xVelocity = moveHorizontal * horizontalSpeed;

            //Calculating y movement
            yVelocity = GetComponent<Rigidbody2D>().velocity.y;

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
}
