using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEmitter : MonoBehaviour {

    public GameObject shurikenPrefab;
    public float timeBetweenShots = 0.3333f;
    public float timeToDestroy = 4.0f;
    private float timestamp;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > timestamp && Input.GetButton("Fire1"))
        {
            timestamp = Time.time + timeBetweenShots;
            GameObject arrow = (GameObject)Instantiate(shurikenPrefab, transform.position, this.transform.rotation);
            Physics2D.IgnoreCollision(arrow.GetComponent<Collider2D>(), GetComponentInParent<Collider2D>());
            Destroy(arrow, timeToDestroy);
            
        }
    }
}
