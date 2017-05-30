using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowEmitter : MonoBehaviour {

    public GameObject arrowPrefab;
    public float timeBetweenShots;
    public float timeToDestroy;

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
            Vector3 position = transform.position;
            position.z += 0.50f;
            GameObject arrow = (GameObject)Instantiate(arrowPrefab, position, this.transform.rotation);
            timeBetweenShots = 2f;
            Destroy(arrow, timeToDestroy);
        }
    }
}
