using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour {

    public float speed = 6.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += transform.up * Time.deltaTime * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyController>().enemyHealth -= 1;
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Obstacle" || collision.gameObject.name == "crate")
        {
            Destroy(gameObject);
        }
    }

}
