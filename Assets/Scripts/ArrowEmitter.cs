using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowEmitter : MonoBehaviour {

    public GameObject arrowPrefab;
    public float timeBetweenShots = 2.0f;
    public float timeToDestroy = 4.0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        ShootArrow();
	}

    void ShootArrow()
    {
        timeBetweenShots -= Time.deltaTime;

        if (timeBetweenShots <= 0)
        {
            GameObject arrow = (GameObject)Instantiate(arrowPrefab, transform.position, this.transform.rotation);
            timeBetweenShots = 2f;
            Destroy(arrow, timeToDestroy);
        }
    }
}
