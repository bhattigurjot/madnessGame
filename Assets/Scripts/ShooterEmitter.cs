using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEmitter : MonoBehaviour {

    public GameObject shurikenPrefab;
    public float timeBetweenShots = 2.0f;
    public float timeToDestroy = 4.0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Shoot();
        timeBetweenShots -= Time.deltaTime;
    }

    public void Shoot()
    {
        if (timeBetweenShots > 0)
        {
            GameObject arrow = (GameObject)Instantiate(shurikenPrefab, transform.position, this.transform.rotation);
            Destroy(arrow, timeToDestroy);
        }
        
    }
}
