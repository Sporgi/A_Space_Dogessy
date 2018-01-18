using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public GameObject BulletPrefab;
    public Transform BulletSpawn;

    // Use this for initialization
    void Start () {
        gameObject.transform.parent = gameObject.GetComponentInParent<Transform>();
        gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        gameObject.GetComponent<Collider2D>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject Bullet = Instantiate(BulletPrefab, BulletSpawn.position, BulletSpawn.rotation);

            Bullet.tag = "Bullet";
            Bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(12f, 0);
        }
	}
}
