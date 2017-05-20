using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControllerOnGameWon : MonoBehaviour {


    Animator anim;


    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")
        {
            Debug.Log("Player is here...");
            anim.SetBool("isGameWon", true);
        }
    }
}
