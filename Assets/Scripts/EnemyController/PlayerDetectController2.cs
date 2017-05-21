using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectController2 : MonoBehaviour {

    public GameObject shurikenPrefab;
    public float timeBetweenShots = 0.3333f;
    public float timeToDestroy = 4.0f;
    private float timestamp;
    public bool shoot = false;
    Quaternion t;

    // Use this for initialization
    void Start () {
        t = transform.rotation * Quaternion.Euler(0, 0, -90f);
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time > timestamp)
        {
            timestamp = Time.time + timeBetweenShots;
            GameObject arrow = (GameObject)Instantiate(shurikenPrefab, transform.position, t);
            Physics2D.IgnoreCollision(arrow.GetComponent<BoxCollider2D>(), GetComponentInParent<BoxCollider2D>());
            Physics2D.IgnoreCollision(arrow.GetComponent<BoxCollider2D>(), GetComponent<CircleCollider2D>());
            Destroy(arrow, timeToDestroy);

        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.gameObject.tag == "Player")
        {
            shoot = true;
            transform.LookAt(collision.gameObject.transform);
            //EnemyController ec = GetComponentInParent<EnemyController>();
            //ec.isFacingLeft = !(ec.isFacingLeft);
            //ec.playerFlip();

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            shoot = false;
        }
    }
}
